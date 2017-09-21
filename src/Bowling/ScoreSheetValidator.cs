namespace Bowling
{
    public class ScoreSheetValidator : IScoreSheetValidator
    {
        //figure out what the RegEx should be!
//        private const string RulesRegEx = "[0-9\\-Xx/\\|]*10||[0-9\\-Xx/\\|]*1";
        public bool Validate(string scoreSheet)
        {
            if (scoreSheet.Length < 22 || scoreSheet.Length > 33) return false;

            return true;
        }
    }
}