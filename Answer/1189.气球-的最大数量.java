/*
 * @lc app=leetcode.cn id=1189 lang=java
 *
 * [1189] “气球” 的最大数量
 */

// @lc code=start
class Solution {
    public int maxNumberOfBalloons(String text) {
        int[] count = new int[26];
        for (char c : text.toCharArray()) {
            count[c - 'a']++;
        }
        return Math.min(
            Math.min(
                Math.min(count['b' - 'a'], count['a' - 'a']),
                count['l' - 'a'] / 2
            ),
            Math.min(count['o' - 'a'] / 2, count['n' - 'a'])
        );
    }
}
// @lc code=end
