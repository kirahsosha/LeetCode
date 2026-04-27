/*
 * @lc app=leetcode.cn id=2033 lang=typescript
 *
 * [2033] 获取单值网格的最小操作数
 */

// @lc code=start
function minOperations(grid: number[][], x: number): number {
    const base: number = grid[0][0];
    const nums: number[] = [];
    
    for (const row of grid) {
        for (const num of row) {
            if ((num - base) % x !== 0) {
                return -1;
            }
            nums.push(num);
        }
    }
    
    nums.sort((a: number, b: number) => a - b);
    const median: number = nums[nums.length >> 1];
    let ans: number = 0;
    
    for (const num of nums) {
        ans += Math.abs(num - median) / x;
    }
    
    return ans;
};
// @lc code=end
