/*
 * @lc app=leetcode.cn id=3312 lang=csharp
 *
 * [3312] 查询排序后的最大公约数
 */

// @lc code=start
public class Solution
{
    public int[] GcdValues(int[] nums, long[] queries)
    {
        int mx = 0;
        foreach (int x in nums)
        {
            mx = Math.Max(mx, x);
        }
        int[] cntX = new int[mx + 1];
        foreach (int x in nums)
        {
            cntX[x]++;
        }

        long[] cntGcd = new long[mx + 1];
        for (int i = mx; i > 0; i--)
        {
            int c = 0;
            for (int j = i; j <= mx; j += i)
            {
                c += cntX[j];
                cntGcd[i] -= cntGcd[j]; // gcd 是 2i,3i,4i,... 的数对不能统计进来
            }
            cntGcd[i] += (long)c * (c - 1) / 2; // c 个数选 2 个，组成 c*(c-1)/2 个数对
        }

        for (int i = 2; i <= mx; i++)
        {
            cntGcd[i] += cntGcd[i - 1]; // 原地求前缀和
        }

        int[] ans = new int[queries.Length];
        for (int i = 0; i < queries.Length; i++)
        {
            ans[i] = UpperBound(cntGcd, queries[i]);
        }
        return ans;
    }

    private int UpperBound(long[] nums, long target)
    {
        int left = -1, right = nums.Length; // 开区间 (left, right)
        while (left + 1 < right)
        { // 区间不为空
            // 循环不变量：
            // nums[left] <= target
            // nums[right] > target
            int mid = (left + right) >> 1;
            if (nums[mid] > target)
            {
                right = mid; // 二分范围缩小到 (left, mid)
            }
            else
            {
                left = mid; // 二分范围缩小到 (mid, right)
            }
        }
        return right;
    }
}
// @lc code=end

