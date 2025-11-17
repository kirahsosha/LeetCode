/*
 * @lc app=leetcode.cn id=392 lang=csharp
 *
 * [392] 判断子序列
 */

// @lc code=start
public class Solution {
    //后续挑战
    //预处理 计算t的每个字符后每个字母首次出现的位置dp[t.Length + 1][26]
    //状态转移 s的每个字符在dp中顺次查找
    public bool IsSubsequence(string s, string t) {
        if(s.Length == 0) return true;
        if(t.Length == 0) return false;
        if(s.Length > t.Length) return false;
        int p1 = 0, p2 = p1;
        while(p1 < t.Length)
        {
            //查找检索起点
            if(t[p1] != s[0])
            {
                p1++;
                continue;
            }
            p2 = p1 + 1;
            int p3 = 1;
            //顺序查找后续字符
            while(p2 < t.Length && p3 < s.Length)
            {
                if(t[p2] == s[p3])
                {
                    p2++;
                    p3++;
                }
                else
                {
                    p2++;
                }
            }
            if(p3 == s.Length) return true;
            p1++;
        }
        return false;
    }
}
// @lc code=end

