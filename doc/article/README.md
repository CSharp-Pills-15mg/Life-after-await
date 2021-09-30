# Life after `await`

## What is context?

For different types of applications, context means different things. For example, it may be the same thread, the same `HttpContext`, the same `Dispatcher` or something else.

A `SynchronizationContext` instance is a generic concept that can be used to encapsulate the details of what context means and helps to execute code in that context. Each type of application will provide a custom synchronization context.

## When do we need context?

### WPF Example

Let's take, as example, a WPF application. On a button click, the application makes some time consuming calculations and then it must display the result. The calculations are better to be performed asynchronously, on a different thread, but, when we display the result, we must be back on the UI thread to update the text in the window.

In this situation, context means the same `Dispatcher` instance. The `SynchronizationContext` comes to help here, keeping the original `Dispatcher` inside and using it when the result is obtained from the asynchronous execution. The steps are the followings:

- Preserve the current `SynchronizationContext` instance in a local variable.
- Use a `Task` to execute some code asynchronously.
- Execute the continuation code using the previously preserved `SynchronizationContext` instance which will, in turn, execute the code using the previously captured `Dispatcher` instance.

## The `SynchronizationContext` is an abstraction

You may ask why we didn't use directly the `Dispatcher` instead of using the `SynchronizationContext`. After all, it ends up using, the same `Dispatcher` we could use from the beginning ourselves.

The answer is that we want to implement a generic pattern that works in all kinds of environments where "context" means different things for each of them. We hide the details about what context actually is behind the concept of synchronization context.

In the the above example (the WPF example), the described steps are already implemented by Microsoft when a task is executed. All we have to provide a `SynchronizationContext` instance.

## Code Example

Let's call an asynchronous method. It returns a `Task` so we can await it. By default, the execution catches the `SynchronizationContext`, if any, before executing the task and then the `DoSomethingElse()` method is delegated to be executed by that `SynchronizationContext` that was caught before. Everything is done automatically under the hood.

```csharp
...
await DoSomethigAsync();
DoSomethingElse();
...
```

The action of preserving the synchronization context and restoring it after the asynchronous method is finished adds a little performance penalty. If we know there is no need to run the continuation code in the same context, we have a way to specify this using the `ConfigureAwait()` method:

```csharp
...
await DoSomethigAsync().ConfigureAwait(false);
DoSomethingElse();
...
```

By doing this, we instruct the runtime to not bother catching and restoring the context that results in a faster execution of the code.

## Synchronization Context in different application models

Stephen Cleary has a good article posted on the Microsoft's web page:

- https://docs.microsoft.com/en-us/archive/msdn-magazine/2011/february/msdn-magazine-parallel-computing-it-s-all-about-the-synchronizationcontext
  - (Stephen Cleary | February 2011)

|                     | **Specific Thread Used to Execute Delegates** | **Exclusive (Delegates Execute One at a Time)** | **Ordered (Delegates Execute in Queue Order)** | **Send May Invoke Delegate Directly** | **Post May Invoke Delegate Directly** |
| ------------------- | --------------------------------------------- | ----------------------------------------------- | ---------------------------------------------- | ------------------------------------- | ------------------------------------- |
| **WinForms**        | Yes                                           | Yes                                             | Yes                                            | If called from UI thread              | Never                                 |
| **WPF/Silverlight** | Yes                                           | Yes                                             | Yes                                            | If called from UI thread              | Never                                 |
| **Default**         | No                                            | No                                              | No                                             | Always                                | Never                                 |
| **ASP.NET**         | No                                            | Yes                                             | No                                             | Always                                | Always                                |

(Stephen Cleary | February 2011)

## Synchronization Context Types

|          |            NET Framework             |               NET Core               |
| -------- | :----------------------------------: | :----------------------------------: |
| Console  |                `null`                |                `null`                |
| WinForms | `WindowsFormsSynchronizationContext` | `WindowsFormsSynchronizationContext` |
| WPF      |  `DispatcherSynchronizationContext`  |  `DispatcherSynchronizationContext`  |
| ASP.NET  |    `AspNetSynchronizationContext`    |                `null`                |

> **Note**: There is no Synchronization Context in ASP.NET Core
>
> - https://blog.stephencleary.com/2017/03/aspnetcore-synchronization-context.html#comment-cb00d154-b44b-3ee7-b2b9-d08ccea10531
>   - (Stephen Cleary)

### What does the Synchronization Context preserve?

|                       |      NET Framework       |         NET Core         |
| --------------------- | :----------------------: | :----------------------: |
| Console               |        (nothing)         |        (nothing)         |
| WinForms              |        UI thread         |        UI thread         |
| WPF                   | UI thread and Dispatcher | UI thread and Dispatcher |
| ASP.NET               |      `HttpContext`       |        (nothing)         |
| Default - Thread Pool |        (nothing)         |        (nothing)         |

