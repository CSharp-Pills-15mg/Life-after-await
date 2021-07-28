using System;
using System.Threading;

namespace ConsoleApplication.NetFramework
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Display SynchronizationContext's type

            Type synchronizationContextType = SynchronizationContext.Current?.GetType();
            Console.WriteLine(synchronizationContextType?.FullName ?? "<null>");

        }
    }
}