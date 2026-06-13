using System.Text;

/*
 * @lc app=leetcode.cn id=3838 lang=csharp
 *
 * [3838] 带权单词映射
 */

// @lc code=start
public class Solution {
    public string MapWordWeights(string[] words, int[] weights) {
        var sb = new StringBuilder(words.Length);
        foreach (string word in words) {
            int w = 0;
            for (int i = 0; i < word.Length; i++) {
                w = (w + weights[word[i] - 'a']) % 26;
            }
            sb.Append((char)('a' + 25 - w));
        }
        return sb.ToString();
    }
}
// @lc code=end
