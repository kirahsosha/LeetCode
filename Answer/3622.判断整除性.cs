/*
 * @lc app=leetcode.cn id=3622 lang=csharp
 *
 * [3622] 判断整除性
 */

// @lc code=start
public class Solution
{
    public bool CheckDivisibility(int n)
    {
        var sum = 0;
        var pro = 1;
        var temp = n;
        while (temp > 0)
        {
            var d = temp % 10;
            sum += d;
            pro *= d;
            temp /= 10;
        }
        return n % (sum + pro) == 0;
    }
}
// @lc code=end

