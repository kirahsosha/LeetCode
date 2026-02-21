/*
 * @lc app=leetcode.cn id=868 lang=csharp
 *
 * [868] 二进制间距
 */

// @lc code=start
public class Solution
{
    public int BinaryGap(int n)
    {
        var ans = 0;
        var left = 0;
        var right = 0;
        while (n > 0)
        {
            right++;
            if (n % 2 == 1)
            {
                if (left == 0)
                {
                    left = right;
                }
                else
                {
                    ans = Math.Max(ans, right - left);
                    left = right;
                }
            }
            n /= 2;
        }
        return ans;
    }
}
// @lc code=end

