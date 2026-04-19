/*
 * @lc app=leetcode.cn id=2078 lang=csharp
 *
 * [2078] 两栋颜色不同且距离最远的房子
 */

// @lc code=start
public class Solution {
    public int MaxDistance(int[] colors) {
        int n = colors.Length;
        int left = 0;
        while (left < n && colors[left] == colors[n - 1]) {
            left++;
        }
        if (left == n) {
            return 0;
        }
        int right = n - 1;
        while (right >= 0 && colors[right] == colors[0]) {
            right--;
        }
        return Math.Max(n - 1 - left, right);
    }
}
// @lc code=end

