using System.Collections.Generic;

namespace LeetCodeTester.Solutions
{
    public partial class Solution
    {
        public Dictionary<string, object> ParseCron(string cron)
        {
            var crons = cron.Split(' ');
            var dic = new Dictionary<string, object>();
            var keys = new string[] { "minutes", "hours", "day_of_month", "month", "day_of_week" };

            for (int i = 0; i < keys.Length; i++)
            {
                dic.Add(keys[i], GetValue(crons[i]));
            }

            return dic;

            object GetValue(string s)
            {
                if (int.TryParse(s, out var time))
                {
                    return time;
                }
                return s;
            }
        }
    }
}
