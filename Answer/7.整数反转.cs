/*
 * @lc app=leetcode.cn id=7 lang=csharp
 *
 * [7] 整数反转
 */

// @lc code=start
public class Solution {
    public int Reverse(int x)
    {
        int[] d = new int[10] {0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
        int len = 0;
        if (x == 0) return 0;
        if (x == Int32.MinValue) return 0;
        long y = 0;
        while (x != 0)
        {
            d[len] = x % 10;
            x /= 10;
            len++;
        }

        for (int i = 0; i < len; i++)
        {
            y = y * 10 + d[i];
        }

        if (y < Int32.MinValue || y > Int32.MaxValue)
        {
            return 0;
        }

        x = (int) y;
        return x;
    }
}
// @lc code=end

