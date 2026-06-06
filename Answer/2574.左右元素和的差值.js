/*
 * @lc app=leetcode.cn id=2574 lang=javascript
 *
 * [2574] 左右元素和的差值
 */

// @lc code=start
/**
 * @param {number[]} nums
 * @return {number[]}
 */
var leftRightDifference = function (nums) {
    var total = 0;
    for (var i = 0; i < nums.length; i++) {
        total += nums[i];
    }

    var leftSum = 0;
    var ans = new Array(nums.length);
    for (var i = 0; i < nums.length; i++) {
        var diff = 2 * leftSum + nums[i] - total;
        ans[i] = diff < 0 ? -diff : diff;
        leftSum += nums[i];
    }
    return ans;
};
// @lc code=end
