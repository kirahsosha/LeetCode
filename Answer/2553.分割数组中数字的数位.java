/*
 * @lc app=leetcode.cn id=2553 lang=java
 *
 * [2553] 分割数组中数字的数位
 */

// @lc code=start
class Solution {
    public int[] separateDigits(int[] nums) {
        // 先计算总位数，一次分配精确长度的数组
        int total = 0;
        for (int num : nums) {
            for (int x = num; x > 0; x /= 10) {
                total++;
            }
        }
        int[] ans = new int[total];
        int idx = 0;
        // 复用固定长度临时数组，避免频繁创建对象
        int[] buf = new int[6];
        for (int num : nums) {
            int n = 0;
            for (int x = num; x > 0; x /= 10) {
                buf[n++] = x % 10;
            }
            for (int i = n - 1; i >= 0; i--) {
                ans[idx++] = buf[i];
            }
        }
        return ans;
    }
}
// @lc code=end
