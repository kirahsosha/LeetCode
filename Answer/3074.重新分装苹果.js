/*
 * @lc app=leetcode.cn id=3074 lang=javascript
 *
 * [3074] 重新分装苹果
 */

// @lc code=start
/**
 * @param {number[]} apple
 * @param {number[]} capacity
 * @return {number}
 */
var minimumBoxes = function (apple, capacity) {
    let apples = 0;
    apple.forEach(a => {
        apples += a;
    });
    capacity = capacity.sort((a, b) => b - a);
    let res = 0;
    for (let i = 0; i < capacity.length; i++) {
        apples -= capacity[i];
        res++;
        if (apples <= 0) {
            break;
        }
    }
    return res;
};
// @lc code=end

