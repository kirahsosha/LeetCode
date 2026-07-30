/*
 * @lc app=leetcode.cn id=3014 lang=csharp
 *
 * [3014] 输入单词需要的最少按键次数 I
 */

// @lc code=start
public class Solution
{
    public int MinimumPushes(string word)
    {
        var n = word.Length;
        var ans = 0;
        var level = 1;
        while (n > 0)
        {
            if (n >= 8)
            {
                ans += 8 * level;
                n -= 8;
                level += 1;
            }
            else
            {
                ans += n * level;
                break;
            }
        }
        return ans;
    }
}
// @lc code=end

