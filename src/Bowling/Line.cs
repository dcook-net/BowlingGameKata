using System.Runtime.CompilerServices;
using Bowling.Exceptions;

[assembly: InternalsVisibleTo("Bowling.Tests")]

namespace Bowling
{
    using System.Collections.Generic;
    using System.Linq;

    internal class Line
    {
        private List<Frame> Frames { get; set; }
        private int _bonusBall1;
        private int _bonusBall2;

        public Line(string scores)
        {
            //Use DI/Autofac to resolve this 
            IScoreSheetValidator validator = new ScoreSheetValidator();
            if (!validator.Validate(scores))
                throw new InvalidScoreSheetException();

            InitialiseFramesFromScoreSheet(scores);
        }

        private void InitialiseFramesFromScoreSheet(string scores)
        {
            Frames = CreateFramesFromScoreSheet(scores);
            InitialiseBonusBalls();
        }

        private List<Frame> CreateFramesFromScoreSheet(string scores)
        {
            var framesInScoreSheet = scores.Split(Constants.FRAMEBOUNDARY);

            return (from balls in framesInScoreSheet where balls.Length > 0 select new Frame(balls.ToCharArray())).ToList();
        }

        private void InitialiseBonusBalls()
        {
            if (Frames.Count <= Constants.MAXFRAMECOUNT) return;

            _bonusBall1 = Frames.Last().BallOne;
            _bonusBall2 = Frames.Last().BallTwo;

            Frames.Remove(Frames.Last());
        }

        public int BonusBall1 => _bonusBall1;
        public int BonusBall2 => _bonusBall2;

        public int Total => CalculateTotalScore(Frames);

        private int CalculateTotalScore(IReadOnlyList<Frame> frames)
        {
            var score = 0;

            for (var index = 0; index < frames.Count; index++)
            {
                var currentFrame = frames[index];
                var currentFrameIsStrike = currentFrame.IsStrike;
                var currentFrameIsSpare = currentFrame.IsSpare;

                if (!currentFrameIsStrike && !currentFrameIsSpare)
                {
                    score += currentFrame.BallOne + currentFrame.BallTwo;
                }
                else
                {
                    score += Constants.STRIKEVALUE;
                    var bonusScore1 = 0;
                    var bonusScore2 = 0;
                    var isFinalFrame = index == Constants.MAXFRAMECOUNT - 1;

                    if (isFinalFrame)
                    {
                        bonusScore1 = BonusBall1;
                        if (currentFrameIsStrike)
                            bonusScore2 = BonusBall2;
                    }

                    if (IsPenultimateFrame(index))
                    {
                        var frame10 = frames.Last();
                        bonusScore1 = frame10.BallOne;
                        if (currentFrameIsStrike)
                        {
                            bonusScore2 = frame10.IsStrike ? BonusBall1 : frame10.BallTwo;
                        }
                    }

                    if (!isFinalFrame && !IsPenultimateFrame(index))
                    {
                        bonusScore1 = frames[index + 1].BallOne;
                        if (currentFrameIsStrike)
                        {
                            bonusScore2 = frames[index + 1].IsStrike
                                ? frames[index + 2].BallOne
                                : frames[index + 1].BallTwo;
                        }
                    }

                    score += bonusScore1 + bonusScore2;
                }
            }

            return score;
        }

        private bool IsPenultimateFrame(int index)
        {
            return index == 8;
        }
    }
}