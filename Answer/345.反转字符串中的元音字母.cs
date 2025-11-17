/*
 * @lc app=leetcode.cn id=345 lang=csharp
 *
 * [345] 反转字符串中的元音字母
 */

// @lc code=start
public class Solution {
    public string ReverseVowels(string s) {
        if(s.Length == 1) return s;
        int l = 0;
        int r = s.Length - 1;
        char[] arr = s.ToCharArray();
        while(l < r)
        {
            if(s[l] != 'a' && s[l] != 'e' && s[l] != 'i' && s[l] != 'o' && s[l] != 'u'
                && s[l] != 'A' && s[l] != 'E' && s[l] != 'I' && s[l] != 'O' && s[l] != 'U')
            {
                l++;
            }
            else if(s[r] != 'a' && s[r] != 'e' && s[r] != 'i' && s[r] != 'o' && s[r] != 'u'
                && s[r] != 'A' && s[r] != 'E' && s[r] != 'I' && s[r] != 'O' && s[r] != 'U')
            {
                r--;
            }
            else if(s[l] == s[r])
            {
                l++;
                r--;
            }
            else
            {
                char c = arr[l];
                arr[l] = arr[r];
                arr[r] = c;
                l++;
                r--;
            }
        }
        return new string(arr);
    }
}
// @lc code=end

