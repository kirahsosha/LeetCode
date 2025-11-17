/*
 * @lc app=leetcode.cn id=1935 lang=csharp
 *
 * [1935] 可以输入的最大单词数
 */

// @lc code=start
public class Solution {
    public int CanBeTypedWords(string text, string brokenLetters)
    {
        var texts = text.Split(" ");
        if (texts.Length == 0) return 0;
        int res = texts.Length;
        foreach (var t in texts)
        {
            foreach (var c in t)
            {
                if (brokenLetters.Contains(c))
                {
                    res--;
                    break;
                }
            }
        }
        return res;
    }
}
// @lc code=end

