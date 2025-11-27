/*
 * @lc app=leetcode.cn id=3381 lang=java
 *
 * [3381] 长度可被 K 整除的子数组的最大元素和
 */

// @lc code=start
class Solution {
    public long maxSubarraySum(int[] nums, int k) {
        var n = nums.length;
        var set = new long[k];
        long sum = 0;
        long res = Long.MIN_VALUE;
        //initialize prefix sum array
        set[0] = 0;
        for (int i = 1; i < k; i++)
        {
            set[i] = Long.MAX_VALUE / 2;
        }
        for (int i = 0; i < n; i++)
        {
            sum += nums[i];
            res = Math.max(res, sum - set[(i + 1) % k]);
            set[(i + 1) % k] = Math.min(set[(i + 1) % k], sum);
        }
        return res;
    }
}
// @lc code=end

