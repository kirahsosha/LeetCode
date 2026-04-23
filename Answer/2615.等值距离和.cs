using System.Collections.Generic;

/*
 * @lc app=leetcode.cn id=2615 lang=csharp
 *
 * [2615] 等值距离和
 */

// @lc code=start
public class Solution
{
    public long[] Distance(int[] nums)
    {
        var n = nums.Length;
        var ans = new long[n];

        // 从左向右：计算每个位置左侧同值元素的距离和
        var cnt = new Dictionary<int, int>(n);
        var sum = new Dictionary<int, long>(n);
        for (var i = 0; i < n; i++)
        {
            cnt.TryGetValue(nums[i], out int c);
            sum.TryGetValue(nums[i], out long s);
            long idx = i;
            ans[i] = idx * c - s;
            cnt[nums[i]] = c + 1;
            sum[nums[i]] = s + idx;
        }

        // 从右向左：计算每个位置右侧同值元素的距离和并累加
        cnt = new Dictionary<int, int>(n);
        sum = new Dictionary<int, long>(n);
        for (var i = n - 1; i >= 0; i--)
        {
            cnt.TryGetValue(nums[i], out int c);
            sum.TryGetValue(nums[i], out long s);
            long idx = i;
            ans[i] += s - idx * c;
            cnt[nums[i]] = c + 1;
            sum[nums[i]] = s + idx;
        }

        return ans;
    }
}
// @lc code=end
