/*
 * @lc app=leetcode.cn id=2091 lang=java
 *
 * [2091] 从数组中移除最大值和最小值
 */

// @lc code=start
class Solution {

    public int minimumDeletions(int[] nums) {
        int n = nums.length;
        int minIndex = 0;
        int maxIndex = 0;
        for (int i = 1; i < n; i++) {
            if (nums[i] < nums[minIndex]) {
                minIndex = i;
            }
            if (nums[i] > nums[maxIndex]) {
                maxIndex = i;
            }
        }
        if (minIndex > maxIndex) {
            int temp = minIndex;
            minIndex = maxIndex;
            maxIndex = temp;
        }
        int ans = maxIndex + 1;
        ans = Math.min(ans, n - minIndex);
        ans = Math.min(ans, minIndex + 1 + n - maxIndex);
        return ans;
    }
}
// @lc code=end
