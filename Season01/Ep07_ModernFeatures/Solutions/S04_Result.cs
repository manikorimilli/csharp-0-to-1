namespace Ep07.Solutions;

public static class S04_Result
{
    record Result<T>
    {
        public bool IsOk { get; }
        public T? Value { get; }
        public string? Error { get; }

        private Result(bool isOk, T? value, string? error) { IsOk = isOk; Value = value; Error = error; }

        public static Result<T> Ok(T value) => new(true, value, null);
        public static Result<T> Fail(string error) => new(false, default, error);

        public Result<TOut> Map<TOut>(Func<T, TOut> f) =>
            IsOk ? Result<TOut>.Ok(f(Value!)) : Result<TOut>.Fail(Error!);

        public TOut Match<TOut>(Func<T, TOut> onOk, Func<string, TOut> onFail) =>
            IsOk ? onOk(Value!) : onFail(Error!);
    }

    static Result<int> ParseAge(string s) =>
        int.TryParse(s, out var age) && age >= 0
            ? Result<int>.Ok(age)
            : Result<int>.Fail($"'{s}' is not a valid age");

    public static void Run()
    {
        foreach (var input in new[] { "42", "15", "abc" })
        {
            string message = ParseAge(input)
                .Map(age => age >= 18)
                .Match(isAdult => isAdult ? "adult" : "minor",
                       error => $"error: {error}");
            Console.WriteLine($"{input,-4} -> {message}");
        }
    }
}
