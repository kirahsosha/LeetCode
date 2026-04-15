/*
 * @lc app=leetcode.cn id=2515 lang=javascript
 *
 * [2515] 到目标字符串的最短距离
 */

// @lc code=start
/**
 * @param {string[]} words
 * @param {string} target
 * @param {number} startIndex
 * @return {number}
 */
var closestTarget = function(words, target, startIndex) {
    const n = words.length;
    for (let i = 0; i < Math.floor(n / 2) + 1; i++) {
        if (words[(startIndex + i) % n] === target || words[(startIndex - i + n) % n] === target) {
            return i;
        }
    }
    return -1;
};
// @lc code=end

