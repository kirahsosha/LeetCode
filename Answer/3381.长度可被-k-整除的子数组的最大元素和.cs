/*
 * @lc app=leetcode.cn id=3381 lang=csharp
 *
 * [3381] 长度可被 K 整除的子数组的最大元素和
 */

// @lc code=start
public class Solution
{
    public long MaxSubarraySum(int[] nums, int k)
    {
        var n = nums.Length;
        var set = new long[k];
        long sum = 0;
        var res = long.MinValue;
        //initialize prefix sum array
        set[0] = 0;
        for (int i = 1; i < k; i++)
        {
            set[i] = 200000000000000;
        }
        for (int i = 0; i < n; i++)
        {
            sum += nums[i];
            res = Math.Max(res, sum - set[(i + 1) % k]);
            set[(i + 1) % k] = Math.Min(set[(i + 1) % k], sum);
        }
        return res;
    }
}
// @lc code=end

