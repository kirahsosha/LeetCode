/*
 * @lc app=leetcode.cn id=1689 lang=csharp
 *
 * [1689] 十-二进制数的最少数目
 */

// @lc code=start
public class Solution
{
    public int MinPartitions(string n)
    {
        var res = 0;
        foreach (var c in n)
        {
            res = Math.Max(res, c - '0');
        }
        return res;
    }
}
// @lc code=end

