/*
 * @lc app=leetcode.cn id=70 lang=cpp
 *
 * [70] 爬楼梯
 */

// @lc code=start
class Solution {
public:
	int climbStairs(int n) {
		if (n < 2) return 1;
		int a = 1, b = 1, c = 0;
		for (int i = 2; i <= n; i++)
		{
			c = a + b;
            b = a;
			a = c;
		}
		return a;
    }
};
// @lc code=end

