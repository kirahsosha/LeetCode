/*
 * @lc app=leetcode.cn id=2553 lang=typescript
 *
 * [2553] 分割数组中数字的数位
 */

// @lc code=start
function separateDigits(nums: number[]): number[] {
    // 同 JS 策略：利用引擎字符串优化，join 后预分配数组再填充
    const str = nums.join('');
    const ans = new Array<number>(str.length);
    for (let i = 0; i < str.length; i++) {
        ans[i] = str.charCodeAt(i) - 48;
    }
    return ans;
}
// @lc code=end
