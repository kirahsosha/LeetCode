/*
 * @lc app=leetcode.cn id=3120 lang=java
 *
 * [3120] 统计特殊字母的数量 I
 */

// @lc code=start
class Solution {

    public int numberOfSpecialChars(String word) {
        int lowerMask = 0;
        int upperMask = 0;
        for (int i = 0; i < word.length(); i++) {
            char c = word.charAt(i);
            if (c >= 'a' && c <= 'z') {
                lowerMask |= 1 << (c - 'a');
            } else if (c >= 'A' && c <= 'Z') {
                upperMask |= 1 << (c - 'A');
            }
        }

        int common = lowerMask & upperMask;
        int ans = 0;
        while (common > 0) {
            ans += common & 1;
            common >>= 1;
        }
        return ans;
    }
}
// @lc code=end
