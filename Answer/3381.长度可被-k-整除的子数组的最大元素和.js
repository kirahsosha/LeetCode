/*
 * @lc app=leetcode.cn id=3381 lang=javascript
 *
 * [3381] 长度可被 K 整除的子数组的最大元素和
 */

// @lc code=start
/**
 * @param {number[]} nums
 * @param {number} k
 * @return {number}
 */
var maxSubarraySum = function (nums, k) {
    var n = nums.length;
    var set = Array(k).fill(200000000000000);
    var sum = 0;
    var res = -200000000000000;
    //initialize prefix sum array
    set[0] = 0;
    for (var i = 0; i < n; i++) {
        sum += nums[i];
        res = Math.max(res, sum - set[(i + 1) % k]);
        set[(i + 1) % k] = Math.min(set[(i + 1) % k], sum);
    }
    return res;
};
// @lc code=end

