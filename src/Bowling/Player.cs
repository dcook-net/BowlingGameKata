namespace Bowling
{
    public class Player
    {
        private readonly Line _resultsLine;

        public Player(string name, string scoreSheet)
        {
            Name = name;
            _resultsLine = new Line(scoreSheet);
        }

        public string Name { get; }

        public int Score() => _resultsLine.Total;
    }
}