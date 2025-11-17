/*
 * @lc app=leetcode.cn id=1437 lang=java
 *
 * [1437] 是否所有 1 都至少相隔 k 个元素
 */

// @lc code=start
class Solution {
    public boolean kLengthApart(int[] nums, int k) {
        int index = -1;
        for (int i = 0; i < nums.length; i++) {
            if (nums[i] == 1 && index == -1) {
                index = 0;
            } else if (nums[i] == 1 && index < k) {
                return false;
            } else if (nums[i] == 1) {
                index = 0;
            } else if (index != -1) {
                index++;
            }
        }
        return true;
    }
}
// @lc code=end

