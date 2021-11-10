// C# Pills 15mg
// Copyright (C) 2021 Dust in the Wind
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

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