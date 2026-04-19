/*
 * @lc app=leetcode.cn id=1855 lang=java
 *
 * [1855] 下标对中的最大距离
 */

// @lc code=start
class Solution {
    public int maxDistance(int[] nums1, int[] nums2) {
        int i = 0, ans = 0;
        for (int j = 0; j < nums2.length; j++) {
            while (i < nums1.length && nums1[i] > nums2[j]) {
                i++;
            }
            if (i == nums1.length) {
                break;
            }
            ans = Math.max(ans, j - i);
        }
        return ans;
    }
}
// @lc code=end
