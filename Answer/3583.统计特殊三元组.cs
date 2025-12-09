/*
 * @lc app=leetcode.cn id=3583 lang=csharp
 *
 * [3583] 统计特殊三元组
 */

// @lc code=start
public class Solution
{
    const int MOD = 1000000007;
    public int SpecialTriplets(int[] nums)
    {
        //记录每个值的出现次数
        var dic = new Dictionary<int, int>();
        //记录i左边有多少符合条件nums[i]*2的值
        var count = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            if (dic.ContainsKey(nums[i]))
            {
                dic[nums[i]]++;
            }
            else
            {
                dic.Add(nums[i], 1);
            }
            if (nums[i] != 0 && dic.ContainsKey(nums[i] * 2))
            {
                count.Add(i, dic[nums[i] * 2]);
            }
        }
        int res = 0;
        foreach (var item in count)
        {
            var i = item.Key;
            var value = item.Value;
            if (i != 0)
            {
                var right = dic[nums[i] * 2] - value;
                res = (value * right + res) % MOD;
            }
        }
        //处理0
        if (dic.ContainsKey(0) && dic[0] >= 3)
        {
            long zero = (long)dic[0] * (dic[0] - 1) * (dic[0] - 2) / 6 % MOD;
            res = (res + (int)zero) % MOD;
        }
        return res;
    }
}
// @lc code=end

