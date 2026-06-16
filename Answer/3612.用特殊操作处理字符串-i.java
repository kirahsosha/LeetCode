/*
 * @lc app=leetcode.cn id=3612 lang=java
 *
 * [3612] 用特殊操作处理字符串 I
 */

// @lc code=start
class Solution {

    public String processStr(String s) {
        StringBuilder sb = new StringBuilder();
        for (char ch : s.toCharArray()) {
            if (ch == '*' && sb.length() > 0) {
                sb.deleteCharAt(sb.length() - 1);
            } else if (ch == '#') {
                sb.append(sb);
            } else if (ch == '%') {
                sb.reverse();
            } else if (ch >= 'a' && ch <= 'z') {
                sb.append(ch);
            }
        }
        return sb.toString();
    }
}
// @lc code=end
