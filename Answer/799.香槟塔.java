/*
 * @lc app=leetcode.cn id=799 lang=java
 *
 * [799] 香槟塔
 */

// @lc code=start
class Solution {
    public double champagneTower(int poured, int query_row, int query_glass) {
        // dp[i][j] = (dp[i - 1][j - 1] - 1) / 2 + (dp[i - 1][j] - 1) / 2
        var dp = new double[query_row + 1][];
        for (int i = 0; i <= query_row; i++) {
            dp[i] = new double[i + 1];
            if (i == 0) {
                dp[i][0] = poured;
            } else {
                dp[i][0] = dp[i - 1][0] <= 1 ? 0 : (dp[i - 1][0] - 1) / 2;
                for (int j = 1; j < i; j++) {
                    dp[i][j] = (dp[i - 1][j - 1] <= 1 ? 0 : (dp[i - 1][j - 1] - 1) / 2)
                            + (dp[i - 1][j] <= 1 ? 0 : (dp[i - 1][j] - 1) / 2);
                }
                dp[i][i] = dp[i - 1][i - 1] <= 1 ? 0 : (dp[i - 1][i - 1] - 1) / 2;
            }
        }
        return dp[query_row][query_glass] >= 1 ? 1 : dp[query_row][query_glass];
    }
}
// @lc code=end
