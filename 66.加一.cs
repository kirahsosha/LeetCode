/*
 * @lc app=leetcode.cn id=66 lang=csharp
 *
 * [66] 加一
 */

// @lc code=start
public class Solution {
    public int[] PlusOne(int[] digits) {
        if (digits.Length == 0)
		{
			int[] a = new int[] { 1 };
			return a;
		}
		if (digits.Length == 1 && digits[0] == 0)
		{
			digits[0] = 1;
			return digits;
		}
		int t = 1;
		for (int i = digits.Length - 1; i >= 0; i--)
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
			int[] a = new int[digits.Length + 1];
			a[0] = 1;
			for (int i = 0; i < digits.Length; i++)
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
}
// @lc code=end

