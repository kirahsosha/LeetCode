/*
 * @lc app=leetcode.cn id=3418 lang=javascript
 *
 * [3418] 机器人可以获得的最大金币数
 */

// @lc code=start
/**
 * @param {number[][]} coins
 * @return {number}
 */
var maximumAmount = function (coins) {
  const m = coins.length;
  const n = coins[0].length;

  const solve = (rows, cols, transposed) => {
    const negInf = Number.NEGATIVE_INFINITY;
    const dp0 = new Array(cols).fill(negInf);
    const dp1 = new Array(cols).fill(negInf);
    const dp2 = new Array(cols).fill(negInf);

    for (let r = 0; r < rows; r++) {
      let left0 = negInf;
      let left1 = negInf;
      let left2 = negInf;
      for (let c = 0; c < cols; c++) {
        const up0 = dp0[c];
        const up1 = dp1[c];
        const up2 = dp2[c];

        let best0;
        let best1;
        let best2;
        if (r === 0 && c === 0) {
          best0 = 0;
          best1 = 0;
          best2 = 0;
        } else {
          best0 = Math.max(up0, left0);
          best1 = Math.max(up1, left1);
          best2 = Math.max(up2, left2);
        }

        const coin = transposed ? coins[c][r] : coins[r][c];
        const cur0 = best0 + coin;
        const cur1 = Math.max(best1 + coin, best0);
        const cur2 = Math.max(best2 + coin, best1);

        dp0[c] = cur0;
        dp1[c] = cur1;
        dp2[c] = cur2;

        left0 = cur0;
        left1 = cur1;
        left2 = cur2;
      }
    }

    const last = cols - 1;
    return Math.max(dp0[last], dp1[last], dp2[last]);
  };

  if (n <= m) {
    return solve(m, n, false);
  }
  return solve(n, m, true);
};
// @lc code=end
