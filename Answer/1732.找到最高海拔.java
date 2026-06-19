/*
 * @lc app=leetcode.cn id=1732 lang=java
 *
 * [1732] 找到最高海拔
 */

// @lc code=start
class Solution {

    public int largestAltitude(int[] gain) {
        int max = 0;
        int cur = 0;
        for (int g : gain) {
            cur += g;
            max = Math.max(max, cur);
        }
        return max;
    }
}
// @lc code=end

