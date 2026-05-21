/*
 * @lc app=leetcode.cn id=2657 lang=csharp
 *
 * [2657] 找到两个数组的前缀公共数组
 */

// @lc code=start
public class Solution
{
    public int[] FindThePrefixCommonArray(int[] A, int[] B)
    {
        int n = A.Length;
        int[] ans = new int[n];
        int[] count = new int[n + 1];
        int common = 0;
        for (int i = 0; i < n; i++)
        {
            count[A[i]]++;
            if (count[A[i]] == 2)
            {
                common++;
            }

            count[B[i]]++;
            if (count[B[i]] == 2)
            {
                common++;
            }

            ans[i] = common;
        }

        return ans;
    }
}
// @lc code=end
