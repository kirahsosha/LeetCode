/*
 * @lc app=leetcode.cn id=3300 lang=java
 *
 * [3300] 替换为数位和以后的最小元素
 */
// @lc code=start
class Solution {

    public int minElement(int[] nums) {
        int ans = Integer.MAX_VALUE;
        for (int num : nums) {
            int sum = 0;
            for (int x = num; x > 0; x /= 10) {
                sum += x % 10;
            }

            if (sum < ans) {
                ans = sum;
            }
        }

        return ans;
    }
}
// @lc code=end
