// `using` imports a NAMESPACE (not a file). JS: import { Invoice } from "./billing.js"
using Ep06.Billing;
// Alias, useful when two namespaces have the same type name
using Txt = System.Text;

namespace Ep06.Examples;

public static class Ex09_Namespaces
{
    public static void Run()
    {
        var inv = new Invoice("INV-1", 99.5m);           // found via `using Ep06.Billing;`
        Console.WriteLine(inv);

        // Fully qualified name works without a using
        var again = new Ep06.Billing.Invoice("INV-2", 10m);
        Console.WriteLine(again);

        var sb = new Txt.StringBuilder("alias works");
        Console.WriteLine(sb);

        // Key differences from JS modules:
        //  - No per-file imports/exports between your own files: every .cs file in the
        //    project is compiled together. Namespaces only organize NAMES.
        //  - Convention: namespace mirrors the folder path (Company.Project.Folder).
        //  - `global using X;` in one file applies to the whole project.
        //    ImplicitUsings generates a few for you (System, System.Linq, ...).
        Console.WriteLine(typeof(Invoice).FullName);
    }
}
