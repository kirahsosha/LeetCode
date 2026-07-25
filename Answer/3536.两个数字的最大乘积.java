/*
 * @lc app=leetcode.cn id=3536 lang=java
 *
 * [3536] 两个数字的最大乘积
 */

// @lc code=start
class Solution {
    public int maxProduct(int n) {
        int digit = 0;
        int ans = 0;
        while (n > 0) {
            int d = n % 10;
            ans = Math.max(ans, d * digit);
            digit = Math.max(digit, d);
            n /= 10;
        }
        return ans;
    }
}
// @lc code=end
