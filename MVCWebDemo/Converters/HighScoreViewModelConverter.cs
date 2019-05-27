using MVCWebDemo.Core.DAL.Model;
using MVCWebDemo.Models;

namespace MVCWebDemo.Converters
{
    public class HighScoreViewModelConverter
    {
        public HighScore ViewModelToScore(HighScoreViewModel vm)
        {
            HighScore h = new HighScore()
            {
                Score = vm.Score,
                UserName = vm.UserName
            };
            return h;
        }
    }
}
