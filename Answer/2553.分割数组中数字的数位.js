/*
 * @lc app=leetcode.cn id=2553 lang=javascript
 *
 * [2553] 分割数组中数字的数位
 */

// @lc code=start
/**
 * @param {number[]} nums
 * @return {number[]}
 */
var separateDigits = function(nums) {
    // JS 引擎对字符串操作高度优化，join + charCodeAt 比数学循环更快
    const str = nums.join('');
    const ans = new Array(str.length);
    for (let i = 0; i < str.length; i++) {
        ans[i] = str.charCodeAt(i) - 48;
    }
    return ans;
};
// @lc code=end
