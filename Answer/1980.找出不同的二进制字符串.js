/*
 * @lc app=leetcode.cn id=1980 lang=javascript
 *
 * [1980] 找出不同的二进制字符串
 */

// @lc code=start
/**
 * @param {string[]} nums
 * @return {string}
 */
var findDifferentBinaryString = function (nums) {
    var n = nums.length;
    var res = "";
    for (var i = 0; i < n; i++) {
        res += nums[i].charAt(i) == '0' ? '1' : '0';
    }
    return res;
};
// @lc code=end

