using NUnit.Framework;

namespace Bowling.Tests
{
    public class FrameTests
    {
        [Test]
        public void IsStrikeShouldReturnTrue()
        {
            var frame = new Frame("X".ToCharArray());

            Assert.True(frame.IsStrike);
        }

        [TestCase("-/")]
        [TestCase("19")]
        [TestCase("28")]
        [TestCase("37")]
        [TestCase("46")]
        [TestCase("55")]
        [TestCase("64")]
        [TestCase("73")]
        [TestCase("82")]
        [TestCase("91")]
        public void IsStrikeShouldReturnFalse(string frameScores)
        {
            var frame = new Frame(frameScores.ToCharArray());

            Assert.False(frame.IsStrike);
        }

        [TestCase("-/")]
        [TestCase("1/")]
        [TestCase("2/")]
        [TestCase("3/")]
        [TestCase("4/")]
        [TestCase("5/")]
        [TestCase("6/")]
        [TestCase("7/")]
        [TestCase("8/")]
        [TestCase("9/")]
        public void IsSpareShouldReturnTrue(string frameScores)
        {
            var frame = new Frame(frameScores.ToCharArray());

            Assert.True(frame.IsSpare);
        }

        [TestCase("X-")]
        [TestCase("5-")]
        [TestCase("-9")]
        [TestCase("-8")]
        [TestCase("-7")]
        [TestCase("-6")]
        [TestCase("-5")]
        [TestCase("-4")]
        [TestCase("-3")]
        [TestCase("-2")]
        [TestCase("-1")]
        public void IsSpareShouldReturnFalse(string frameScores)
        {
            var frame = new Frame(frameScores.ToCharArray());

            Assert.False(frame.IsSpare);
        }

        [TestCase("--",  0, 0)]
        [TestCase("11",  1, 1)]
        [TestCase("22",  2, 2)]
        [TestCase("33",  3, 3)]
        [TestCase("44",  4, 4)]
        [TestCase("55",  5, 5)]
        [TestCase("66",  6, 6)]
        [TestCase("77",  7, 7)]
        [TestCase("88",  8, 8)]
        [TestCase("99",  9, 9)]
        [TestCase("XX", 10, 10)]
        [TestCase("//", 10, 10)]
        public void ShouldReturnTheCorrectBallValues(string frameScore, int expectedValueOfBallOne, int expectedValueOfBallTwo)
        {
            var frame = new Frame(frameScore.ToCharArray());

            Assert.That(frame.BallOne, Is.EqualTo(expectedValueOfBallOne));
            Assert.That(frame.BallTwo, Is.EqualTo(expectedValueOfBallTwo));
        }
    }
}