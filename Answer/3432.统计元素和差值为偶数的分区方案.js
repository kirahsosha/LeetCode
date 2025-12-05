/*
 * @lc app=leetcode.cn id=3432 lang=javascript
 *
 * [3432] 统计元素和差值为偶数的分区方案
 */

// @lc code=start
/**
 * @param {number[]} nums
 * @return {number}
 */
var countPartitions = function (nums) {
    var sum = 0;
    nums.forEach(i => {
        sum += i;
    });
    if (sum % 2 != 0) {
        return 0;
    }
    var res = 0;
    var left = 0;
    for (var i = 0; i < nums.length - 1; i++) {
        left += nums[i];
        sum -= nums[i];
        if ((left - sum) % 2 == 0) {
            res++;
        }
    }
    return res;
};
// @lc code=end

