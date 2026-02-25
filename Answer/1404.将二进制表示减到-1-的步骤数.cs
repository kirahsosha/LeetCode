/*
 * @lc app=leetcode.cn id=1404 lang=csharp
 *
 * [1404] 将二进制表示减到 1 的步骤数
 */

// @lc code=start
public class Solution
{
    public int NumSteps(string s)
    {
        var step = 0;
        var carry = 0;
        for (int i = s.Length - 1; i > 0; i--)
        {
            step++;
            if (s[i] - '0' + carry == 1)
            {
                carry = 1;
                step++;
            }
        }
        return step + carry;
    }
}
// @lc code=end

