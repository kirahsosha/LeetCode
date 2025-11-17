/*
 * @lc app=leetcode.cn id=824 lang=csharp
 *
 * [824] 山羊拉丁文
 */

// @lc code=start
public class Solution {
    public string ToGoatLatin(string S) {
        if(S == " " || S == "") return "";
        string[] words = S.Split(' ');
        string a = "a";
        for(int i = 0; i < words.Length; i++)
        {
            char t = words[i][0];
            if(t == 'a' || t == 'e' || t == 'i' || t == 'o' || t == 'u' 
            || t == 'A' || t == 'E' || t == 'I' || t == 'O' || t == 'U')
            {
                words[i] += "ma" + a;
            }
            else
            {
                words[i] = words[i].Substring(1) + t + "ma" + a;
            }
            a += "a";
        }
        S = string.Empty;
        for(int i= 0; i < words.Length; i++)
        {
            S += words[i] + " ";
        }
        S = S.Trim();
        return S;
    }
}
// @lc code=end

