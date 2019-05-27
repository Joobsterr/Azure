using MVCWebDemo.Core.DAL.Contexts;
using MVCWebDemo.Core.DAL.Model;
using System.Collections.Generic;


namespace MVCWebDemo.Core.BLL
{
    public class HighScoreRepository
    {
        IHighScoreContext context;

        public HighScoreRepository(IHighScoreContext _Context)
        {
            context = _Context;
        }

        public List<HighScore> GetScores()
        {
            return context.GetHighScores();
        }
    }
}
