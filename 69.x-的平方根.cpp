/*
 * @lc app=leetcode.cn id=69 lang=cpp
 *
 * [69] x 的平方根
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
		if (x == 0) return 0;
		if (x < 4) return 1;
		return div(x, x / 2, 1, x);
    }
};
// @lc code=end

