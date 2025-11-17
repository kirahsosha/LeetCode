/*
 * @lc app=leetcode.cn id=400 lang=csharp
 *
 * [400] 第 N 位数字
 */

// @lc code=start
public class Solution {
    public int FindNthDigit(int n) {
        int[] length = new int[] { 0, 9, 189, 2889, 38889, 488889, 5888889, 68888889, 788888889, 2147483647 };
        int t = 0;
        while (t <= 8 && n > length[t])
        {
            t++;
        }
        int p = (n - length[t - 1] - 1) / t + (int)Math.Pow(10, t - 1);
        int q = (n - length[t - 1] - 1) % t;
        //long ans = (long)Math.Pow(10, t) - p - 1;

        return (int)p.ToString()[q] - 48;
    }
}
// @lc code=end

