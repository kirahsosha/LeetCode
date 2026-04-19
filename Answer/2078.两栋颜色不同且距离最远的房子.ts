/*
 * @lc app=leetcode.cn id=2078 lang=typescript
 *
 * [2078] 两栋颜色不同且距离最远的房子
 */

// @lc code=start
function maxDistance(colors: number[]): number {
    const n = colors.length;
    let left = 0;
    while (left < n && colors[left] === colors[n - 1]) {
        left++;
    }
    if (left === n) {
        return 0;
    }
    let right = n - 1;
    while (right >= 0 && colors[right] === colors[0]) {
        right--;
    }
    return Math.max(n - 1 - left, right);
}
// @lc code=end

