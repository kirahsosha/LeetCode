/*
 * @lc app=leetcode.cn id=1015 lang=javascript
 *
 * [1015] 可被 K 整除的最小整数
 */

// @lc code=start
/**
 * @param {number} k
 * @return {number}
 */
var smallestRepunitDivByK = function (k) {
    var set = new Set();
    var n = 0;
    for (var i = 1; i <= k; i++) {
        n = (n * 10 + 1) % k;
        if (n == 0) {
            return i;
        }
        else if (set.has(n)) {
            return -1;
        }
        else {
            set.add(n);
        }
    }
    return -1;
};
// @lc code=end

