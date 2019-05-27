using MVCWebDemo.Core.DAL.Model;
using System;
using System.Data;

namespace MVCWebDemo.Core.DAL
{
    public static class DataSetParser
    {
        public static HighScore DataSetToScore(DataSet set, int rowIndex)
        {
            return new HighScore()
            {
                Score = Convert.ToString(set.Tables[0].Rows[rowIndex][0]),
                UserName = Convert.ToString(set.Tables[0].Rows[rowIndex][1])
            };
        }
    }
}
