/*
 * @lc app=leetcode.cn id=693 lang=java
 *
 * [693] 交替位二进制数
 */

// @lc code=start
class Solution {
    public boolean hasAlternatingBits(int n) {
        var a = n ^ (n >> 1);
        var b = a + 1;
        return (a & b) == 0;
    }
}
// @lc code=end
