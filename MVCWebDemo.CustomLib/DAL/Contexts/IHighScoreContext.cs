using MVCWebDemo.Core.DAL.Model;
using System.Collections.Generic;

namespace MVCWebDemo.Core.DAL.Contexts
{
    public interface IHighScoreContext
    {
        List<HighScore> GetHighScores();
    }
}
