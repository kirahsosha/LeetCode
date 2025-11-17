/*
 * @lc app=leetcode.cn id=1248 lang=csharp
 *
 * [1248] 统计「优美子数组」
 */

// @lc code=start
public class Solution {
    public int NumberOfSubarrays(int[] nums, int k) {
        if(nums.Length < k) return 0;
        int ans = 0, len = nums.Length;
        int[] sum = new int[len + 1];
        int t = 0, i = 0;
        //遍历nums, 给偶数分组
        while(i < len)
        {
            if(nums[i] % 2 == 0)
            {
                sum[t]++;
                i++;
            }
            else
            {
                t++;
                i++;
            }
        }
        for(i = 0; i < t - k + 1; i++)
        {
            ans += (sum[i] + 1) * (sum[i + k] + 1);
        }
        return ans;
    }
}
// @lc code=end

