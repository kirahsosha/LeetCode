/*
 * @lc app=leetcode.cn id=2770 lang=javascript
 *
 * [2770] 达到末尾下标所需的最大跳跃次数
 */

// @lc code=start
/**
 * @param {number[]} nums
 * @param {number} target
 * @return {number}
 */
var maximumJumps = function(nums, target) {
    const n = nums.length;
    const dp = new Array(n).fill(-1);
    dp[0] = 0;
    
    for (let i = 1; i < n; i++) {
        for (let j = 0; j < i; j++) {
            const d = nums[i] - nums[j];
            if (d <= target && d >= -target && dp[j] !== -1) {
                dp[i] = Math.max(dp[i], dp[j] + 1);
            }
        }
    }
    
    return dp[n - 1];
};
// @lc code=end
