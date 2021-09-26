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
            // - Do not call ConfigureAwait(...) method. By default the await keyword will restore the context.
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