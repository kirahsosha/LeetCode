/*
 * @lc app=leetcode.cn id=1390 lang=javascript
 *
 * [1390] 四因数
 */

// @lc code=start
/**
 * @param {number[]} nums
 * @return {number}
 */
var sumFourDivisors = function (nums) {
    let res = 0;
    nums.forEach(n => {
        let di = AllDivisors(n);
        if (di.size == 4) {
            di.forEach(i => {
                res += i;
            });
        }
    });
    return res;
};

function AllDivisors(n) {
    let res = new Set();
    for (let i = 1; i <= Math.sqrt(n); i++) {
        if (n % i == 0) {
            res.add(i);
            res.add(n / i);
        }
    }
    return res;
}
// @lc code=end

