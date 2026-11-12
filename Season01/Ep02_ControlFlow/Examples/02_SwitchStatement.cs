namespace Ep02.Examples;

public static class Ex02_SwitchStatement
{
    public static void Run()
    {
        foreach (string day in new[] { "Sat", "Mon", "Wed", "Xyz" })
        {
            switch (day)                 // switch works on strings (Java 7+ too)
            {
                case "Sat":
                case "Sun":              // stacking empty cases = shared body
                    Console.WriteLine($"{day}: weekend");
                    break;               // required: no silent fall-through in C#
                case "Mon":
                    Console.WriteLine($"{day}: ugh");
                    break;
                case "Tue" or "Wed" or "Thu" or "Fri":   // pattern 'or' (C# 9)
                    Console.WriteLine($"{day}: weekday");
                    break;
                default:
                    Console.WriteLine($"{day}: unknown");
                    break;
            }
        }

        // Cases can have conditions with `when`
        int score = 85;
        switch (score)
        {
            case int s when s >= 90:
                Console.WriteLine("A");
                break;
            case int s when s >= 80:
                Console.WriteLine("B");
                break;
            default:
                Console.WriteLine("C or below");
                break;
        }
    }
}
