# Life after `await`

## Pill Category

Frameworks (.NET)

## Description

Let's consider, for example, a call to an asynchronous method that we await. To do so, our caller method must also be asynchronous:

```csharp
private async Task DoSomething()
{
    // Before await
    
    await CallAsynchronousMethod();
    
    // After await
}
```

### Question

- What happens with the execution when it returns from an awaited call? Is the code after the `await` executed by the same thread? Do we have a way to control this behaviour?

