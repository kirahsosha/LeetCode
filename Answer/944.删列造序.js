/*
 * @lc app=leetcode.cn id=944 lang=javascript
 *
 * [944] 删列造序
 */

// @lc code=start
/**
 * @param {string[]} strs
 * @return {number}
 */
var minDeletionSize = function (strs) {
    let n = strs[0].length;
    let res = 0;
    for (let i = 0; i < n; i++) {
        for (let j = 1; j < strs.length; j++) {
            if (strs[j].charAt(i) < strs[j - 1].charAt(i)) {
                res++;
                break;
            }
        }
    }
    return res;
};
// @lc code=end

