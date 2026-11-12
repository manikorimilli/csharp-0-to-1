namespace Ep04.Examples;

public static class Ex04_QueueStack
{
    public static void Run()
    {
        // Queue<T>: first in, first out. JS: arr.push() + arr.shift()
        var queue = new Queue<string>();
        queue.Enqueue("job1");
        queue.Enqueue("job2");
        queue.Enqueue("job3");
        Console.WriteLine($"Peek: {queue.Peek()}");          // look without removing
        while (queue.Count > 0)
            Console.WriteLine($"Processing {queue.Dequeue()}");

        // TryDequeue avoids an exception when empty
        if (!queue.TryDequeue(out var next))
            Console.WriteLine("queue is empty");

        // Stack<T>: last in, first out. JS: arr.push() + arr.pop()
        var history = new Stack<string>();
        history.Push("/home");
        history.Push("/products");
        history.Push("/products/42");
        Console.WriteLine($"Current: {history.Peek()}");
        history.Pop();
        Console.WriteLine($"Back to: {history.Peek()}");
        Console.WriteLine($"Remaining: {string.Join(" <- ", history)}"); // iterates top to bottom
    }
}
