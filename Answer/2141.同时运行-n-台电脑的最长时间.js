/*
 * @lc app=leetcode.cn id=2141 lang=javascript
 *
 * [2141] 同时运行 N 台电脑的最长时间
 */

// @lc code=start
/**
 * @param {number} n
 * @param {number[]} batteries
 * @return {number}
 */
var maxRunTime = function (n, batteries) {
    //可运行时间不超过平均时间
    var total = 0;
    batteries.forEach(num => {
        total += num;
    });
    var l = 0;
    var r = Math.floor(total / n) + 1;
    while (l + 1 < r) {
        //二分，假设能运行t分钟，b >= t的电池只能给一台电脑使用，b < t的电池可以组合使用
         t = l + Math.floor((r - l) / 2);
        var sum = 0;

        batteries.forEach(b => {
            sum += Math.min(b, t);
        });
        if (n * t <= sum) {
            //可以运行t分钟，下一轮查找范围[t,r)
            l = t;
        }
        else {
            //无法运行t分钟，下一轮查找范围[l,t)
            r = t;
        }
    }
    return l;
};
// @lc code=end

