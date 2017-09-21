using System.Collections.Generic;

namespace Bowling
{
    public class Frame
    {
        private readonly char _ballOne;
        private readonly char _ballTwo;

        public Frame(IReadOnlyList<char> balls)
        {
            _ballOne = balls[0];
            _ballTwo = balls.Count > 1 ? balls[1] : Constants.MISSINDICATOR;
        }

        public int BallOne => NumericValue(_ballOne);

        public int BallTwo => NumericValue(_ballTwo);

        private int NumericValue(char? ballValue)
        {
            if (ballValue == null) return 0;
            if (ballValue == Constants.STRIKEINDICATOR || ballValue == Constants.SPAREINDICATOR) return 10;

            return ballValue == Constants.MISSINDICATOR ? 0 : int.Parse(ballValue.ToString());
        }

        public bool IsStrike => _ballOne == Constants.STRIKEINDICATOR;
        public bool IsSpare => _ballTwo == Constants.SPAREINDICATOR;
    }
}