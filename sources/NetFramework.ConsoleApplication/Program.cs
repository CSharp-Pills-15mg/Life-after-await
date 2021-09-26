﻿using System;
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