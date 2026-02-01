/*
 * @lc app=leetcode.cn id=3010 lang=java
 *
 * [3010] 将数组分成最小总代价的子数组 I
 */

// @lc code=start
class Solution {

    public int minimumCost(int[] nums) {
        var n1 = nums[0];
        var n2 = Integer.MAX_VALUE;
        var n3 = Integer.MAX_VALUE;
        for (int i = 1; i < nums.length; i++) {
            if (nums[i] < n2) {
                n3 = n2;
                n2 = nums[i];
            } else if (nums[i] < n3) {
                n3 = nums[i];
            }
        }
        return n1 + n2 + n3;
    }
}
// @lc code=end

