/*
 * @lc app=leetcode.cn id=50 lang=csharp
 *
 * [50] Pow(x, n)
 */

// @lc code=start
public class Solution {
    public double dPow(double x, long m)
    {
        long k = m % 2;
        m = m / 2;
        if(m == 0) return (k == 1 ? x : 1);
        double t = dPow(x, m);
        return t * t * (k == 1 ? x : 1);
    }

    public double MyPow(double x, int n) {
        if(n == 0) return 1;
        if(x == 0) return 0;
        x = n > 0 ? x : 1 / x;
        long m = Math.Abs((long)n);
        return dPow(x, m);
    }
}
// @lc code=end

