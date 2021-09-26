using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace NetFramework.WpfApplication
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

        public Dispatcher Dispatcher1 { get; set; }
        
        public Dispatcher Dispatcher2 { get; set; }

        public bool IsSameDispatcher => Dispatcher1 == Dispatcher2;
    }
}