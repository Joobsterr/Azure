using MVCWebDemo.Core.DAL.Model;
using System.Collections.Generic;
using System.Data;

namespace MVCWebDemo.Core.DAL.Contexts
{
    public class HighScoreContext : BaseMSSQLContext, IHighScoreContext
    {
        public HighScoreContext()
        {

        }
        public List<HighScore> GetHighScores()
        {
            // removes the part behind @... in the emailadress so people wont have their full emails exposed in the leaderboards
            string sql = "SELECT TOP 10 (Time), REPLACE(LEFT([User], CHARINDEX('@',[User]) - 1),'_',' ') [User] FROM[dbi408687].[dbo].[Highscore] ORDER BY [TIME] ASC ";
            List<KeyValuePair<string, string>> para = new List<KeyValuePair<string, string>>();
            DataSet result = ExecuteSql(sql, para);

            List<HighScore> high = new List<HighScore>();
            if (result != null)
            {
                for (int i = 0; i < result.Tables[0].Rows.Count; i++)
                {
                    HighScore h = DataSetParser.DataSetToScore(result, i);
                    high.Add(h);
                }
            }
            return high;
        }
    }
}
