# Life after await

## Pill Category

Frameworks (.NET)

## Description

Let's have a call to an asynchronous method that we await. To do so, our main method must be asynchronous as well:

```csharp
private async Task DoSomething()
{
    // Before await
    
    await CallAnAsynchronousMethod();
    
    // After await
}
```

## Question

- What happens with the execution when it returns from an awaited call? Is the code after the `await` executed on the same thread as the code before the `await`?