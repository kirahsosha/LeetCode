/*
 * @lc app=leetcode.cn id=3227 lang=csharp
 *
 * [3227] 字符串元音游戏
 */

// @lc code=start
public class Solution {
    public bool DoesAliceWin(string s)
    {
        foreach (char c in s)
        {
            if ("aeiou".Contains(c))
            {
                return true;
            }
        }
        return false;
    }
}
// @lc code=end

