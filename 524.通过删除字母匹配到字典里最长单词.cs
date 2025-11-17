/*
 * @lc app=leetcode.cn id=524 lang=csharp
 *
 * [524] 通过删除字母匹配到字典里最长单词
 */

// @lc code=start
public class Solution {
    public bool checkString(string s, string c)
    {
        int index = 0;
        for(int i = 0; i < s.Length; i++)
        {
            if(s[i] == c[index]) index++;
            if(index == c.Length) return true;
        }
        return false;
    }

    public string FindLongestWord(string s, IList<string> d) {
        string maxString = string.Empty;
        foreach(string temp in d)
        {
            if(temp.Length == maxString.Length && string.Compare(temp, maxString) == -1 && checkString(s, temp))
            {
                maxString = temp;
            }
            else if(temp.Length > maxString.Length && checkString(s, temp))
            {
                maxString = temp;
            }
        }
        return maxString;
    }
}
// @lc code=end

