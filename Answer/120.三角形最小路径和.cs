/*
 * @lc app=leetcode.cn id=120 lang=csharp
 *
 * [120] 三角形最小路径和
 */

// @lc code=start
public class Solution
{
    public int MinimumTotal(IList<IList<int>> triangle)
    {
        if (triangle.Count == 1)
        {
            return triangle[0][0];
        }
        var n = triangle.Count;
        int[] dp = new int[n];
        dp[0] = triangle[0][0];
        for (int i = 1; i < n; i++)
        {
            for (int j = i; j >= 0; j--)
            {
                if (j == 0)
                {
                    dp[j] = dp[j] + triangle[i][j];
                }
                else if (j == i)
                {
                    dp[j] = dp[j - 1] + triangle[i][j];
                }
                else
                {
                    dp[j] = Math.Min(dp[j], dp[j - 1]) + triangle[i][j];
                }
            }
        }
        return dp.Min();
    }
}
// @lc code=end

