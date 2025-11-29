/*
 * @lc app=leetcode.cn id=3512 lang=csharp
 *
 * [3512] 使数组和能被 K 整除的最少操作次数
 */

// @lc code=start
public class Solution
{
    public int MinOperations(int[] nums, int k)
    {
        var res = 0;
        foreach (var n in nums)
        {
            res = (res + n) % k;
        }
        return res;
    }
}
// @lc code=end

