/*
 * @lc app=leetcode.cn id=2463 lang=java
 *
 * [2463] 最小移动总距离
 */

// @lc code=start
import java.util.Arrays;
import java.util.List;

class Solution {

    public long minimumTotalDistance(List<Integer> robot, int[][] factory) {
        int n = robot.size();
        int[] robots = new int[n];
        for (int i = 0; i < n; i++) {
            robots[i] = robot.get(i);
        }
        Arrays.sort(robots);
        Arrays.sort(factory, (a, b) -> Integer.compare(a[0], b[0]));

        int m = factory.length;
        long[][] dp = new long[m + 1][n + 1];
        for (int j = 1; j <= n; j++) {
            dp[0][j] = Long.MAX_VALUE;
        }

        for (int i = 1; i <= m; i++) {
            int pos = factory[i - 1][0];
            int limit = factory[i - 1][1];
            for (int j = 0; j <= n; j++) {
                dp[i][j] = dp[i - 1][j];
                long sum = 0;
                for (int k = 1; k <= limit && k <= j; k++) {
                    sum += Math.abs(robots[j - k] - pos);
                    if (dp[i - 1][j - k] != Long.MAX_VALUE) {
                        dp[i][j] = Math.min(dp[i][j], dp[i - 1][j - k] + sum);
                    }
                }
            }
        }

        return dp[m][n];
    }
}
// @lc code=end
