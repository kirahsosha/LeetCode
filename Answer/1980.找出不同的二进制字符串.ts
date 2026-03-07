/*
 * @lc app=leetcode.cn id=1980 lang=typescript
 *
 * [1980] 找出不同的二进制字符串
 */

// @lc code=start
function findDifferentBinaryString(nums: string[]): string {
    var n = nums.length;
    var res = "";
    for (var i = 0; i < n; i++) {
        res += nums[i].charAt(i) == '0' ? '1' : '0';
    }
    return res;
};
// @lc code=end

