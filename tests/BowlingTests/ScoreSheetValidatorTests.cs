using NUnit.Framework;

namespace Bowling.Tests
{
    public class ScoreSheetValidatorTests
    {
        [TestCase("XXXXXXXXXXXX")]
        [TestCase("X|X|X|X|X|X|X|X|X|X|X|X|X|X|X|X|X|")]
        public void ShouldFailValidation(string scoreSheet)
        {
            var validator = new ScoreSheetValidator();

            Assert.False(validator.Validate(scoreSheet));
        }
    }
}