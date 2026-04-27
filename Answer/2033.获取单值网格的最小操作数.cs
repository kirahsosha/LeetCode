/*
 * @lc app=leetcode.cn id=2033 lang=csharp
 *
 * [2033] 获取单值网格的最小操作数
 */

// @lc code=start
public class Solution
{
    public int MinOperations(int[][] grid, int x)
    {
        var m = grid.Length;
        var n = grid[0].Length;
        var nums = new int[m * n];
        var baseVal = grid[0][0];
        var idx = 0;

        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < n; j++)
            {
                var num = grid[i][j];
                if ((num - baseVal) % x != 0)
                {
                    return -1;
                }
                nums[idx++] = num;
            }
        }

        Array.Sort(nums);
        var median = nums[nums.Length / 2];
        var ans = 0;

        foreach (var num in nums)
        {
            ans += Math.Abs(num - median) / x;
        }

        return ans;
    }
}
// @lc code=end
