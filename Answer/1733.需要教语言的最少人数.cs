/*
 * @lc app=leetcode.cn id=1733 lang=csharp
 *
 * [1733] 需要教语言的最少人数
 */

// @lc code=start
public class Solution
{
    public int MinimumTeachings(int n, int[][] languages, int[][] friendships)
    {
        var needToLearn = new HashSet<int>();
        var langMap = new Dictionary<int, HashSet<int>>();
        for (int i = 0; i < languages.Length; i++)
        {
            langMap[i + 1] = new HashSet<int>(languages[i]);
        }
        foreach (var friendship in friendships)
        {
            var user1 = friendship[0];
            var user2 = friendship[1];
            var lang1 = langMap[user1];
            var lang2 = langMap[user2];
            var common = false;
            foreach (var l in lang1)
            {
                if (lang2.Contains(l))
                {
                    common = true;
                    break;
                }
            }
            if (!common)
            {
                needToLearn.Add(user1);
                needToLearn.Add(user2);
            }
        }
        var langCount = new int[n + 1];
        foreach (var user in needToLearn)
        {
            var langs = langMap[user];
            foreach (var l in langs)
            {
                langCount[l]++;
            }
        }
        var max = 0;
        for (int i = 1; i <= n; i++)
        {
            max = Math.Max(max, langCount[i]);
        }
        return needToLearn.Count - max;
    }
}
// @lc code=end

