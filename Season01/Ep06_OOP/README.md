# Ep06 OOP the C# Way

Classes, properties, access modifiers, inheritance, interfaces, records and namespaces.
This is the vocabulary of every C# code base. Time: about 3 hours.

## Learning order

| # | Concept | Example | Run |
|---|---|---|---|
| 1 | [Classes and constructors](concepts/01_Classes_Constructors.md) | [01_ClassesConstructors.cs](Examples/01_ClassesConstructors.cs) | `dotnet run -- 01` |
| 2 | [Object initializers](concepts/02_Object_Initializers.md) | [02_ObjectInitializers.cs](Examples/02_ObjectInitializers.cs) | `dotnet run -- 02` |
| 3 | [Properties: get/set/init, auto, computed](concepts/03_Properties.md) | [03_Properties.cs](Examples/03_Properties.cs) | `dotnet run -- 03` |
| 4 | [Access modifiers](concepts/04_Access_Modifiers.md) | [04_AccessModifiers.cs](Examples/04_AccessModifiers.cs) | `dotnet run -- 04` |
| 5 | [static](concepts/05_Static.md) | [05_Static.cs](Examples/05_Static.cs) | `dotnet run -- 05` |
| 6 | [Inheritance, base, virtual/override, abstract, sealed](concepts/06_Inheritance.md) | [06_Inheritance.cs](Examples/06_Inheritance.cs) | `dotnet run -- 06` |
| 7 | [Interfaces](concepts/07_Interfaces.md) | [07_Interfaces.cs](Examples/07_Interfaces.cs) | `dotnet run -- 07` |
| 8 | [Records](concepts/08_Records.md) | [08_Records.cs](Examples/08_Records.cs) | `dotnet run -- 08` |
| 9 | [Namespaces (vs JS modules)](concepts/09_Namespaces.md) | [09_Namespaces.cs](Examples/09_Namespaces.cs), [09_Namespaces_Billing.cs](Examples/09_Namespaces_Billing.cs) | `dotnet run -- 09` |
| 10 | [Partial classes](concepts/10_Partial_Classes.md) | [10_PartialClasses.cs](Examples/10_PartialClasses.cs), [10_PartialClasses.Generated.cs](Examples/10_PartialClasses.Generated.cs) | `dotnet run -- 10` |

Then do the [Exercises](Exercises.md). Solutions are in [Solutions/](Solutions/).

## Checkpoint

- Write a class with a required init-only property, a private-set property, and a computed property.
- What does a method need so a subclass can override it? (`virtual` or `abstract`)
- When do you pick a `record` over a `class`?
- Why do services depend on `IOrderRepository` instead of `OrderRepository`?
