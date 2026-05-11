/*
 * @lc app=leetcode.cn id=2553 lang=csharp
 *
 * [2553] 分割数组中数字的数位
 */

// @lc code=start
public class Solution {
    public int[] SeparateDigits(int[] nums) {
        int total = 0;
        foreach (int num in nums) {
            for (int x = num; x > 0; x /= 10) {
                total++;
            }
        }
        int[] ans = new int[total];
        int idx = 0;
        // C# 特性：stackalloc 在栈上分配小缓冲区，零 GC 开销
        Span<int> buf = stackalloc int[6];
        foreach (int num in nums) {
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
