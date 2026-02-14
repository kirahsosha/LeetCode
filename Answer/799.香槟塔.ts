/*
 * @lc app=leetcode.cn id=799 lang=typescript
 *
 * [799] 香槟塔
 */

// @lc code=start
function champagneTower(poured: number, query_row: number, query_glass: number): number {

    function GetHalf(num: number) {
        if (num <= 1) {
            return 0;
        }
        return (num - 1) / 2;
    }

    //dp[i][j] = (dp[i - 1][j - 1] - 1) / 2 + (dp[i - 1][j] - 1) / 2
    let dp = new Array(query_row + 1);
    for (let i = 0; i <= query_row; i++) {
        dp[i] = new Array(i + 1);
        if (i == 0) {
            dp[i][0] = poured;
        }
        else {
            dp[i][0] = GetHalf(dp[i - 1][0]);
            for (let j = 1; j < i; j++) {
                dp[i][j] = GetHalf(dp[i - 1][j - 1]) + GetHalf(dp[i - 1][j]);
            }
            dp[i][i] = GetHalf(dp[i - 1][i - 1]);
        }
    }
    return dp[query_row][query_glass] >= 1 ? 1 : dp[query_row][query_glass];

};
// @lc code=end

