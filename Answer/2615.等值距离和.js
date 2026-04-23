/*
 * @lc app=leetcode.cn id=2615 lang=javascript
 *
 * [2615] 等值距离和
 */

// @lc code=start
/**
 * @param {number[]} nums
 * @return {number[]}
 */
var distance = function(nums) {
    const n = nums.length;
    const ans = new Array(n).fill(0);

    // 从左向右：计算每个位置左侧同值元素的距离和
    const cnt = new Map();
    const sum = new Map();
    for (let i = 0; i < n; i++) {
        const c = cnt.get(nums[i]) ?? 0;
        const s = sum.get(nums[i]) ?? 0;
        ans[i] = i * c - s;
        cnt.set(nums[i], c + 1);
        sum.set(nums[i], s + i);
    }

    // 从右向左：计算每个位置右侧同值元素的距离和并累加
    cnt.clear();
    sum.clear();
    for (let i = n - 1; i >= 0; i--) {
        const c = cnt.get(nums[i]) ?? 0;
        const s = sum.get(nums[i]) ?? 0;
        ans[i] += s - i * c;
        cnt.set(nums[i], c + 1);
        sum.set(nums[i], s + i);
    }

    return ans;
};
// @lc code=end
