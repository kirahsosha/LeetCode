/*
 * @lc app=leetcode.cn id=3314 lang=javascript
 *
 * [3314] 构造最小位运算数组 I
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
        let num = nums[i];
        let min = Math.floor(num / 2);
        ans[i] = -1;
        for (let j = min; j < num; j++) {
            if ((j | (j + 1)) == num) {
                ans[i] = j;
                break;
            }
        }
    }
    return ans;
};
// @lc code=end

