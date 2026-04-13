/*
 * @lc app=leetcode.cn id=1848 lang=java
 *
 * [1848] 到目标元素的最小距离
 */

// @lc code=start
class Solution {
    public int getMinDistance(int[] nums, int target, int start) {
        int n = nums.length;
        int left = start, right = start;
        
        // 向两边扩散查找
        while (left >= 0 || right < n) {
            if (left >= 0 && nums[left] == target) {
                return start - left;
            }
            if (right < n && nums[right] == target) {
                return right - start;
            }
            left--;
            right++;
        }
        
        return -1;
    }
}
// @lc code=end
