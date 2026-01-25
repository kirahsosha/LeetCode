/*
 * @lc app=leetcode.cn id=1984 lang=javascript
 *
 * [1984] 学生分数的最小差值
 */

// @lc code=start
/**
 * @param {number[]} nums
 * @param {number} k
 * @return {number}
 */
var minimumDifference = function (nums, k) {
    if (k == 1) {
        return 0;
    }
    nums.sort((a, b) => a - b);
    let ans = nums[k - 1] - nums[0];
    for (let i = 1; i <= nums.length - k; i++) {
        ans = Math.min(ans, nums[i + k - 1] - nums[i]);
    }
    return ans;
};
// @lc code=end

