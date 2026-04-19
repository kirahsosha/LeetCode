/*
 * @lc app=leetcode.cn id=1855 lang=csharp
 *
 * [1855] 下标对中的最大距离
 */

// @lc code=start
public class Solution {
    public int MaxDistance(int[] nums1, int[] nums2) {
        int i = 0, ans = 0;
        for (int j = 0; j < nums2.Length; j++) {
            while (i < nums1.Length && nums1[i] > nums2[j]) {
                i++;
            }
            if (i == nums1.Length) {
                break;
            }
            ans = Math.Max(ans, j - i);
        }
        return ans;
    }
}
// @lc code=end
