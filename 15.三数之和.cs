/*
 * @lc app=leetcode.cn id=15 lang=csharp
 *
 * [15] 三数之和
 */

// @lc code=start
public class Solution {
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        int len = nums.Length;
        var result = new List<IList<int>>();
        if (len < 3) return result;
        Array.Sort(nums);
        //map<值，lastIndex>
        var map = new Dictionary<int, int>();
        for (int i = 0; i < len; i++)
        {
            if (map.ContainsKey(nums[i])) map[nums[i]] = i;
            else map.Add(nums[i], i);
        }
        for (int i = 0; i < len - 2; i++)
        {
            if (nums[i] > 0) break;
            if (i > 0 && nums[i] == nums[i - 1]) continue;
            for (int j = i + 1; j < len - 1; j++)
            {
                if (j != i + 1 && nums[j] == nums[j - 1]) continue;
                int numsK = 0 - nums[i] - nums[j];
                if (map.ContainsKey(numsK) && map[numsK] > j)
                    result.Add(new List<int>() { nums[i], nums[j], numsK });
            }
        }
        return result;
    }
}
// @lc code=end

