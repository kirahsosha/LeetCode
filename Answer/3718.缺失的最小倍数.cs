/*
 * @lc app=leetcode.cn id=3718 lang=csharp
 *
 * [3718] 缺失的最小倍数
 */

// @lc code=start
public class Solution
{
    public int MissingMultiple(int[] nums, int k)
    {
        var set = new HashSet<int>(nums);
        var multiple = k;
        while (set.Contains(multiple))
        {
            multiple += k;
        }
        return multiple;
    }
}
// @lc code=end

