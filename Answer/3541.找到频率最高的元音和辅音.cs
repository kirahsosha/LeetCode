/*
 * @lc app=leetcode.cn id=3541 lang=csharp
 *
 * [3541] 找到频率最高的元音和辅音
 */

// @lc code=start
public class Solution
{
    public int MaxFreqSum(string s)
    {
        if (s.Length == 1) return 1;
        var vowel = new Dictionary<char, int>
            {
                { ' ', 0 }
            };
        var consonant = new Dictionary<char, int>
            {
                { ' ', 0 }
            };
        foreach (var c in s)
        {
            if ("aeiou".Contains(c))
            {
                if (vowel.ContainsKey(c))
                {
                    vowel[c]++;
                }
                else
                {
                    vowel.Add(c, 1);
                }
            }
            else
            {
                if (consonant.ContainsKey(c))
                {
                    consonant[c]++;
                }
                else
                {
                    consonant.Add(c, 1);
                }
            }
        }
        return vowel.Values.Max() + consonant.Values.Max();
    }
}
// @lc code=end

