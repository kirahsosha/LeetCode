/*
 * @lc app=leetcode.cn id=3432 lang=csharp
 *
 * [3432] 统计元素和差值为偶数的分区方案
 */

// @lc code=start
public class Solution
{
    public int CountPartitions(int[] nums)
    {
        var sum = 0;
        foreach (var i in nums)
        {
            sum += i;
        }
        if (sum % 2 != 0)
        {
            return 0;
        }
        var res = 0;
        var left = 0;
        for (int i = 0; i < nums.Length - 1; i++)
        {
            left += nums[i];
            sum -= nums[i];
            if ((left - sum) % 2 == 0)
            {
                res++;
            }
        }
        return res;
    }
}
// @lc code=end

