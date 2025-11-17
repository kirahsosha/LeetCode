/*
 * @lc app=leetcode.cn id=128 lang=csharp
 *
 * [128] 最长连续序列
 */

// @lc code=start
public class Solution {
    public int LongestConsecutive(int[] nums) {
        if(nums.Length == 0) return 0;
        if(nums.Length == 1) return 1;
        Array.Sort(nums);
        int ans = 0;
        int index = 1;
        for(int i = 1; i < nums.Length; i++)
        {
            if(nums[i] == nums[i - 1] + 1)
            {
                index++;
            }
            else if(nums[i] == nums[i - 1])
            {
                continue;
            }
            else
            {
                ans = Math.Max(ans, index);
                index = 1;
            }
        }
        ans = Math.Max(ans, index);
        return ans;
    }
}
// @lc code=end

