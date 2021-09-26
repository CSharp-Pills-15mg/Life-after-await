using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NetCore.AspNetCoreRazorPages.Pages
{
    public class IndexModel : PageModel
    {
        public string SerializedResult { get; private set; }

        public async Task OnGet()
        {
            Result result = new Result();

            // Before async
            result.SynchronizationContext1 = SynchronizationContext.Current;
            result.ExecutionContext1 = Thread.CurrentThread.ExecutionContext;
            result.ThreadId1 = Thread.CurrentThread.ManagedThreadId;
            result.CultureInfo1 = Thread.CurrentThread.CurrentCulture;
            result.UICultureInfo1 = Thread.CurrentThread.CurrentUICulture;
            result.HttpContext1 = HttpContext;

            // In ASP.NET Core there is no synchronization context. That means there is nothing to be restored.
            // Even though, from a functional point of view, it doesn't matter if "ConfigureAwait(...)" is called and
            // it doesn't matter if it is called with "true" or "false", a call to "ConfigureAwait(false)" will
            // slightly improve the performance. By doing so, the "await" will not even try to capture and restore
            // the nonexistent context.
            await Task.Delay(1000).ConfigureAwait(false);

            // After async
            result.SynchronizationContext2 = SynchronizationContext.Current;
            result.ExecutionContext2 = Thread.CurrentThread.ExecutionContext;
            result.ThreadId2 = Thread.CurrentThread.ManagedThreadId;
            result.CultureInfo2 = Thread.CurrentThread.CurrentCulture;
            result.UICultureInfo2 = Thread.CurrentThread.CurrentUICulture;
            result.HttpContext2 = HttpContext;

            SerializedResult = SerializeResult(result);
        }

        private static string SerializeResult(Result result)
        {
            JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            ResultViewModel resultViewModel = new ResultViewModel(result);
            return JsonSerializer.Serialize(resultViewModel, jsonSerializerOptions);
        }
    }
}