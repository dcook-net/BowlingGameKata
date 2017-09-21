using System;
using Bowling.Exceptions;
using NUnit.Framework;

namespace Bowling.Tests
{
    public class LineTests
    {
        [Test]
        public void LineShouldContain2BonusBalls()
        {
            var scoreSheet = "X|X|X|X|X|X|X|X|X|X||X5";

            var line = new Line(scoreSheet);

            Assert.That(line.BonusBall1, Is.EqualTo(10));
            Assert.That(line.BonusBall2, Is.EqualTo(5));
        }

        [Test]
        public void LineShouldContain1BonusBall()
        {
            var scoreSheet = "X|X|X|X|X|X|X|X|X|X||5";

            var line = new Line(scoreSheet);

            Assert.That(line.BonusBall1, Is.EqualTo(5));
            Assert.That(line.BonusBall2, Is.EqualTo(0));
        }

        [Test]
        public void ShouldCalculateZeroScore()
        {
            var scores = "--|--|--|--|--|--|--|--|--|--";

            var line = new Line(scores);

            var calculatedScore = line.Total;

            Assert.That(calculatedScore, Is.EqualTo(0));
        }

        [Test]
        public void ShouldCorrectlyCalculateMaximumScore()
        {
            var scores = "X|X|X|X|X|X|X|X|X|X||XX";

            var line = new Line(scores);

            var calculatedScore = line.Total;

            Assert.That(calculatedScore, Is.EqualTo(300));
        }

        [TestCase("X|X|X|X|X|X|X|X|X|X||X-", 290)]
        [TestCase("X|X|X|X|X|X|X|X|X|X||-", 270)]
        [TestCase("X|X|X|X|X|X|X|X|X|X||--", 270)]
        [TestCase("X|X|X|X|X|X|X|X|X|X||X9", 299)]
        [TestCase("X|X|X|X|X|X|X|X|X|X||X1", 291)]
        [TestCase("X|X|X|X|X|X|X|X|X|X||-/", 280)]
        [TestCase("-/|-/|-/|-/|-/|-/|-/|-/|-/|-/||/", 110)]
        public void ShouldCalculateCorrectScoreForBonusBallsScenarios(string playerScoreSheet, int expectedScore)
        {
            var line = new Line(playerScoreSheet);

            var calculatedScore = line.Total;

            Assert.That(calculatedScore, Is.EqualTo(expectedScore));
        }

        [TestCase("-1|-1|-1|-1|-1|-1|-1|-1|-1|-1||", 10)]
        [TestCase("9-|8-|7-|63|12|23|34|45|54|21||", 69)]
        [TestCase("44|33|22|63|12|23|34|45|54|21||", 63)]
        [TestCase("X|33|22|63|12|23|34|45|54|21||", 71)]
        [TestCase("8/|33|22|63|12|23|34|45|54|21||", 68)]
        public void ShouldCalculateCorrectScoreWithoutBonusBalls(string playerScoreSheet, int expectedScore)
        {
            var line = new Line(playerScoreSheet);

            var calculatedScore = line.Total;

            Assert.That(calculatedScore, Is.EqualTo(expectedScore));
        }

        [Test]
        public void ShouldThrowExceptionWhenScoreSheetIsInvalid()
        {
            Action constructor = () => new Line("X");

            Assert.Throws<InvalidScoreSheetException>(constructor.Invoke);
        }
    }
}