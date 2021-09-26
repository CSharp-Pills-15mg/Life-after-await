using System.Globalization;

namespace NetFramework.AspNetWebApi.Models
{
    public class JobViewModel
    {
        public string SynchronizationContext1 { get; }

        public string SynchronizationContext2 { get; }

        public int ThreadId1 { get; }

        public int ThreadId2 { get; }

        public string CurrentCulture1 { get; }

        public string CurrentCulture2 { get; }

        public string CurrentUICulture1 { get;  }

        public string CurrentUICulture2 { get;  }

        public string HttpContext1 { get; }

        public string HttpContext2 { get; }

        public bool IsSameHttpContext { get; }

        public JobViewModel(Job job)
        {
            SynchronizationContext1 = job.SynchronizationContext1?.GetType().FullName ?? "<null>";
            SynchronizationContext2 = job.SynchronizationContext2?.GetType().FullName ?? "<null>";
            ThreadId1 = job.ThreadId1;
            ThreadId2 = job.ThreadId2;
            CurrentCulture1 = job.CultureInfo1?.Name ?? "<null>";
            CurrentCulture2 = job.CultureInfo2?.Name ?? "<null>";
            CurrentUICulture1 = job.UICultureInfo1?.Name ?? "<null>";
            CurrentUICulture2 = job.UICultureInfo2?.Name ?? "<null>";
            HttpContext1 = job.HttpContext1?.GetType().FullName ?? "<null>";
            HttpContext2 = job.HttpContext2?.GetType().FullName ?? "<null>";
            IsSameHttpContext = job.HttpContext1 == job.HttpContext2;
        }
    }
}