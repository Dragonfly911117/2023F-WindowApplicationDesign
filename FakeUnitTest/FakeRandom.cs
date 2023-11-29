using System;
using System.Collections.Generic;

namespace FakeUnitTest
{

    public class FakeRandom : Random
    {
        public static List<int> RandomNumbers = new List<int>();
        private static int _index = 0;

        public FakeRandom()
        {
            RandomNumbers.Add(0);
        }

        public void SetRandomNumbers(List<int> randomNumbers)
        {
            RandomNumbers = randomNumbers;
        }

        public void Reset(int index = 0)
        {
            _index = index;
        }

        public override int Next(int minValue, int maxValue)
        {
            if (_index >= RandomNumbers.Count - 1)
                _index = 0;
            return RandomNumbers[_index++];
        }
    }
}
