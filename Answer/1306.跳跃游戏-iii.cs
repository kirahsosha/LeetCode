/*
 * @lc app=leetcode.cn id=1306 lang=csharp
 *
 * [1306] 跳跃游戏 III
 */

// @lc code=start
public class Solution
{
    public bool CanReach(int[] arr, int start)
    {
        var visited = new bool[arr.Length];
        var stack = new Stack<int>();
        stack.Push(start);
        visited[start] = true;
        while (stack.Count > 0)
        {
            int index = stack.Pop();
            if (arr[index] == 0)
            {
                return true;
            }

            int next = index + arr[index];
            if (next < arr.Length && !visited[next])
            {
                visited[next] = true;
                stack.Push(next);
            }

            int prev = index - arr[index];
            if (prev >= 0 && !visited[prev])
            {
                visited[prev] = true;
                stack.Push(prev);
            }
        }

        return false;
    }
}
// @lc code=end