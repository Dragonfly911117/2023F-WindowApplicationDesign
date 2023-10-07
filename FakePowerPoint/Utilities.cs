using System;

namespace FakePowerPoint
{
    public static class Utilities
    {
        // generate a random number between min and max
        private static readonly Random random = new Random();

        public static int RandomNumber(int min, int max)
        {
            return random.Next(min, max);
        }

        // Add more utility methods as needed
    }
}
