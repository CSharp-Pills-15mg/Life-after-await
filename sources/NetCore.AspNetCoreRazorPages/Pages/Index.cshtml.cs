using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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

            // In order to execute correctly we need to restore the context after the await.
            // - Do not call ConfigureAwait(...) method. By default the await keyword will restore the context.
            // - Or call ConfigureAwait(true) to explicitly ask to restore the context.
            await Task.Delay(1000).ConfigureAwait(false);

            // After async
            result.SynchronizationContext2 = SynchronizationContext.Current;
            result.ExecutionContext2 = Thread.CurrentThread.ExecutionContext;
            result.ThreadId2 = Thread.CurrentThread.ManagedThreadId;
            result.CultureInfo2 = Thread.CurrentThread.CurrentCulture;
            result.UICultureInfo2 = Thread.CurrentThread.CurrentUICulture;
            result.HttpContext2 = HttpContext;

            ResultViewModel resultViewModel = new ResultViewModel(result);
            SerializedResult = JsonSerializer.Serialize(resultViewModel, new JsonSerializerOptions
            {
                WriteIndented = true
            });
        }
    }
}
