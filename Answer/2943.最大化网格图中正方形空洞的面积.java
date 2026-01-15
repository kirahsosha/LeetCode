/*
 * @lc app=leetcode.cn id=2943 lang=java
 *
 * [2943] 最大化网格图中正方形空洞的面积
 */

// @lc code=start
import java.util.Arrays;

class Solution {

    public int maximizeSquareHoleArea(int n, int m, int[] hBars, int[] vBars) {
        Arrays.sort(hBars);
        var hMax = 1;
        var left = 1;
        var right = 2;
        for (var bar : hBars) {
            if (bar == right) {
                right = bar + 1;
            } else {
                left = bar - 1;
                right = bar + 1;
            }
            hMax = Math.max(hMax, right - left);
        }

        Arrays.sort(vBars);
        var vMax = 1;
        left = 1;
        right = 2;
        for (var bar : vBars) {
            if (bar == right) {
                right = bar + 1;
            } else {
                left = bar - 1;
                right = bar + 1;
            }
            vMax = Math.max(vMax, right - left);
        }

        var l = Math.min(hMax, vMax);
        return l * l;
    }
}
// @lc code=end

