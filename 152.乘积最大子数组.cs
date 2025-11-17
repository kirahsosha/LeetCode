/*
 * @lc app=leetcode.cn id=152 lang=csharp
 *
 * [152] 乘积最大子数组
 */

// @lc code=start
public class Solution {
    public int MaxProduct(int[] nums) {
        if (nums.Length == 0) return 0;
        if (nums.Length == 1) return nums[0];
        int n = nums.Length;
        int max = nums[0];
        int min = nums[0];
        int ans = nums[0];
        for (int i = 1; i < n; i++)
        {
            int tmax = max;
            int tmin = min;
            max = Math.Max(tmax * nums[i],
                  Math.Max(tmin * nums[i], nums[i]));
            min = Math.Min(tmax * nums[i],
                  Math.Min(tmin * nums[i], nums[i]));
            ans = Math.Max(ans, max);
        }
        return ans;
    }
}
// @lc code=end

