/*
 * @lc app=leetcode.cn id=84 lang=csharp
 *
 * [84] 柱状图中最大的矩形
 */

// @lc code=start
public class Solution
{
    public int LargestRectangleArea(int[] heights)
    {
        int n = heights.Length;
        int[] left = new int[n];
        int[] right = new int[n];
        for (int i = 0; i < n; i++)
        {
            right[i] = n;
        }
        Stack<int> mono_stack = new Stack<int>();
        for (int i = 0; i < n; ++i)
        {
            while (mono_stack.Count != 0 && heights[mono_stack.Peek()] >= heights[i])
            {
                right[mono_stack.Peek()] = i;
                mono_stack.Pop();
            }
            left[i] = (mono_stack.Count == 0 ? -1 : mono_stack.Peek());
            mono_stack.Push(i);
        }
        int ans = 0;
        for (int i = 0; i < n; ++i)
        {
            ans = Math.Max(ans, (right[i] - left[i] - 1) * heights[i]);
        }
        return ans;
    }
}
// @lc code=end

