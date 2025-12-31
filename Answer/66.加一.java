/*
 * @lc app=leetcode.cn id=66 lang=java
 *
 * [66] 加一
 */

// @lc code=start
class Solution {

    public int[] plusOne(int[] digits) {
        var n = digits.length;
        if (n == 1 && digits[0] == 0) {
            digits[0] = 1;
            return digits;
        }
        int t = 1;
        for (int i = n - 1; i >= 0; i--) {
            digits[i] += t;
            t = 0;
            if (digits[i] == 10) {
                digits[i] = 0;
                t = 1;
            }
            if (t == 0) {
                break;
            }
        }
        if (t == 1) {
            int[] a = new int[n + 1];
            a[0] = 1;
            System.arraycopy(digits, 0, a, 1, n);
            return a;
        } else {
            return digits;
        }
    }
}
// @lc code=end

