using System.Collections.Generic;

namespace MVCWebDemo.Core.DAL.Model
{
    public class HighScore
    {
        public string UserName { get; set; }
        public string Score { get; set; }

        public List<HighScore> Scores;

    }
}
