/*
 * @lc app=leetcode.cn id=3514 lang=csharp
 *
 * [3514] 不同 XOR 三元组的数目 II
 */

// @lc code=start
public class Solution
{
    public int UniqueXorTriplets(int[] nums)
    {
        var ans = new HashSet<int>();
        var set = new HashSet<int>();
        nums = nums.Distinct().ToArray();
        var n = nums.Length;
        for (var i = 0; i < n; i++)
        {
            for (var j = i; j < n; j++)
            {
                set.Add(nums[i] ^ nums[j]);
            }
        }
        for (var i = 0; i < n; i++)
        {
            foreach (var num in set)
            {
                ans.Add(nums[i] ^ num);
            }
        }
        return ans.Count;
    }
}
// @lc code=end

