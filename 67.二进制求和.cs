/*
 * @lc app=leetcode.cn id=67 lang=csharp
 *
 * [67] 二进制求和
 */

// @lc code=start
public class Solution {
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

    public string AddBinary(string a, string b) {
        string s;
		if (b.Length > a.Length)
		{
			s = a;
			a = b;
			b = s;
		}
        char[] c = new char[a.Length];
		int len = a.Length - b.Length;
		int aa = 0, t = 0;
		for (int i = b.Length - 1; i >= 0; i--)
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
			c[i + len] = ItoC(aa);
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
			c[i] = ItoC(aa);
		}
        s = new string(c);
		if (t == 1)
		{
			s = "1" + s;
		}
		return s;
    }
}
// @lc code=end

