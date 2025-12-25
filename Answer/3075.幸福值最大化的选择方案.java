/*
 * @lc app=leetcode.cn id=3075 lang=java
 *
 * [3075] 幸福值最大化的选择方案
 */

// @lc code=start

import java.util.Arrays;

class Solution {
    public long maximumHappinessSum(int[] happiness, int k) {
        Integer[] arr = Arrays.stream(happiness).boxed().toArray(Integer[]::new);
        Arrays.sort(arr, (a, b) -> b - a);
        long res = 0;
        for (int i = 0; i < k; i++) {
            res += Math.max(0, arr[i] - i);
        }
        return res;
    }
}
// @lc code=end
