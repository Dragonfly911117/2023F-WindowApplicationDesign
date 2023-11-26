using System;
using System.Collections.Generic;

namespace FakeUnitTest;

public class FakeRandom : Random
{
    private static List<int> _randomNumbers = new List<int>();
    private static int _index = 0;

    public FakeRandom()
    {
        _randomNumbers.Add(0);
    }

    public void SetRandomNumbers(List<int> randomNumbers)
    {
        _randomNumbers = randomNumbers;
    }

    public void Reset()
    {
        _index = 0;
    }

    public override int Next(int minValue, int maxValue)
    {
        if (_index >= _randomNumbers.Count - 1)
            _index = 0;
        return _randomNumbers[_index++];
    }
}
