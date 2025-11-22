/*
 * @lc app=leetcode.cn id=3190 lang=csharp
 *
 * [3190] 使所有元素都可以被 3 整除的最少操作数
 */

// @lc code=start
public class Solution
{
    public int MinimumOperations(int[] nums)
    {
        int res = 0;
        foreach (var n in nums)
        {
            if (n % 3 == 0) continue;
            else
            {
                res++;
            }
        }
        return res;
    }
}
// @lc code=end

