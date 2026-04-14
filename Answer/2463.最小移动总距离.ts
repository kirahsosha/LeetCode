/*
 * @lc app=leetcode.cn id=2463 lang=typescript
 *
 * [2463] 最小移动总距离
 */

// @lc code=start
function minimumTotalDistance(robot: number[], factory: number[][]): number {
    robot.sort((a, b) => a - b);
    factory.sort((a, b) => a[0] - b[0]);

    const n = robot.length;
    const m = factory.length;
    const dp: number[][] = Array.from({ length: m + 1 }, () => Array(n + 1).fill(Infinity));
    dp[0][0] = 0;

    for (let i = 1; i <= m; i++) {
        const pos = factory[i - 1][0];
        const limit = factory[i - 1][1];
        for (let j = 0; j <= n; j++) {
            dp[i][j] = dp[i - 1][j];
            let sum = 0;
            for (let k = 1; k <= limit && k <= j; k++) {
                sum += Math.abs(robot[j - k] - pos);
                if (dp[i - 1][j - k] !== Infinity) {
                    dp[i][j] = Math.min(dp[i][j], dp[i - 1][j - k] + sum);
                }
            }
        }
    }

    return dp[m][n];
};
// @lc code=end
