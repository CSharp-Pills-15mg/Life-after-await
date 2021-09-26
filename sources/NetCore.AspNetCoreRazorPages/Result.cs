using System.Globalization;
using System.Threading;
using Microsoft.AspNetCore.Http;

namespace NetCore.AspNetCoreRazorPages
{
    public class Result
    {
        public SynchronizationContext SynchronizationContext1 { get; set; }

        public SynchronizationContext SynchronizationContext2 { get; set; }

        public bool IsSameSynchronizationContext => (SynchronizationContext1 == null && SynchronizationContext2 == null) ||
                                                    ReferenceEquals(SynchronizationContext1, SynchronizationContext2);

        public ExecutionContext ExecutionContext1 { get; set; }

        public ExecutionContext ExecutionContext2 { get; set; }

        public bool IsSameExecutionContext => ReferenceEquals(ExecutionContext1, ExecutionContext2);

        public int ThreadId1 { get; set; }

        public int ThreadId2 { get; set; }

        public bool IsSameThreadId => ThreadId1 == ThreadId2;

        public CultureInfo CultureInfo1 { get; set; }

        public CultureInfo CultureInfo2 { get; set; }

        public CultureInfo UICultureInfo1 { get; set; }

        public CultureInfo UICultureInfo2 { get; set; }

        public bool IsSameCultureInfo => ReferenceEquals(CultureInfo1, CultureInfo2);

        public HttpContext HttpContext1 { get; set; }

        public HttpContext HttpContext2 { get; set; }

        public bool IsSameHttpContext => ReferenceEquals(HttpContext1, HttpContext2);
    }
}