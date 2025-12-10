/*
 * @lc app=leetcode.cn id=3577 lang=javascript
 *
 * [3577] 统计计算机解锁顺序排列数
 */

// @lc code=start
/**
 * @param {number[]} complexity
 * @return {number}
 */
var countPermutations = function (complexity) {
    let MOD = 1000000007;
    //complexity[0]必须是唯一最小值
    let res = 1;
    for (let i = 1; i < complexity.length; i++) {
        if (complexity[i] <= complexity[0]) {
            return 0;
        }
        res = res * i % MOD;
    }
    return res;
};
// @lc code=end

