using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace NetCore.AspNetCoreRazorPages.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public string SynchronizationContextType { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public async Task OnGet()
        {
            // Display SynchronizationContext's type

            Type synchronizationContextType = SynchronizationContext.Current?.GetType();
            SynchronizationContextType = synchronizationContextType?.FullName ?? "<null>";

            Thread.CurrentThread.CurrentCulture = new CultureInfo("ro-RO");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("ro-RO");

            CultureInfo cultureInfo1 = Thread.CurrentThread.CurrentCulture;

            List<Task> tasks = Enumerable.Range(1, 100)
                .Select(x => Task.Delay(1000))
                .ToList();

            foreach (Task task in tasks)
            {
                await task.ConfigureAwait(false);

                CultureInfo cultureInfo2 = Thread.CurrentThread.CurrentCulture;

                if (cultureInfo1.Name != cultureInfo2.Name)
                {
                }

            }

            //await Task.Delay(1000).ConfigureAwait(false);

            CultureInfo cultureInfo3 = Thread.CurrentThread.CurrentCulture;
        }
    }
}
