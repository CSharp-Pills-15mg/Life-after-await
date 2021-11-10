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

namespace NetCore.AspNetCoreRazorPages
{
    public class ResultViewModel
    {
        public string SynchronizationContext1 { get; }

        public string SynchronizationContext2 { get; }

        public int ThreadId1 { get; }

        public int ThreadId2 { get; }

        public string CurrentCulture1 { get; }

        public string CurrentUICulture1 { get;  }

        public string CurrentCulture2 { get; }

        public string CurrentUICulture2 { get;  }

        public string HttpContext1 { get; }

        public string HttpContext2 { get; }

        public bool IsSameHttpContext { get; }

        public ResultViewModel(Result result)
        {
            SynchronizationContext1 = result.SynchronizationContext1?.GetType().FullName;
            SynchronizationContext2 = result.SynchronizationContext2?.GetType().FullName;
            ThreadId1 = result.ThreadId1;
            ThreadId2 = result.ThreadId2;
            CurrentCulture1 = result.CultureInfo1?.Name;
            CurrentCulture2 = result.CultureInfo2?.Name;
            CurrentUICulture1 = result.UICultureInfo1?.Name;
            CurrentUICulture2 = result.UICultureInfo2?.Name;
            HttpContext1 = result.HttpContext1?.GetType().FullName;
            HttpContext2 = result.HttpContext2?.GetType().FullName;
            IsSameHttpContext = result.HttpContext1 == result.HttpContext2;
        }
    }
}