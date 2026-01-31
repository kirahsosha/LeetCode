/*
 * @lc app=leetcode.cn id=744 lang=java
 *
 * [744] 寻找比目标字母大的最小字母
 */

// @lc code=start
class Solution {

    public char nextGreatestLetter(char[] letters, char target) {
        var index = 0;
        for (var i = 0; i < letters.length; i++) {
            if (letters[i] > target) {
                index = i;
                break;
            }
        }
        return letters[index];
    }
}
// @lc code=end

