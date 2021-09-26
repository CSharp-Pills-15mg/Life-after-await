using System.Threading;
using System.Threading.Tasks;

namespace NetCore.WinForms
{
    public class Job
    {
        private volatile SynchronizationContext synchronizationContext1;
        private volatile SynchronizationContext synchronizationContext2;

        public SynchronizationContext SynchronizationContext1
        {
            get => synchronizationContext1;
            set => synchronizationContext1 = value;
        }

        public SynchronizationContext SynchronizationContext2
        {
            get => synchronizationContext2;
            set => synchronizationContext2 = value;
        }

        public bool IsSameSynchronizationContext => (SynchronizationContext1 == null && SynchronizationContext2 == null) ||
                                                    ReferenceEquals(SynchronizationContext1, SynchronizationContext2);

        public ExecutionContext ExecutionContext1 { get; set; }

        public ExecutionContext ExecutionContext2 { get; set; }

        public bool IsSameExecutionContext => ReferenceEquals(ExecutionContext1, ExecutionContext2);

        public int ThreadId1 { get; set; }

        public int ThreadId2 { get; set; }

        public bool IsSameThreadId => ThreadId1 == ThreadId2;
    }
}