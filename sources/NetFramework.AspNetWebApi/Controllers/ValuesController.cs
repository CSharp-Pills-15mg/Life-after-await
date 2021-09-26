using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using NetFramework.AspNetWebApi.Models;

namespace NetFramework.AspNetWebApi.Controllers
{
    public class ValuesController : ApiController
    {
        private CultureInfo currentCulture1;
        private CultureInfo currentUICulture1;

        private CultureInfo currentCulture2;
        private CultureInfo currentUICulture2;

        //// GET api/values
        //public async Task<JobViewModel> Get()
        //{
        //    // Set culture

        //    Thread.CurrentThread.CurrentCulture = new CultureInfo("ro-RO");
        //    Thread.CurrentThread.CurrentUICulture = new CultureInfo("ro-RO");

        //    Job job = new Job();
        //    await job.ExecuteAsync();

        //    return new JobViewModel(job);
        //}

        public ThreadInfoViewModel Get()
        {
            // Set culture

            Thread.CurrentThread.CurrentCulture = new CultureInfo("ro-RO");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("ro-RO");

            Thread thread = new Thread(RunThread);
            thread.IsBackground = false;

            currentCulture1 = Thread.CurrentThread.CurrentCulture;
            currentUICulture1 = Thread.CurrentThread.CurrentUICulture;

            thread.Start();
            thread.Join();

            return new ThreadInfoViewModel
            {
                CurrentCulture1 = currentCulture1?.Name ?? "<null>",
                CurrentCulture2 = currentCulture2?.Name ?? "<null>",
                CurrentUICulture1 = currentUICulture1?.Name ?? "<null>",
                CurrentUICulture2 = currentUICulture2?.Name ?? "<null>",
            };
        }

        private void RunThread()
        {
            currentCulture2 = Thread.CurrentThread.CurrentCulture;
            currentUICulture2 = Thread.CurrentThread.CurrentUICulture;
        }
    }

    public class ThreadInfoViewModel
    {
        public string CurrentCulture1 { get; set; }
        
        public string CurrentCulture2 { get; set; }
        
        public string CurrentUICulture1 { get; set; }
        
        public string CurrentUICulture2 { get; set; }
    }
}