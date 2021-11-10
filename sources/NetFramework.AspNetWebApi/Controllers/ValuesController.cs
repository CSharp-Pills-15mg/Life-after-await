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

using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using NetFramework.AspNetWebApi.Models;

namespace NetFramework.AspNetWebApi.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public async Task<ResultViewModel> Get()
        {
            Result result = new Result();

            // Before async
            result.SynchronizationContext1 = SynchronizationContext.Current;
            result.ExecutionContext1 = Thread.CurrentThread.ExecutionContext;
            result.ThreadId1 = Thread.CurrentThread.ManagedThreadId;
            result.CultureInfo1 = Thread.CurrentThread.CurrentCulture;
            result.UICultureInfo1 = Thread.CurrentThread.CurrentUICulture;
            result.HttpContext1 = HttpContext.Current;

            // In order to execute correctly we need to restore the context after the await.
            // - Do not even call ConfigureAwait(...) method. The await keyword will restore the context by default.
            // - Or call ConfigureAwait(true) to explicitly ask to restore the context.
            await Task.Delay(1000).ConfigureAwait(true);

            // After async
            result.SynchronizationContext2 = SynchronizationContext.Current;
            result.ExecutionContext2 = Thread.CurrentThread.ExecutionContext;
            result.ThreadId2 = Thread.CurrentThread.ManagedThreadId;
            result.CultureInfo2 = Thread.CurrentThread.CurrentCulture;
            result.UICultureInfo2 = Thread.CurrentThread.CurrentUICulture;
            result.HttpContext2 = HttpContext.Current;

            return new ResultViewModel(result);
        }
    }
}