# 07. Interfaces

**In one line:** a named contract of members a class promises to implement. JS has nothing like it at runtime (TypeScript interfaces are erased).

```csharp
public interface INotifier
{
    string Channel { get; }
    void Send(string to, string message);
}

public class EmailNotifier : INotifier, IDisposable   // one base class max, many interfaces
{
    public string Channel => "email";
    public void Send(string to, string message) { /* ... */ }
    public void Dispose() { }
}
```

## Why they matter so much in C#

```csharp
public class AlertService(INotifier notifier)      // depends on the contract
{
    public void Alert(string user) => notifier.Send(user, "Hi");
}
```

- **Dependency injection** (Ep10) registers "for `INotifier`, give `EmailNotifier`".
- **Tests** pass a fake `INotifier`.
- Most services in a real code base come in pairs: `IOrderService` + `OrderService`.

## TypeScript comparison

TS interfaces are structural ("has the right shape"). C# interfaces are **nominal**: a class must say `: INotifier` explicitly.

## Key points

- Names start with `I`: `IRepository`, `IDisposable`, `IEnumerable<T>`.
- Interfaces can have default method implementations (C# 8), but you will rarely see it.

## Gotchas

- An interface cannot hold fields or constructor logic.

Run it: `dotnet run -- 07`
