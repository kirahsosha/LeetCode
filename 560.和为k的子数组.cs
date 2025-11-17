/*
 * @lc app=leetcode.cn id=560 lang=csharp
 *
 * [560] 和为K的子数组
 */

// @lc code=start
public class Solution {
    public int SubarraySum(int[] nums, int k) {
        if(nums.Length == 1) return nums[0] == k ? 1 : 0;
        int ans = 0, pre = 0;
        Dictionary<int, int> dict = new Dictionary<int, int> {{0, 1}};
        for (int i = 0; i < nums.Length; i++)
        {
            pre += nums[i];
            if (dict.ContainsKey(pre - k))
                ans += dict[pre - k];

            if (dict.ContainsKey(pre))
            {
                dict[pre]++;
            }
            else
            {
                dict.Add(pre, 1);
            }
        }

        return ans;
    }
}
// @lc code=end

