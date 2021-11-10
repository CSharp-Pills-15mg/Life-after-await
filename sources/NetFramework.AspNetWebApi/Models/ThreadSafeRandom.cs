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

namespace NetFramework.AspNetWebApi.Models
{
    public class ThreadSafeRandom
    {
        private static readonly Random RandomSeeds = new Random();

        [ThreadStatic]
        private static Random random;

        public int Next()
        {
            if (random == null)
                random = CreateNewRandom();

            return random.Next();
        }

        public int Next(int maxValue)
        {
            if (random == null)
                random = CreateNewRandom();

            return random.Next(maxValue);
        }

        public int Next(int minValue, int maxValue)
        {
            if (random == null)
                random = CreateNewRandom();

            return random.Next(minValue, maxValue);
        }

        private static Random CreateNewRandom()
        {
            int seed;

            lock (RandomSeeds)
            {
                seed = RandomSeeds.Next();
            }

            return new Random(seed);
        }
    }
}