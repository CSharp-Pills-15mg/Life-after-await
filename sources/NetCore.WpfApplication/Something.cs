using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace NetCore.WpfApplication
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
            Dispatcher dispatcher1 = Dispatcher.CurrentDispatcher;

            await AsyncJob(millisecondsDelay).ConfigureAwait(false);

            SynchronizationContext synchronizationContext2 = SynchronizationContext.Current;
            ExecutionContext executionContext2 = Thread.CurrentThread.ExecutionContext;
            int id2 = Thread.CurrentThread.ManagedThreadId;
            Dispatcher dispatcher2 = Dispatcher.CurrentDispatcher;

            Result result = new Result
            {
                IsSameSynchronizationContext = (synchronizationContext1 == null && synchronizationContext2 == null) || ReferenceEquals(synchronizationContext1, synchronizationContext2),
                IsSameThreadId = id1 == id2,
                IsSameExecutionContext = ReferenceEquals(executionContext1, executionContext2),
                IsSameDispatcher = dispatcher1 == dispatcher2
            };

            return result;
        }

        private static Task AsyncJob(int millisecondsDelay)
        {
            return Task.Run(() =>
            {
                Stopwatch stopwatch = Stopwatch.StartNew();

                while (stopwatch.ElapsedMilliseconds < millisecondsDelay)
                {
                }
            });
        }
    }
}