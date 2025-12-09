/*
 * @lc app=leetcode.cn id=3583 lang=javascript
 *
 * [3583] 统计特殊三元组
 */

// @lc code=start
/**
 * @param {number[]} nums
 * @return {number}
 */
var specialTriplets = function (nums) {
    let MOD = 1000000007;
    //记录每个值的出现次数
    let dic = new Map();
    //记录i左边有多少符合条件nums[i]*2的值
    let count = new Map();
    for (let i = 0; i < nums.length; i++) {
        if (dic.has(nums[i])) {
            dic.set(nums[i], dic.get(nums[i]) + 1);
        }
        else {
            dic.set(nums[i], 1);
        }
        if (nums[i] != 0 && dic.has(nums[i] * 2)) {
            count.set(i, dic.get(nums[i] * 2));
        }
    }
    let res = 0;
    for (let key of count.keys()) {
        var value = count.get(key);
        if (key != 0) {
            var right = dic.get(nums[key] * 2) - value;
            res = (value * right + res) % MOD;
        }
    };
    //处理0
    if (dic.has(0) && dic.get(0) >= 3) {
        var c = dic.get(0);
        let zero = c * (c - 1) * (c - 2) / 6 % MOD;
        res = (res + zero) % MOD;
    }
    return res;
};
// @lc code=end

