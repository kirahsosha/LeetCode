/*
 * @lc app=leetcode.cn id=2033 lang=javascript
 *
 * [2033] 获取单值网格的最小操作数
 */

// @lc code=start
/**
 * @param {number[][]} grid
 * @param {number} x
 * @return {number}
 */
var minOperations = function(grid, x) {
    const base = grid[0][0];
    const nums = [];
    
    for (const row of grid) {
        for (const num of row) {
            if ((num - base) % x !== 0) {
                return -1;
            }
            nums.push(num);
        }
    }
    
    nums.sort((a, b) => a - b);
    const median = nums[nums.length >> 1];
    let ans = 0;
    
    for (const num of nums) {
        ans += Math.abs(num - median) / x;
    }
    
    return ans;
};
// @lc code=end
