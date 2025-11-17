/*
 * @lc app=leetcode.cn id=2654 lang=csharp
 *
 * [2654] 使数组所有元素变成 1 的最少操作次数
 */

// @lc code=start
public class Solution
{
    public int MinOperations(int[] nums)
    {
        if (nums.Contains(1))
        {
            return nums.Count(n => n > 1);
        }
        int min = nums.Length;
        for (int i = 0; i < nums.Length - 1; i++)
        {
            var gcd = 0;
            for (int j = i; j < nums.Length; j++)
            {
                gcd = GCD(gcd, nums[j]);
                if (gcd == 1)
                {
                    min = Math.Min(min, j - i);
                    break;
                }
            }
            if (min == 1) break;
        }
        if (min == nums.Length) return -1;
        else return nums.Length + min - 1;
    }

    private int GCD(int a, int b)
    {
        return b == 0 ? a : GCD(b, a % b);
    }
}
// @lc code=end

