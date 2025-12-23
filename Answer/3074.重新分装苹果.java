/*
 * @lc app=leetcode.cn id=3074 lang=java
 *
 * [3074] 重新分装苹果
 */

// @lc code=start

import java.util.Arrays;

class Solution {
    public int minimumBoxes(int[] apple, int[] capacity) {
        var apples = 0;
        for (var appleCount : apple) {
            apples += appleCount;
        }
        Arrays.sort(capacity);
        var res = 0;
        for (int i = capacity.length - 1; i >= 0; i--) {
            apples -= capacity[i];
            res++;
            if (apples <= 0) {
                break;
            }
        }
        return res;
    }
}
// @lc code=end
