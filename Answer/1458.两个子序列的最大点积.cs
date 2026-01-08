/*
 * @lc app=leetcode.cn id=1458 lang=csharp
 *
 * [1458] 两个子序列的最大点积
 */

// @lc code=start
public class Solution
{
    public int MaxDotProduct(int[] nums1, int[] nums2)
    {
        //i - nums1 index
        //j - nums2 index
        //dp[i][j] = max(dp[i-1][j-1], dp[i-1][j-1] + nums1[i] * nums2[j])
        var n1 = nums1.Length;
        var n2 = nums2.Length;
        var dp = new int[n1, n2];
        var max = -1000000;
        for (int i = 0; i < n1; i++)
        {
            for (int j = 0; j < n2; j++)
            {
                if (i == 0 && j == 0)
                {
                    dp[0, 0] = Math.Max(-1000000, nums1[i] * nums2[j]);
                    max = Math.Max(max, dp[i, j]);
                }
                else if (i == 0)
                {
                    dp[0, j] = Math.Max(dp[0, j - 1], nums1[i] * nums2[j]);
                    max = Math.Max(max, dp[i, j]);
                }
                else if (j == 0)
                {
                    dp[i, 0] = Math.Max(dp[i - 1, 0], nums1[i] * nums2[j]);
                    max = Math.Max(max, dp[i, j]);
                }
                else
                {
                    dp[i, j] = Math.Max(Math.Max(dp[i, j - 1], dp[i - 1, j]), Math.Max(dp[i - 1, j - 1], Math.Max(dp[i - 1, j - 1] + nums1[i] * nums2[j], nums1[i] * nums2[j])));
                    max = Math.Max(max, dp[i, j]);
                }
            }
        }
        return max;
    }
}
// @lc code=end

