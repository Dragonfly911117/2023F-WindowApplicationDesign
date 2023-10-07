using System;

namespace FakePowerPoint
{
    public static class Utilities
    {
        // generate a random number between min and max
        public static int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        // Add more utility methods as needed
    }
}
