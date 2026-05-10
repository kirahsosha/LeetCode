/*
 * @lc app=leetcode.cn id=2770 lang=csharp
 *
 * [2770] 达到末尾下标所需的最大跳跃次数
 */

// @lc code=start
public class Solution {
    public int MaximumJumps(int[] nums, int target) {
        int n = nums.Length;
        int[] dp = new int[n];
        for (int i = 0; i < n; i++) {
            dp[i] = -1;
        }
        dp[0] = 0;
        
        for (int i = 1; i < n; i++) {
            for (int j = 0; j < i; j++) {
                int d = nums[i] - nums[j];
                if (d <= target && d >= -target && dp[j] != -1) {
                    dp[i] = Math.Max(dp[i], dp[j] + 1);
                }
            }
        }
        
        return dp[n - 1];
    }
}
// @lc code=end
