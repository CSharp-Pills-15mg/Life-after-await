using System.Globalization;

namespace NetFramework.AspNetWebApi.Models
{
    public class ResultViewModel
    {
        public string SynchronizationContext1 { get; }

        public string SynchronizationContext2 { get; }

        public bool IsSameSynchronizationContext { get; set; }

        public int ThreadId1 { get; }

        public int ThreadId2 { get; }

        public string CurrentCulture1 { get; }

        public string CurrentUICulture1 { get; }

        public string CurrentCulture2 { get; }

        public string CurrentUICulture2 { get; }

        public string HttpContext1 { get; }

        public string HttpContext2 { get; }

        public bool IsSameHttpContext { get; }

        public ResultViewModel(Result result)
        {
            SynchronizationContext1 = result.SynchronizationContext1?.GetType().FullName ?? "<null>";
            SynchronizationContext2 = result.SynchronizationContext2?.GetType().FullName ?? "<null>";
            IsSameSynchronizationContext = ReferenceEquals(result.SynchronizationContext1, result.SynchronizationContext2);
            ThreadId1 = result.ThreadId1;
            ThreadId2 = result.ThreadId2;
            CurrentCulture1 = result.CultureInfo1?.Name ?? "<null>";
            CurrentCulture2 = result.CultureInfo2?.Name ?? "<null>";
            CurrentUICulture1 = result.UICultureInfo1?.Name ?? "<null>";
            CurrentUICulture2 = result.UICultureInfo2?.Name ?? "<null>";
            HttpContext1 = result.HttpContext1?.GetType().FullName ?? "<null>";
            HttpContext2 = result.HttpContext2?.GetType().FullName ?? "<null>";
            IsSameHttpContext = ReferenceEquals(result.HttpContext1, result.HttpContext2);
        }
    }
}