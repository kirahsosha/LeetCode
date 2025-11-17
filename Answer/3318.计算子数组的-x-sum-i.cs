/*
 * @lc app=leetcode.cn id=3318 lang=csharp
 *
 * [3318] 计算子数组的 x-sum I
 */

// @lc code=start
public class Solution
{
    public int[] FindXSum(int[] nums, int k, int x)
    {
        if (nums.Length == 1) return nums;
        var sd = new Dictionary<int, int>();
        var res = new int[nums.Length - k + 1];
        for (int i = 0; i < k; i++)
        {
            if (sd.ContainsKey(nums[i]))
            {
                sd[nums[i]]++;
            }
            else
            {
                sd.Add(nums[i], 1);
            }
        }
        res[0] = FindXSum(x, sd);
        for (int i = k; i < nums.Length; i++)
        {
            sd[nums[i - k]]--;
            if (sd.ContainsKey(nums[i]))
            {
                sd[nums[i]]++;
            }
            else
            {
                sd.Add(nums[i], 1);
            }
            res[i - k + 1] = FindXSum(x, sd);
        }
        return res;
    }

    public int FindXSum(int x, Dictionary<int, int> dic)
    {
        return dic.OrderByDescending(d => d.Value).ThenByDescending(d => d.Key).Take(x).Sum(d => d.Key * d.Value);
    }
}
// @lc code=end

