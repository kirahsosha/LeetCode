/*
 * @lc app=leetcode.cn id=1980 lang=java
 *
 * [1980] 找出不同的二进制字符串
 */

// @lc code=start
class Solution {

    public String findDifferentBinaryString(String[] nums) {
        var n = nums.length;
        var res = new char[n];
        for (var i = 0; i < n; i++) {
            res[i] = nums[i].charAt(i) == '0' ? '1' : '0';
        }
        return new String(res);
    }
}
// @lc code=end

