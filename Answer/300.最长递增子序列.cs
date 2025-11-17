/*
 * @lc app=leetcode.cn id=300 lang=csharp
 *
 * [300] 最长递增子序列
 */

// @lc code=start
public class Solution
{
    public int LengthOfLIS(int[] nums)
    {
        int n = nums.Length;
        if (n == 1) return 1;
        int[] dp = new int[n];
        for (int i = 0; i < n; i++)
        {
            dp[i] = 1;
        }
        int ans = 0;
        for (int i = 1; i < n; i++)
        {
            for (int j = 0; j < i; j++)
            {
                // 如果当前位置前面的数中存在比当前的数小的，就进行状态转移
                if (nums[j] < nums[i])
                {
                    dp[i] = Math.Max(dp[j] + 1, dp[i]);
                }
            }
            ans = Math.Max(ans, dp[i]);
        }
        return ans;
    }
}
// @lc code=end

