/*
 * @lc app=leetcode.cn id=2144 lang=java
 *
 * [2144] 打折购买糖果的最小开销
 */

// @lc code=start
import java.util.Arrays;

class Solution {

    public int minimumCost(int[] cost) {
        Arrays.sort(cost);
        int totalCost = 0;
        for (int i = cost.length - 1; i >= 0; i -= 3) {
            totalCost += cost[i];
            if (i > 0) {
                totalCost += cost[i - 1];
            }
        }
        return totalCost;
    }
}
// @lc code=end
