/*
 * @lc app=leetcode.cn id=1967 lang=java
 *
 * [1967] 作为子字符串出现在单词中的字符串数目
 */

// @lc code=start
class Solution {
    public int numOfStrings(String[] patterns, String word) {
        int ans = 0;
        for (String p : patterns) {
            if (word.contains(p)) {
                ans++;
            }
        }
        return ans;
    }
}
// @lc code=end
