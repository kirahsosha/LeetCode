/*
 * @lc app=leetcode.cn id=66 lang=cpp
 *
 * [66] 加一
 */

// @lc code=start
class Solution {
public:
    vector<int> plusOne(vector<int>& digits) {
		if (digits.size() == 0)
		{
			vector<int> a = { 1 };
			return a;
		}
		if (digits.size() == 1 && digits[0] == 0)
		{
			digits[0] = 1;
			return digits;
		}
		int t = 1;
		for (int i = digits.size() - 1; i >= 0; i--)
		{
			digits[i] += t;
			t = 0;
			if (digits[i] == 10)
			{
				digits[i] = 0;
				t = 1;
			}
		}
		if (t == 1)
		{
			vector<int> a(digits.size() + 1);
			a[0] = 1;
			for (int i = 0; i < digits.size(); i++)
			{
				a[i + 1] = digits[i];
			}
			return a;
		}
		else
		{
			return digits;
		}
    }
};
// @lc code=end

