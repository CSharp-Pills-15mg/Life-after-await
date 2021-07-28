# Life after await

## What do I want to show?

1) The type of the Synchronization Context in different types of applications:
   - Console (Net Core)
   - WinForms (Net Framework)
   - WPF (Net Core)
   - Web Application (Net Core)
   - Web Application (Net Framework)

|                 |            NET Framework             |              NET Core              |
| --------------- | :----------------------------------: | :--------------------------------: |
| Console         |                `null`                |               `null`               |
| WinForms        | `WindowsFormsSynchronizationContext` |                                    |
| WPF             |  `DispatcherSynchronizationContext`  | `DispatcherSynchronizationContext` |
| Web Application |    `AspNetSynchronizationContext`    |               `null`               |

2) The effect of `ConfigureAwait(false)` in different types of applications:
   - Console (Net Core) - no effect
   - WPF (Net Core) - different `Dispatcher` instance
   - Web Application (Net Framework) - loose `HttpContext`
   - Web Application (Net Core) - no effect

|                 |    NET Framework    |               NET Core               |
| --------------- | :-----------------: | :----------------------------------: |
| Console         |     (no effect)     |             (no effect)              |
| WinForms        |          ?          |                                      |
| WPF             |          ?          | different `Dispatcher` - still works |
| Web Application | loose `HttpContext` |             (no effect)              |

## Preparation Recipe

(redo)

- Create a C# Console Application.
- Create an `async` method, and `await` inside it another `async` method.
- Before the call, write into the console the id of the current thread.
- After the call, write into the console the id of the current thread.
- Build in release mode and run the application from outside Visual Studio.
- Repeat the test using `ConfigureAwait` when awaiting the second method.



- asp.net core app
- change current culture
- call an async operation with `ConfigureAwait(true)`
- check the current culture and `HttpContext.Current`
- call an async operation with `ConfigureAwait(false)`
- check the current culture and `HttpContext.Current` again.

