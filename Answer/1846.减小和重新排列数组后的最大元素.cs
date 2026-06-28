/*
 * @lc app=leetcode.cn id=1846 lang=csharp
 *
 * [1846] 减小和重新排列数组后的最大元素
 */

// @lc code=start
public class Solution
{
    public int MaximumElementAfterDecrementingAndRearranging(int[] arr)
    {
        Array.Sort(arr);
        int prev = 0;
        foreach (int x in arr)
        {
            prev = Math.Min(x, prev + 1);
        }
        return prev;
    }
}
// @lc code=end
