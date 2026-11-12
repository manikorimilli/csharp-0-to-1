namespace Ep02.Solutions;

public static class Challenge
{
    public static void Run()
    {
        string[] script = { "add 10", "mul 3", "", "sub 4", "oops 1", "print", "div 0", "div 2", "print", "quit", "add 1000" };
        int total = 0;

        foreach (var line in script)
        {
            if (string.IsNullOrWhiteSpace(line)) continue;

            string[] parts = line.Split(' ');
            string command = parts[0];
            int value = parts.Length > 1 && int.TryParse(parts[1], out int n) ? n : 0;

            if (command == "quit") break;   // `break` inside the switch below would only exit the switch

            switch (command)
            {
                case "add": total += value; break;
                case "sub": total -= value; break;
                case "mul": total *= value; break;
                case "div" when value == 0:
                    Console.WriteLine("Cannot divide by zero");
                    break;
                case "div": total /= value; break;
                case "print": Console.WriteLine($"Total: {total}"); break;
                default: Console.WriteLine($"Unknown command: {command}"); break;
            }
        }
    }
}
