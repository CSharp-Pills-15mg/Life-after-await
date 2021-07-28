using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace WebApplication2.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public async Task<ValuesViewModel> Get()
        {
            // Set culture

            Thread.CurrentThread.CurrentCulture = new CultureInfo("ro-RO");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("ro-RO");

            // Display SynchronizationContext's type

            Type synchronizationContextType = SynchronizationContext.Current?.GetType();
            string synchronizationContextTypeText = synchronizationContextType?.FullName ?? " < null>";

            int threadId1 = Thread.CurrentThread.ManagedThreadId;
            CultureInfo cultureInfo1 = Thread.CurrentThread.CurrentCulture;
            HttpContext httpContext1 = HttpContext.Current;

            await Task.Delay(1000).ConfigureAwait(false);

            int threadId2 = Thread.CurrentThread.ManagedThreadId;
            CultureInfo cultureInfo2 = Thread.CurrentThread.CurrentCulture;
            HttpContext httpContext2 = HttpContext.Current;

            return new ValuesViewModel
            {
                SynchronizationContextType = synchronizationContextTypeText,
                ThreadId1 = threadId1,
                ThreadId2 = threadId2,
                CurrentCulture1 = cultureInfo1.Name,
                CurrentCulture2 = cultureInfo2.Name,
                HttpContextExists1 = httpContext1 != null,
                HttpContextExists2 = httpContext2 != null,
                IsSameHttpContext = httpContext1 == httpContext2
            };
        }

        // GET api/values/5
        public string Get(int id)
        {
            int threadId1 = Thread.CurrentThread.ManagedThreadId;
            CultureInfo cultureInfo1 = Thread.CurrentThread.CurrentCulture;

            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}