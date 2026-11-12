using System.Diagnostics;

namespace Ep07.Solutions;

public class TransientException(string message) : Exception(message);

public class RetryEventArgs(int attempt, Exception error) : EventArgs
{
    public int Attempt { get; } = attempt;
    public Exception Error { get; } = error;
}

public class RetryPolicy
{
    public int MaxAttempts { get; init; } = 3;
    public event EventHandler<RetryEventArgs>? Retrying;

    public T Execute<T>(Func<T> action)
    {
        using var _ = new TimingScope("Execute");
        for (int attempt = 1; ; attempt++)
        {
            try
            {
                return action();
            }
            catch (TransientException ex) when (attempt < MaxAttempts)   // filter: retry only if attempts remain
            {
                Retrying?.Invoke(this, new RetryEventArgs(attempt, ex));
            }
            // A TransientException on the last attempt does not match the filter, so it
            // propagates with its original stack trace. Other exception types escape at once.
        }
    }
}

public sealed class TimingScope(string label) : IDisposable
{
    private readonly Stopwatch _watch = Stopwatch.StartNew();
    public void Dispose() => Console.WriteLine($"  [{label} took {_watch.ElapsedMilliseconds} ms]");
}

public static class RetryExtensions
{
    public static T WithRetry<T>(this Func<T> action, RetryPolicy policy) => policy.Execute(action);
}

public static class Challenge
{
    public static void Run()
    {
        var policy = new RetryPolicy { MaxAttempts = 3 };
        policy.Retrying += (_, e) => Console.WriteLine($"  retry after attempt {e.Attempt}: {e.Error.Message}");

        // 1. Fails twice, then succeeds
        int calls = 0;
        Func<string> flaky = () => ++calls < 3 ? throw new TransientException($"timeout #{calls}") : "data!";
        Console.WriteLine($"Result: {flaky.WithRetry(policy)}");

        // 2. Always fails with a transient error
        Func<int> alwaysDown = () => throw new TransientException("service down");
        try { alwaysDown.WithRetry(policy); }
        catch (TransientException ex) { Console.WriteLine($"Gave up: {ex.Message}"); }

        // 3. A non-transient error is not retried
        Func<int> broken = () => throw new InvalidOperationException("bad config");
        try { broken.WithRetry(policy); }
        catch (InvalidOperationException ex) { Console.WriteLine($"Not retried: {ex.Message}"); }
    }
}
