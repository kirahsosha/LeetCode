/*
 * @lc app=leetcode.cn id=3075 lang=javascript
 *
 * [3075] 幸福值最大化的选择方案
 */

// @lc code=start
/**
 * @param {number[]} happiness
 * @param {number} k
 * @return {number}
 */
var maximumHappinessSum = function (happiness, k) {
    happiness.sort((a, b) => b - a);
    let res = 0;
    for (let i = 0; i < k; i++) {
        res += Math.max(0, happiness[i] - i);
    }
    return res;
};
// @lc code=end

