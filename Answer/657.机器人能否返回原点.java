/*
 * @lc app=leetcode.cn id=657 lang=java
 *
 * [657] 机器人能否返回原点
 */

// @lc code=start
class Solution {

    public boolean judgeCircle(String moves) {
        var ver = 0;
        var hor = 0;
        for (char move : moves.toCharArray()) {
            switch (move) {
                case 'U':
                    ver++;
                    break;
                case 'D':
                    ver--;
                    break;
                case 'L':
                    hor--;
                    break;
                case 'R':
                    hor++;
                    break;
                default:
                    throw new AssertionError();
            }
        }
        return ver == 0 && hor == 0;
    }
}
// @lc code=end

