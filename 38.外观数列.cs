/*
 * @lc app=leetcode.cn id=38 lang=csharp
 *
 * [38] 外观数列
 */

// @lc code=start
public class Solution {
    public string CountAndSay(int n)
        {
            return GetArray(1, n, "1");
        }

        public string GetArray(int index, int n, string s)
        {
            if (index == n) return s;
            int cnt = 1;
            string ans = "";
            for (int i = 0; i < s.Length - 1; i++)
            {
                if (s[i] == s[i + 1])
                {
                    cnt++;
                }
                else
                {
                    ans = ans + cnt + s[i];
                    cnt = 1;
                }
            }
            ans = ans + cnt + s[s.Length - 1];
            return GetArray(index + 1, n, ans);
        }
}
// @lc code=end

