/*
 * @lc app=leetcode.cn id=2515 lang=java
 *
 * [2515] 到目标字符串的最短距离
 */

// @lc code=start
class Solution {
    public int closestTarget(String[] words, String target, int startIndex) {
        int n = words.length;
        for (int i = 0; i < n / 2 + 1; i++) {
            if (words[(startIndex + i) % n].equals(target) || words[(startIndex - i + n) % n].equals(target)) {
                return i;
            }
        }
        return -1;
    }
}
// @lc code=end

