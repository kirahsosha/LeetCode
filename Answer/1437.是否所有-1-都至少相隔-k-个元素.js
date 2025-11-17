/*
 * @lc app=leetcode.cn id=1437 lang=javascript
 *
 * [1437] 是否所有 1 都至少相隔 k 个元素
 */

// @lc code=start
/**
 * @param {number[]} nums
 * @param {number} k
 * @return {boolean}
 */
var kLengthApart = function (nums, k) {
    var index = -1;
    for (var i = 0; i < nums.length; i++) {
        if (nums[i] == 1 && index == -1) {
            index = 0;
        }
        else if (nums[i] == 1 && index < k) {
            return false;
        }
        else if (nums[i] == 1) {
            index = 0;
        }
        else if (index != -1) {
            index++;
        }
    }
    return true;
};
// @lc code=end

