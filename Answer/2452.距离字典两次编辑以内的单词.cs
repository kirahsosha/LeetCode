/*
 * @lc app=leetcode.cn id=2452 lang=csharp
 *
 * [2452] 距离字典两次编辑以内的单词
 */

// @lc code=start
public class Solution
{
    public IList<string> TwoEditWords(string[] queries, string[] dictionary)
    {
        int EditTimes(string a, string b)
        {
            int diff = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i])
                {
                    diff++;
                }
            }
            return diff;
        }

        var ans = new List<string>();
        foreach (var query in queries)
        {
            foreach (var dict in dictionary)
            {
                if (EditTimes(query, dict) <= 2)
                {
                    ans.Add(query);
                    break;
                }
            }
        }
        return ans;
    }
}
// @lc code=end

