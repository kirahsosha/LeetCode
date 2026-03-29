/*
 * @lc app=leetcode.cn id=2839 lang=java
 *
 * [2839] 判断通过操作能否让字符串相等 I
 */

// @lc code=start
class Solution {
    public boolean canBeEqual(String s1, String s2) {
        boolean evenEqual =
            (s1.charAt(0) == s2.charAt(0) && s1.charAt(2) == s2.charAt(2)) ||
            (s1.charAt(0) == s2.charAt(2) && s1.charAt(2) == s2.charAt(0));
        boolean oddEqual =
            (s1.charAt(1) == s2.charAt(1) && s1.charAt(3) == s2.charAt(3)) ||
            (s1.charAt(1) == s2.charAt(3) && s1.charAt(3) == s2.charAt(1));

        return evenEqual && oddEqual;
    }
}
// @lc code=end

