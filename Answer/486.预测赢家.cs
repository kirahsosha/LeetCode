/*
 * @lc app=leetcode.cn id=486 lang=csharp
 *
 * [486] 预测赢家
 */

// @lc code=start
public class Solution
{
    public bool PredictTheWinner(int[] nums)
    {
        var n = nums.Length;
        int[][] dp = new int[n][];
        for (int i = 0; i < n; i++)
        {
            dp[i] = new int[n];
            dp[i][i] = nums[i];
        }

        for (int i = n - 2; i >= 0; i--)
        {
            for (int j = i + 1; j < n; j++)
            {
                dp[i][j] = Math.Max(nums[i] - dp[i + 1][j], nums[j] - dp[i][j - 1]);
            }
        }

        return dp[0][n - 1] >= 0;
    }
}
// @lc code=end

