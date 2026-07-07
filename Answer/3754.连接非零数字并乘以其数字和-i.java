/*
 * @lc app=leetcode.cn id=3754 lang=java
 *
 * [3754] 连接非零数字并乘以其数字和 I
 */

// @lc code=start
class Solution {

    public long sumAndMultiply(int n) {
        var x = 0;
        var pow = 1;
        var sum = 0;
        while (n > 0) {
            var d = n % 10;
            if (d != 0) {
                x += d * pow;
                pow *= 10;
                sum += d;
            }
            n /= 10;
        }
        return (long) x * sum;
    }
}
// @lc code=end
