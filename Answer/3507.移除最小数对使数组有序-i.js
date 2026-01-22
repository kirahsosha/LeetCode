/*
 * @lc app=leetcode.cn id=3507 lang=javascript
 *
 * [3507] 移除最小数对使数组有序 I
 */

// @lc code=start
/**
 * @param {number[]} nums
 * @return {number}
 */
var minimumPairRemoval = function (nums) {
    let times = 0;
    while (!Check()) {
        let index = GetMin();
        nums = Replace(index);
        times++;
    }
    return times;

    function GetMin() {
        let res = nums[0] + nums[1];
        let index = 0;
        for (let i = 1; i < nums.length - 1; i++) {
            if (nums[i] + nums[i + 1] < res) {
                res = nums[i] + nums[i + 1];
                index = i;
            }
        }
        return index;
    }

    function Replace(index) {
        let newNums = [];
        for (let i = 0; i < index; i++) {
            newNums[i] = nums[i];
        }
        newNums[index] = nums[index] + nums[index + 1];
        for (let i = index + 2; i < nums.length; i++) {
            newNums[i - 1] = nums[i];
        }
        return newNums;
    }

    function Check() {
        if (nums.length <= 1) {
            return true;
        }

        for (let i = 0; i < nums.length - 1; i++) {
            if (nums[i] > nums[i + 1]) {
                return false;
            }
        }
        return true;
    }
};
// @lc code=end

