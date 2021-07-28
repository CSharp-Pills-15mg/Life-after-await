Todo 1:

- 

## Synchronization Context in different application models

|                     | **Specific Thread Used to Execute Delegates** | **Exclusive (Delegates Execute One at a Time)** | **Ordered (Delegates Execute in Queue Order)** | **Send May Invoke Delegate Directly** | **Post May Invoke Delegate Directly** |
| ------------------- | --------------------------------------------- | ----------------------------------------------- | ---------------------------------------------- | ------------------------------------- | ------------------------------------- |
| **Windows Forms**   | Yes                                           | Yes                                             | Yes                                            | If called from UI thread              | Never                                 |
| **WPF/Silverlight** | Yes                                           | Yes                                             | Yes                                            | If called from UI thread              | Never                                 |
| **Default**         | No                                            | No                                              | No                                             | Always                                | Never                                 |
| **ASP.NET**         | No                                            | Yes                                             | No                                             | Always                                | Always                                |

(Stephen Cleary | February 2011)

### What does the Synchronization Context preserve?

WinForms context (`WindowsFormsSynchronizationContext`):

- the UI thread

WPF context (`DispatcherSynchronizationContext`):

- the UI thread
- the Dispatcher

Default - Thread Pool (`SynchronizationContext`):

- nothing

ASP.NET context (`AspNetSynchronizationContext`):

- the `HttpContext.Current`
- NOT the same thread.

ASP.NET Core context:

-  There is none.

## Documentation

- What is Synchronization Context?
  - https://docs.microsoft.com/en-us/archive/msdn-magazine/2011/february/msdn-magazine-parallel-computing-it-s-all-about-the-synchronizationcontext
    - (Stephen Cleary | February 2011)
- There is no Synchronization Context in ASP.NET Core
  - https://blog.stephencleary.com/2017/03/aspnetcore-synchronization-context.html#comment-cb00d154-b44b-3ee7-b2b9-d08ccea10531
    - (Stephen Cleary)