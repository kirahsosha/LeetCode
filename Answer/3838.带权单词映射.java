/*
 * @lc app=leetcode.cn id=3838 lang=java
 *
 * [3838] 带权单词映射
 */

// @lc code=start
class Solution {

    public String mapWordWeights(String[] words, int[] weights) {
        var sb = new StringBuilder(words.length);
        for (String word : words) {
            var w = 0;
            for (var i = 0; i < word.length(); i++) {
                w = (w + weights[word.charAt(i) - 'a']) % 26;
            }
            sb.append((char) ('a' + 25 - w));
        }
        return sb.toString();
    }
}
// @lc code=end
