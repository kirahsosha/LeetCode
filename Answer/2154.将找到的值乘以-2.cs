/*
 * @lc app=leetcode.cn id=2154 lang=csharp
 *
 * [2154] 将找到的值乘以 2
 */

// @lc code=start
public class Solution
{
    public int FindFinalValue(int[] nums, int original)
    {
        var map = new HashSet<int>(nums);
        while (map.Contains(original))
        {
            original *= 2;
        }
        return original;
    }
}
// @lc code=end

