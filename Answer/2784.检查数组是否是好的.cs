/*
 * @lc app=leetcode.cn id=2784 lang=csharp
 *
 * [2784] 检查数组是否是好的
 */

// @lc code=start
public class Solution
{
    public bool IsGood(int[] nums)
    {
        int n = nums.Length - 1;
        if (n == 0)
        {
            return false;
        }

        int[] cnt = new int[n];
        foreach (int num in nums)
        {
            if (num > n || num <= 0)
            {
                return false;
            }
            if (num != n && cnt[num - 1] == 1)
            {
                return false;
            }
            if (num == n && cnt[num - 1] > 1)
            {
                return false;
            }
            cnt[num - 1]++;
        }
        return true;
    }
}
// @lc code=end
