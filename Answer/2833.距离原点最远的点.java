/*
 * @lc app=leetcode.cn id=2833 lang=java
 *
 * [2833] 距离原点最远的点
 */

// @lc code=start
class Solution {

    public int furthestDistanceFromOrigin(String moves) {
        int left = 0, right = 0;
        for (char c : moves.toCharArray()) {
            switch (c) {
                case 'L' -> {
                    left++;
                    right--;
                }
                case 'R' -> {
                    right++;
                    left--;
                }
                default -> {
                    left++;
                    right++;
                }
            }
        }
        return Math.max(left, right);
    }
}
// @lc code=end

