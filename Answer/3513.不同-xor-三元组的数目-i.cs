/*
 * @lc app=leetcode.cn id=3513 lang=csharp
 *
 * [3513] 不同 XOR 三元组的数目 I
 */

// @lc code=start
public class Solution
{
    public int UniqueXorTriplets(int[] nums)
    {
        var n = nums.Length;
        if (n <= 2) return n;
        var ans = 1;
        while (ans <= n)
        {
            ans <<= 1;
        }
        return ans;
    }
}
// @lc code=end

