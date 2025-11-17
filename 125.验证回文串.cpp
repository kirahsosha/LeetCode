/*
 * @lc app=leetcode.cn id=125 lang=cpp
 *
 * [125] 验证回文串
 */

// @lc code=start
class Solution {
public:
    bool isPalindrome(string s) {
		if (s == "") return true;
		if (s.length() == 1) return true;
		int i = 0, j = s.length() - 1;
		while(i <= j)
		{
			if(s[i] < 48 ||
			  (s[i] > 57 && s[i] < 65) ||
			  (s[i] > 90 && s[i] < 97) ||
			   s[i] > 122)
			{
				i++;
				continue;
			}
			if(s[j] < 48 ||
			  (s[j] > 57 && s[j] < 65) ||
			  (s[j] > 90 && s[j] < 97) ||
			   s[j] > 122)
			{
				j--;
				continue;
			}
			if(s[i] >= 65 && s[i] <= 90)//Upper letter
			{
				if(s[j] == s[i] || s[j] == s[i] + 32)
				{
					i++;
					j--;
					continue;
				}
				return false;
			}
			else if(s[i] >= 97 && s[i] <= 122)//Lower letter
			{
				if(s[j] == s[i] || s[j] == s[i] - 32)
				{
					i++;
					j--;
					continue;
				}
				return false;
			}
			else//if(s[i] >= 48 && s[i] <= 57)//Number
			{
				if(s[j] == s[i])
				{
					i++;
					j--;
					continue;
				}
				return false;
			}
		}
		return true;
    }
};
// @lc code=end

