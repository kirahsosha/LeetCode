/*
 * @lc app=leetcode.cn id=1189 lang=csharp
 *
 * [1189] “气球” 的最大数量
 */

// @lc code=start
public class Solution {
    public int MaxNumberOfBalloons(string text) {
        int[] cnt = new int[26];
        foreach (char c in text) {
            cnt[c - 'a']++;
        }
        return Math.Min(
            Math.Min(
                Math.Min(cnt['b' - 'a'], cnt['a' - 'a']),
                cnt['l' - 'a'] / 2
            ),
            Math.Min(cnt['o' - 'a'] / 2, cnt['n' - 'a'])
        );
    }
}
// @lc code=end
