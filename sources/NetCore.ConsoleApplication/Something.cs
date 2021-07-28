using System;
using System.Threading;
using System.Threading.Tasks;

namespace NetCore.ConsoleApplication
{
    public static class Something
    {
        private static readonly Random Random = new Random();

        public static async Task<Result> DoSomething(int index)
        {
            int millisecondsDelay = Random.Next(1000);
            Console.WriteLine(index + " - " + millisecondsDelay);

            SynchronizationContext synchronizationContext1 = SynchronizationContext.Current;
            ExecutionContext executionContext1 = Thread.CurrentThread.ExecutionContext;
            int id1 = Thread.CurrentThread.ManagedThreadId;

            await Task.Delay(millisecondsDelay).ConfigureAwait(true);

            SynchronizationContext synchronizationContext2 = SynchronizationContext.Current;
            ExecutionContext executionContext2 = Thread.CurrentThread.ExecutionContext;
            int id2 = Thread.CurrentThread.ManagedThreadId;

            return new Result
            {
                IsSameSynchronizationContext = (synchronizationContext1 == null && synchronizationContext2 == null) || ReferenceEquals(synchronizationContext1, synchronizationContext2),
                IsSameThreadId = id1 == id2,
                IsSameContext = ReferenceEquals(executionContext1, executionContext2)
            };
        }
    }
}