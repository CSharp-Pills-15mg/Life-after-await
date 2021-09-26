using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace NetFramework.AspNetWebApi.Models
{
    public class Job
    {
        public SynchronizationContext SynchronizationContext1 { get; private set; }

        public SynchronizationContext SynchronizationContext2 { get; private set; }

        public bool IsSameSynchronizationContext => (SynchronizationContext1 == null && SynchronizationContext2 == null) ||
                                                    ReferenceEquals(SynchronizationContext1, SynchronizationContext2);

        public ExecutionContext ExecutionContext1 { get; private set; }

        public ExecutionContext ExecutionContext2 { get; private set; }

        public bool IsSameExecutionContext => ReferenceEquals(ExecutionContext1, ExecutionContext2);

        public int ThreadId1 { get; private set; }

        public int ThreadId2 { get; private set; }

        public bool IsSameThreadId => ThreadId1 == ThreadId2;

        public CultureInfo CultureInfo1 { get; private set; }

        public CultureInfo CultureInfo2 { get; private set; }

        public CultureInfo UICultureInfo1 { get; private set; }

        public CultureInfo UICultureInfo2 { get; private set; }

        public bool IsSameCultureInfo => ReferenceEquals(CultureInfo1, CultureInfo2);

        public HttpContext HttpContext1 { get; private set; }

        public HttpContext HttpContext2 { get; private set; }

        public bool IsSameHttpContext => ReferenceEquals(HttpContext1, HttpContext2);

        public async Task ExecuteAsync()
        {
            SynchronizationContext1 = SynchronizationContext.Current;
            ExecutionContext1 = Thread.CurrentThread.ExecutionContext;
            ThreadId1 = Thread.CurrentThread.ManagedThreadId;
            CultureInfo1 = Thread.CurrentThread.CurrentCulture;
            UICultureInfo1 = Thread.CurrentThread.CurrentUICulture;
            HttpContext1 = HttpContext.Current;

            await Task.Delay(1000).ConfigureAwait(true);

            SynchronizationContext2 = SynchronizationContext.Current;
            ExecutionContext2 = Thread.CurrentThread.ExecutionContext;
            ThreadId2 = Thread.CurrentThread.ManagedThreadId;
            CultureInfo2 = Thread.CurrentThread.CurrentCulture;
            UICultureInfo2 = Thread.CurrentThread.CurrentUICulture;
            HttpContext2 = HttpContext.Current;
        }
    }
}