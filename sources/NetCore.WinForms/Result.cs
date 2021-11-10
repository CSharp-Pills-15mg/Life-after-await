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

namespace NetCore.WinForms
{
    public class Result
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