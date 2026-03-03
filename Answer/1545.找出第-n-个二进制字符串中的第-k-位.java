/*
 * @lc app=leetcode.cn id=1545 lang=java
 *
 * [1545] 找出第 N 个二进制字符串中的第 K 位
 */

// @lc code=start
class Solution {

    public char findKthBit(int n, int k) {
        if (k % 2 > 0) {
            //奇数
            return (char) ('0' + k / 2 % 2);
        } else {
            //偶数
            k /= k & -k; // 去掉 k 的尾零
            return (char) ('1' - k / 2 % 2);
        }
    }
}
// @lc code=end

