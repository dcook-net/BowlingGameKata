using NUnit.Framework;

namespace Bowling.Tests
{
    public class PlayerTests
    {
        [Test]
        public void PlayerScoreShouldReturnScoreSheetTotal()
        {
            var player = new Player("Dave", "X|X|X|X|X|X|X|X|X|X||XX");

            Assert.That(player.Name, Is.EqualTo("Dave"));
            Assert.That(player.Score, Is.EqualTo(300));
        }
    }
}