/*
 * @lc app=leetcode.cn id=68 lang=csharp
 *
 * [68] 文本左右对齐
 */

// @lc code=start
public class Solution {
    public string getStr(string[] words, int maxWidth, int s, int e)
    {
        string s = "";



        return s;
    }
    
    public string getLastStr(string[] words, int maxWidth, int s, int e)
    {
        string s = "";



        return s;
    }

    public IList<string> FullJustify(string[] words, int maxWidth) {
        int length = words[0].Length;
        int k = 0;
        IList<string> ans = new List<string>();
        for(int i = 1; i < words.Count(); i++)
        {
            if(length + words[i].Length > maxWidth)
            {
                //从k开始到i-1的单词放一行
                ans.Add(getStr(words, maxWidth, k, i - 1));
                length = words[i].Length;
                k = i;
            }
            else
            {
                length += words[i].Length
            }
        }
        //最后一行
        if(length > 0)
        {
            ans.Add(getStr(words, maxWidth, k, words.Count() - 1));
        }
        return ans;
    }
}
// @lc code=end

