/*
 * @lc app=leetcode.cn id=1925 lang=javascript
 *
 * [1925] 统计平方和三元组的数目
 */

// @lc code=start
/**
 * @param {number} n
 * @return {number}
 */
var countTriples = function (n) {
    //a^2 + b^2 = c^2
    //1 <= a, b, c <= n
    //a, b <= sqrt(n^2 / 2)
    let maxa = Math.floor(Math.sqrt(n * n / 2));
    let res = 0;
    for (let a = 3; a <= maxa; a++) {
        let maxb = Math.floor(Math.sqrt(n * n - a * a));
        for (let b = a + 1; b <= maxb; b++) {
            let sum = Math.sqrt(a * a + b * b);
            if (sum == Math.floor(sum)) {
                res += 2;
            }
        }
    }
    return res;
};
// @lc code=end

