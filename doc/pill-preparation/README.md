# Life after await

## What do I want to show?

### The type of the Synchronization Context in different types of applications:

- Console (Net Core) - `null`
- WinForms (Net Framework) - `WindowsFormsSynchronizationContext`
- WPF (Net Core) - `DispatcherSynchronizationContext`
- ASP.NET (Net Framework) - `AspNetSynchronizationContext`
- ASP.NET (Net Core) - `null`

### If context is NOT preserved `ConfigureAwait(false)`:

- Console (Net Core) - no effect
- WPF (Net Core) - different `Dispatcher` instance
- Web Application (Net Framework) - loose `HttpContext`
- Web Application (Net Core) - no effect

## Preparation Recipe (must redo)

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

