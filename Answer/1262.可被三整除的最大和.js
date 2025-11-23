/*
 * @lc app=leetcode.cn id=1262 lang=javascript
 *
 * [1262] 可被三整除的最大和
 */

// @lc code=start
/**
 * @param {number[]} nums
 * @return {number}
 */
var maxSumDivThree = function (nums) {
    var res = 0;
    var min1 = 0, min12 = 0, min2 = 0, min22 = 0;
    nums.forEach(num => {
        res += num;
        if (num % 3 == 1) {
            if (min1 == 0 || num <= min1) {
                min12 = min1;
                min1 = num;
            }
            else if (min12 == 0 || num <= min12) {
                min12 = num;
            }
        }
        else if (num % 3 == 2) {
            if (min2 == 0 || num <= min2) {
                min22 = min2;
                min2 = num;
            }
            else if (min22 == 0 || num <= min22) {
                min22 = num;
            }
        }
    });
    if (res % 3 == 1) {
        if (min1 == 0) {
            res = res - min2 - min22;
        }
        else if (min22 == 0) {
            res = res - min1;
        }
        else {
            res = Math.max(res - min1, res - min2 - min22);
        }
    }
    else if (res % 3 == 2) {
        if (min2 == 0) {
            res = res - min1 - min12;
        }
        else if (min12 == 0) {
            res = res - min2;
        }
        else {
            res = Math.max(res - min2, res - min1 - min12);
        }
    }
    return res;
};
// @lc code=end

