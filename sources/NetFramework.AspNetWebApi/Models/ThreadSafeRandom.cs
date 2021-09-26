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