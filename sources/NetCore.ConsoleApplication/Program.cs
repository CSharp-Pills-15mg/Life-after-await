using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NetCore.ConsoleApplication
{
    internal class Program
    {
        private static void Main()
        {
            // Display SynchronizationContext's type

            Type synchronizationContextType = SynchronizationContext.Current?.GetType();
            Console.WriteLine(synchronizationContextType?.FullName ?? "<null>");

            // Run multiple tasks in parallel.

            Task<Result>[] tasks = Enumerable.Range(1, 10000)
                .Select(Something.DoSomething)
                .ToArray();

            Task.WaitAll(tasks);

            List<Result> results = tasks
                .Select(x => x.Result)
                .ToList();

            Console.WriteLine("Count: " + results.Count);
            Console.WriteLine("Is same synchronization context: " + results.All(x => x.IsSameSynchronizationContext));
            Console.WriteLine("Is same thread id: " + results.All(x => x.IsSameThreadId));
            Console.WriteLine("Is same execution context: " + results.All(x => x.IsSameContext));
        }
    }
}