/*
 * @lc app=leetcode.cn id=396 lang=javascript
 *
 * [396] 旋转函数
 */

// @lc code=start
/**
 * @param {number[]} nums
 * @return {number}
 */
var maxRotateFunction = function(nums) {
    const n = nums.length;

    let sum = 0, f = 0;
    for (let i = 0; i < n; i++) {
        sum += nums[i];
        f += i * nums[i];
    }

    let maxF = f;
    for (let i = n - 1; i > 0; i--) {
        f += sum - n * nums[i];
        if (f > maxF) {
            maxF = f;
        }
    }
    return maxF;
};
// @lc code=end
