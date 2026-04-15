/*
 * @lc app=leetcode.cn id=2515 lang=csharp
 *
 * [2515] 到目标字符串的最短距离
 */

// @lc code=start
public class Solution {
    public int ClosestTarget(string[] words, string target, int startIndex) {
        int n = words.Length;
        for (int i = 0; i < n / 2 + 1; i++) {
            if (words[(startIndex + i) % n] == target || words[(startIndex - i + n) % n] == target) {
                return i;
            }
        }
        return -1;
    }
}
// @lc code=end

