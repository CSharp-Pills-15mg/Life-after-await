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

using System.Threading;
using System.Threading.Tasks;

namespace NetFramework.ConsoleApplication
{
    public class Job
    {
        public int Id { get; }

        public int MillisecondsDelay { get; }

        public SynchronizationContext SynchronizationContext1 { get; private set; }

        public SynchronizationContext SynchronizationContext2 { get; private set; }

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
            SynchronizationContext1 = SynchronizationContext.Current;
            ExecutionContext1 = Thread.CurrentThread.ExecutionContext;
            ThreadId1 = Thread.CurrentThread.ManagedThreadId;

            await Task.Delay(MillisecondsDelay).ConfigureAwait(true);

            SynchronizationContext2 = SynchronizationContext.Current;
            ExecutionContext2 = Thread.CurrentThread.ExecutionContext;
            ThreadId2 = Thread.CurrentThread.ManagedThreadId;
        }
    }
}