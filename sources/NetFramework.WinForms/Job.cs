using System.Threading;
using System.Threading.Tasks;

namespace NetFramework.WinForms
{
    public class Job
    {
        private volatile SynchronizationContext synchronizationContext1;
        private volatile SynchronizationContext synchronizationContext2;

        public int Id { get; }

        public int MillisecondsDelay { get; }

        public SynchronizationContext SynchronizationContext1
        {
            get => synchronizationContext1;
            private set => synchronizationContext1 = value;
        }

        public SynchronizationContext SynchronizationContext2
        {
            get => synchronizationContext2;
            private set => synchronizationContext2 = value;
        }

        public bool IsSameSynchronizationContext => (SynchronizationContext1 == null && SynchronizationContext2 == null) ||
                                                    ReferenceEquals(SynchronizationContext1, SynchronizationContext2);

        public ExecutionContext ExecutionContext1 { get; private set; }

        public ExecutionContext ExecutionContext2 { get; private set; }

        public bool IsSameExecutionContext => ReferenceEquals(ExecutionContext1, ExecutionContext2);

        public int ThreadId1 { get; private set; }

        public int ThreadId2 { get; private set; }

        public bool IsSameThreadId => ThreadId1 == ThreadId2;

        public Job(int id, int millisecondsDelay)
        {
            Id = id;
            MillisecondsDelay = millisecondsDelay;
        }

        public async Task ExecuteAsync()
        {
            synchronizationContext1 = SynchronizationContext.Current;
            ExecutionContext1 = Thread.CurrentThread.ExecutionContext;
            ThreadId1 = Thread.CurrentThread.ManagedThreadId;

            await Task.Delay(MillisecondsDelay).ConfigureAwait(true);

            synchronizationContext2 = SynchronizationContext.Current;
            ExecutionContext2 = Thread.CurrentThread.ExecutionContext;
            ThreadId2 = Thread.CurrentThread.ManagedThreadId;
        }
    }
}