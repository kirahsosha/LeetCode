/*
 * @lc app=leetcode.cn id=14 lang=csharp
 *
 * [14] 最长公共前缀
 */

// @lc code=start
public class Solution {
    public string LongestCommonPrefix(string[] strs) {
        int num = strs.Length;
        if(num == 0) return "";
        if(num == 1) return strs[0];
        int len = strs[0].Length;
        string s = "";
        for(int i = 0; i < len; i++)
        {
            for(int j = 1; j < num; j++)
            {
                if(i >= strs[j].Length || strs[0][i] != strs[j][i])
                {
                    return s;
                }
            }
            s = s + strs[0][i];
        }
        return s;
    }
}
// @lc code=end

