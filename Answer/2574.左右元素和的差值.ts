/*
 * @lc app=leetcode.cn id=2574 lang=typescript
 *
 * [2574] 左右元素和的差值
 */

// @lc code=start
function leftRightDifference(nums: number[]): number[] {
    let total = 0;
    for (const v of nums) {
        total += v;
    }

    let leftSum = 0;
    const ans: number[] = new Array(nums.length);
    for (let i = 0; i < nums.length; i++) {
        const diff = 2 * leftSum + nums[i] - total;
        ans[i] = diff < 0 ? -diff : diff;
        leftSum += nums[i];
    }
    return ans;
}
// @lc code=end
