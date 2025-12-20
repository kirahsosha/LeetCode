/*
 * @lc app=leetcode.cn id=955 lang=javascript
 *
 * [955] 删列造序 II
 */

// @lc code=start
/**
 * @param {string[]} strs
 * @return {number}
 */
var minDeletionSize = function (strs) {
    let n = strs.length;
    let m = strs[0].length;
    let cuts = new Array(n - 1).fill(false);

    let ans = 0;
    for (let j = 0; j < m; j++) {
        var check = true;
        for (let i = 0; i < n - 1; i++) {
            if (!cuts[i] && strs[i].charAt(j) > strs[i + 1].charAt(j)) {
                ans++;
                check = false;
                break;
            }
        }
        if (check) {
            for (let i = 0; i < n - 1; i++) {
                if (strs[i].charAt(j) < strs[i + 1].charAt(j)) {
                    cuts[i] = true;
                }
            }
        }
    }

    return ans;
};
// @lc code=end

