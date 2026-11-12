namespace Ep05.Examples;

public static class Ex06_NullableReferenceTypes
{
    // With <Nullable>enable</Nullable> in the .csproj (the default for new projects):
    //   string  = "should never be null"  (compiler warns if you assign null)
    //   string? = "may be null"            (compiler warns if you use it without a check)
    // It is a COMPILE-TIME check only, like TypeScript's strictNullChecks.

    class User
    {
        public string Email { get; set; } = "";     // non-null: must be initialized
        public string? Nickname { get; set; }       // optional
    }

    static string DisplayName(User user)
    {
        // return user.Nickname.ToUpper();          // warning CS8602: possible null dereference
        if (user.Nickname is not null)
            return user.Nickname.ToUpper();         // OK: compiler knows it's not null here
        return user.Email;
    }

    public static void Run()
    {
        var u1 = new User { Email = "ann@x.com" };
        var u2 = new User { Email = "bob@x.com", Nickname = "bobby" };
        Console.WriteLine(DisplayName(u1));
        Console.WriteLine(DisplayName(u2));

        // string name = null;                      // warning CS8600
        string? maybe = Environment.GetEnvironmentVariable("SOME_UNSET_VAR");   // API returns string?
        Console.WriteLine(maybe ?? "(env var not set)");

        // Compare TypeScript:
        //   let nick: string | null = null;     <->   string? nick = null;
        //   nick!.length                        <->   nick!.Length
    }
}
