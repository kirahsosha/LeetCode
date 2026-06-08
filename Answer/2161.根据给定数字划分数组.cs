/*
 * @lc app=leetcode.cn id=2161 lang=csharp
 *
 * [2161] 根据给定数字划分数组
 */

// @lc code=start
public class Solution
{
    public int[] PivotArray(int[] nums, int pivot)
    {
        var n = nums.Length;
        var ans = new int[n];
        var left = 0;
        var right = n - 1;
        foreach (var num in nums)
        {
            if (num < pivot)
            {
                ans[left++] = num;
            }
            else if (num > pivot)
            {
                ans[right--] = num;
            }
        }
        for (var i = left; i <= right; i++)
        {
            ans[i] = pivot;
        }
        left = right + 1;
        right = n - 1;
        while (left < right)
        {
            var tmp = ans[left];
            ans[left++] = ans[right];
            ans[right--] = tmp;
        }
        return ans;
    }
}
// @lc code=end
