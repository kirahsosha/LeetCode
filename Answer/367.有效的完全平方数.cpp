/*
 * @lc app=leetcode.cn id=367 lang=cpp
 *
 * [367] 有效的完全平方数
 */

// @lc code=start
class Solution {
public:
    int div(int x, int m, int l, int r)
	{
		long a = x, b = m;
		if (a >= b * b && x < (b + 1) * (b + 1))
		{
			return m;
		}
		if (a > b * b)
		{
			return div(x, (m + r) / 2, m, r);
		}
		else
		{
			return div(x, (l + m) / 2, l, m);
		}
	}
	
    int mySqrt(int x) {
		if (x < 4) return 1;
		return div(x, x / 2, 1, x);
    }

    bool isPerfectSquare(int num) {
        if(num < 1) return false;
        int n = mySqrt(num);
        if(n * n == num) return true;
        return false;
    }
};
// @lc code=end

