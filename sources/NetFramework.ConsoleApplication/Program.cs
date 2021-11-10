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
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetFramework.ConsoleApplication
{
    internal class Program
    {
        private static void Main()
        {
            Job[] jobs = CreateJobs();
            RunAllJobs(jobs);

            ConsoleView consoleView = new ConsoleView();
            consoleView.DisplayResults(jobs);

            Pause();
        }

        private static Job[] CreateJobs()
        {
            Random random = new Random();

            return Enumerable.Range(1, 10000)
                .Select(x =>
                {
                    int millisecondsDelay = random.Next(1000);
                    return new Job(x, millisecondsDelay);
                })
                .ToArray();
        }

        private static void RunAllJobs(IEnumerable<Job> jobs)
        {
            Task[] tasks = jobs
                .Select(x => x.ExecuteAsync())
                .ToArray();

            Task.WaitAll(tasks);
        }

        private static void Pause()
        {
            Console.WriteLine();
            Console.Write("Press any key to continue...");
            Console.ReadKey(true);
            Console.WriteLine();
        }
    }
}