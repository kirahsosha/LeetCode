/*
 * @lc app=leetcode.cn id=416 lang=csharp
 *
 * [416] 分割等和子集
 */

// @lc code=start
public class Solution
{
    public bool CanPartition(int[] nums)
    {
        int sum = nums.Sum(), maxNum = nums.Max();
        if (sum % 2 != 0 || maxNum * 2 > sum)
        {
            return false;
        }
        int n = nums.Length;
        int target = sum / 2;
        bool[] dp = new bool[target + 1];
        dp[0] = true;
        for (int i = 1; i <= n; i++)
        {
            for (int j = target; j >= nums[i - 1]; j--)
            {
                dp[j] |= dp[j - nums[i - 1]];
            }
        }
        return dp[target];
    }
}
// @lc code=end

