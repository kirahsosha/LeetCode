/*
 * @lc app=leetcode.cn id=1877 lang=javascript
 *
 * [1877] 数组中最大数对和的最小值
 */

// @lc code=start
/**
 * @param {number[]} nums
 * @return {number}
 */
var minPairSum = function (nums) {
    nums.sort((a, b) => a - b);
    let ans = 0;
    for (let i = 0; i < Math.floor(nums.length / 2); i++) {
        ans = Math.max(ans, nums[i] + nums[nums.length - i - 1]);
    }
    return ans;
};
// @lc code=end

