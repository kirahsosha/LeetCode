/*
 * @lc app=leetcode.cn id=2463 lang=csharp
 *
 * [2463] 最小移动总距离
 */

// @lc code=start
public class Solution {
    public long MinimumTotalDistance(IList<int> robot, int[][] factory) {
        int[] robots = robot.ToArray();
        Array.Sort(robots);
        Array.Sort(factory, (a, b) => a[0].CompareTo(b[0]));

        int n = robots.Length;
        int m = factory.Length;
        long[][] dp = new long[m + 1][];
        for (int i = 0; i <= m; i++) {
            dp[i] = new long[n + 1];
            for (int j = 1; j <= n; j++) {
                dp[i][j] = long.MaxValue;
            }
        }

        for (int i = 1; i <= m; i++) {
            int pos = factory[i - 1][0];
            int limit = factory[i - 1][1];
            for (int j = 0; j <= n; j++) {
                dp[i][j] = dp[i - 1][j];
                long sum = 0;
                for (int k = 1; k <= limit && k <= j; k++) {
                    sum += Math.Abs(robots[j - k] - pos);
                    if (dp[i - 1][j - k] != long.MaxValue) {
                        dp[i][j] = Math.Min(dp[i][j], dp[i - 1][j - k] + sum);
                    }
                }
            }
        }

        return dp[m][n];
    }
}
// @lc code=end
