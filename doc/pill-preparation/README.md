# Life after `await`

## Preparation Recipe

- Create an ASP.NET Web Application (Web API) with .NET Framework 4.8.
- Create an asynchronous GET endpoint in the `ValuesController`.
- First run:
  - Call an asynchronous method: `Task.Delay(1000)`;
  - Before the asynchronous call, store, in a variable, the current `HttpContext`.
  - After the asynchronous call, store, in another variable, the current `HttpContext`.
  - Return, as response, the two instances of the `HttpContext`.
  - Run the application and check the results.

```csharp
public async Task<Result> Get()
{
    HttpContext httpContext1 = HttpContext.Current;
    await Task.Delay(1000);
    HttpContext httpContext2 = HttpContext.Current;

    return new ResultViewModel
    {
        HttpContext1 = httpContext1?.GetType().FullName,
        HttpContext2 = httpContext2?.GetType().FullName
    };
}
```

- Second run - with `ConfigureAwait(false)`
  - Add `ConfigureAwait(false)` to the asynchronous call.
  - Run the application again.

```csharp
public async Task<Result> Get()
{
    // ...

    await Task.Delay(1000).ConfigureAwait(false);

    // ...
}
```

- Third run - with `ConfigureAwait(true)`
  - Add `ConfigureAwait(true)` to the asynchronous call.
  - Run the application again.

```csharp
public async Task<Result> Get()
{
    // ...

    await Task.Delay(1000).ConfigureAwait(true);

    // ...
}
```

- Talk about the `SynchronizationContext` and show the table with different types of synchronization contexts for each type of application.

