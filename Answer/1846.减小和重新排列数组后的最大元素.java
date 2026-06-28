/*
 * @lc app=leetcode.cn id=1846 lang=java
 *
 * [1846] 减小和重新排列数组后的最大元素
 */

import java.util.Arrays;

// @lc code=start
class Solution {
    public int maximumElementAfterDecrementingAndRearranging(int[] arr) {
        Arrays.sort(arr);
        int prev = 0;
        for (int x : arr) {
            prev = Math.min(x, prev + 1);
        }
        return prev;
    }
}
// @lc code=end
