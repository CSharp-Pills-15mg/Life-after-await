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
using System.Windows.Threading;

namespace NetCore.WpfApplication
{
    public struct Result
    {
        public SynchronizationContext SynchronizationContext1 { get; set; }

        public SynchronizationContext SynchronizationContext2 { get; set; }

        public bool IsSameSynchronizationContext => (SynchronizationContext1 == null && SynchronizationContext2 == null) ||
                                                    ReferenceEquals(SynchronizationContext1, SynchronizationContext2);

        public ExecutionContext ExecutionContext1 { get; set; }

        public ExecutionContext ExecutionContext2 { get; set; }

        public bool IsSameExecutionContext => ReferenceEquals(ExecutionContext1, ExecutionContext2);

        public int ThreadId1 { get; set; }

        public int ThreadId2 { get; set; }

        public bool IsSameThreadId => ThreadId1 == ThreadId2;

        public Dispatcher Dispatcher1 { get; set; }

        public Dispatcher Dispatcher2 { get; set; }

        public bool IsSameDispatcher => Dispatcher1 == Dispatcher2;
    }
}