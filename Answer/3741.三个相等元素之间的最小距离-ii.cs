/*
 * @lc app=leetcode.cn id=3741 lang=csharp
 *
 * [3741] 三个相等元素之间的最小距离 II
 */

// @lc code=start
public class Solution
{
    public int MinimumDistance(int[] nums)
    {
        var positions = new Dictionary<int, (int older, int newer, int count)>();
        int best = int.MaxValue;
        foreach ((int num, int index) in nums.Select((num, index) => (num, index)))
        {
            if (!positions.TryGetValue(num, out var state))
            {
                positions[num] = (index, 0, 1);
                continue;
            }

            if (state.count == 1)
            {
                positions[num] = (state.older, index, 2);
                continue;
            }

            best = Math.Min(best, 2 * (index - state.older));
            positions[num] = (state.newer, index, 2);
        }

        return best == int.MaxValue ? -1 : best;
    }
}
// @lc code=end

