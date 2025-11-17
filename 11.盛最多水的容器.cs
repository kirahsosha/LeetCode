/*
 * @lc app=leetcode.cn id=11 lang=csharp
 *
 * [11] 盛最多水的容器
 */

// @lc code=start
public class Solution
{
    public int MaxArea(int[] height)
    {
        int len = height.Length;
        int left = 0, right = len - 1, w = 0;
        while (left < right)
        {
            var currentHight = Math.Min(height[left], height[right]);
            w = Math.Max(w, currentHight * (right - left));
            if (height[left] < height[right])
            {
                while (height[left] <= currentHight && left < right)
                {
                    left++;
                }
            }
            else
            {
                while (height[right] <= currentHight && left < right)
                {
                    right--;
                }
            }
        }
        return w;
    }
}
// @lc code=end

