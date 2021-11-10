// C# Pills 15mg
// Copyright (C) 2021 Dust in the Wind
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Linq;

namespace NetCore.ConsoleApplication
{
    internal class ConsoleView
    {
        public void DisplayResults(Job[] jobs)
        {
            foreach (Job job in jobs)
            {
                Console.WriteLine($"Job {job.Id}");
                Console.WriteLine($"    - Execution time: {job.MillisecondsDelay}");

                string synchronizationContext1Text = job.SynchronizationContext1?.ToString() ?? "<null>";
                Console.WriteLine($"    - Synchronization context 1: {synchronizationContext1Text}");

                string synchronizationContext2Text = job.SynchronizationContext2?.ToString() ?? "<null>";
                Console.WriteLine($"    - Synchronization context 2: {synchronizationContext2Text}");

                Console.WriteLine($"    - Is same synchronization context: {job.IsSameSynchronizationContext}");

                Console.WriteLine($"    - Thread id 1: {job.ThreadId1}");
                Console.WriteLine($"    - Thread id 2: {job.ThreadId2}");
                Console.WriteLine($"    - Is same thread id: {job.IsSameThreadId}");

                string executionContext1Text = job.ExecutionContext1?.ToString() ?? "<null>";
                Console.WriteLine($"    - Execution context 1: {executionContext1Text}");

                string executionContext2Text = job.ExecutionContext2?.ToString() ?? "<null>";
                Console.WriteLine($"    - Execution context 2: {executionContext2Text}");

                Console.WriteLine($"    - Is same execution context: {job.IsSameExecutionContext}");
            }

            Console.WriteLine();

            Console.WriteLine("Job Count: " + jobs.Length);
            Console.WriteLine("It is always same synchronization context: " + jobs.All(x => x.IsSameSynchronizationContext));
            Console.WriteLine("It is always null synchronization context: " + jobs.All(x => x.SynchronizationContext1 == null && x.SynchronizationContext2 == null));
            Console.WriteLine("It is always same thread id: " + jobs.All(x => x.IsSameThreadId));
            Console.WriteLine("It is always same execution context: " + jobs.All(x => x.IsSameExecutionContext));
        }
    }
}