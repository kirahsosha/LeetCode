/*
 * @lc app=leetcode.cn id=1288 lang=java
 *
 * [1288] 删除被覆盖区间
 */

import java.util.Arrays;

// @lc code=start
class Solution {
    public int removeCoveredIntervals(int[][] intervals) {
        Arrays.sort(intervals, (a, b) -> {
            return a[0] != b[0] ? a[0] - b[0] : b[1] - a[1];
        });

        int ans = 0;
        int end = 0;
        for (int[] it : intervals) {
            if (it[1] > end) {
                ans++;
                end = it[1];
            }
        }
        return ans;
    }
}
// @lc code=end
