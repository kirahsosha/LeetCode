/*
 * @lc app=leetcode.cn id=198 lang=csharp
 *
 * [198] 打家劫舍
 */

// @lc code=start
public class Solution {
    //状态转移方程 dp[n] = max(dp[n-1], dp[n-2] + num[n])
    //因为在计算dp[i]的时候只需要使用到dp[i - 1]和dp[i - 2], 所以将数组优化为两个int
    public int Rob(int[] nums) {
        int len = nums.Length;
        if(len == 0) return 0;
        if(len == 1) return nums[0];
        if(len == 2) return Math.Max(nums[0], nums[1]);
        int dp1, dp2;
        dp1 = nums[0];
        dp2 = Math.Max(nums[0], nums[1]);
        for(int i = 2; i < len; i++)
        {
            int sum = Math.Max(dp1 + nums[i], dp2);
            dp1 = dp2;
            dp2 = sum;
        }
        return Math.Max(dp1, dp2);
    }
}
// @lc code=end

