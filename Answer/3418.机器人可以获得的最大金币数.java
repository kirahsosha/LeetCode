/*
 * @lc app=leetcode.cn id=3418 lang=java
 *
 * [3418] 机器人可以获得的最大金币数
 */

// @lc code=start
class Solution {

    public int maximumAmount(int[][] coins) {
        int m = coins.length;
        int n = coins[0].length;
        if (n <= m) {
            return solve(coins, m, n, false);
        }
        return solve(coins, n, m, true);
    }

    private int solve(int[][] coins, int rows, int cols, boolean transposed) {
        final int negInf = Integer.MIN_VALUE / 4;
        int[] dp0 = new int[cols];
        int[] dp1 = new int[cols];
        int[] dp2 = new int[cols];
        for (int c = 0; c < cols; c++) {
            dp0[c] = negInf;
            dp1[c] = negInf;
            dp2[c] = negInf;
        }

        for (int r = 0; r < rows; r++) {
            int left0 = negInf;
            int left1 = negInf;
            int left2 = negInf;
            for (int c = 0; c < cols; c++) {
                int up0 = dp0[c];
                int up1 = dp1[c];
                int up2 = dp2[c];

                int best0;
                int best1;
                int best2;
                if (r == 0 && c == 0) {
                    best0 = 0;
                    best1 = 0;
                    best2 = 0;
                } else {
                    best0 = Math.max(up0, left0);
                    best1 = Math.max(up1, left1);
                    best2 = Math.max(up2, left2);
                }

                int coin = transposed ? coins[c][r] : coins[r][c];
                int cur0 = best0 + coin;
                int cur1 = Math.max(best1 + coin, best0);
                int cur2 = Math.max(best2 + coin, best1);

                dp0[c] = cur0;
                dp1[c] = cur1;
                dp2[c] = cur2;

                left0 = cur0;
                left1 = cur1;
                left2 = cur2;
            }
        }

        int last = cols - 1;
        return Math.max(dp0[last], Math.max(dp1[last], dp2[last]));
    }
}
// @lc code=end

