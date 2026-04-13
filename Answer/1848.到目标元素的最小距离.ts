/*
 * @lc app=leetcode.cn id=1848 lang=typescript
 *
 * [1848] 到目标元素的最小距离
 */

// @lc code=start
function getMinDistance(nums: number[], target: number, start: number): number {
    const n: number = nums.length;
    let left: number = start, right: number = start;
    
    // 向两边扩散查找
    while (left >= 0 || right < n) {
        if (left >= 0 && nums[left] === target) {
            return start - left;
        }
        if (right < n && nums[right] === target) {
            return right - start;
        }
        left--;
        right++;
    }
    
    return -1;
};
// @lc code=end
