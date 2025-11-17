/*
 * @lc app=leetcode.cn id=67 lang=cpp
 *
 * [67] 二进制求和
 */

// @lc code=start
class Solution {
public:
	int CtoI(char c)
	{
		if (c == '1') return 1;
		return 0;
	}
	
	char ItoC(int i)
	{
		if (i == 1) return '1';
		return '0';
	}
	
    string addBinary(string a, string b) {
		string s;
		if (b.length() > a.length())
		{
			s = a;
			a = b;
			b = s;
		}
		int len = a.length() - b.length();
		int aa = 0, t = 0;
		for (int i = b.length() - 1; i >= 0; i--)
		{
			aa = CtoI(a[i + len]) + CtoI(b[i]) + t;
			if (aa > 1)
			{
				t = 1;
				aa -= 2;
			}
			else
			{
				t = 0;
			}
			a[i + len] = ItoC(aa);
		}
		for (int i = len - 1; i >= 0; i--)
		{
			aa = CtoI(a[i]) + t;
			if (aa > 1)
			{
				t = 1;
				aa -= 2;
			}
			else
			{
				t = 0;
			}
			a[i] = ItoC(aa);
		}
		if (t == 1)
		{
			a = "1" + a;
		}
		return a;
    }
};
// @lc code=end

