/*
 * @lc app=leetcode.cn id=3315 lang=javascript
 *
 * [3315] 构造最小位运算数组 II
 */

// @lc code=start
/**
 * @param {number[]} nums
 * @return {number[]}
 */
var minBitwiseArray = function (nums) {
    let n = nums.length;
    let ans = [];
    for (let i = 0; i < n; i++) {
        let value = nums[i];
        if (value == 2) {
            ans[i] = -1;
        }
        else {
            let t = ~value;
            let lowbit = t & -t;
            ans[i] = value ^ (lowbit >> 1);
        }
    }
    return ans;
};
// @lc code=end

