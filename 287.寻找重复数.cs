/*
 * @lc app=leetcode.cn id=287 lang=csharp
 *
 * [287] 寻找重复数
 */

// @lc code=start
public class Solution
{
    public int FindDuplicate(int[] nums)
    {
        bool[] n = new bool[nums.Length + 1];
        foreach (int i in nums)
        {
            if (n[i]) return i;
            n[i] = true;
        }
        return nums[nums.Length - 1];
    }
}
// @lc code=end

