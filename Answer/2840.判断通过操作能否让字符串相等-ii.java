/*
 * @lc app=leetcode.cn id=2840 lang=java
 *
 * [2840] 判断通过操作能否让字符串相等 II
 */

// @lc code=start
class Solution {
    public boolean checkStrings(String s1, String s2) {
        int[][] cnt1 = new int[2][26], cnt2 = new int[2][26];
        for (int i = 0; i < s1.length(); i++) {
            cnt1[i % 2][s1.charAt(i) - 'a']++;
            cnt2[i % 2][s2.charAt(i) - 'a']++;
        }

        for (int p = 0; p < 2; p++) {
            for (int c = 0; c < 26; c++) {
                if (cnt1[p][c] != cnt2[p][c]) {
                    return false;
                }
            }
        }

        return true;
    }
}
// @lc code=end

