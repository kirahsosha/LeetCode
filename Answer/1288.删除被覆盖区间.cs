/*
 * @lc app=leetcode.cn id=1288 lang=csharp
 *
 * [1288] 删除被覆盖区间
 */

// @lc code=start
public class Solution
{
    public int RemoveCoveredIntervals(int[][] intervals)
    {
        Array.Sort(intervals, (a, b) =>
        {
            return a[0] != b[0] ? a[0] - b[0] : b[1] - a[1];
        });

        int count = 0;
        int end = 0;
        foreach (var interval in intervals)
        {
            if (interval[1] > end)
            {
                count++;
                end = interval[1];
            }
        }

        return count;
    }
}
// @lc code=end

