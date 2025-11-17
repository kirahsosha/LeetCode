/*
 * @lc app=leetcode.cn id=213 lang=csharp
 *
 * [213] 打家劫舍 II
 */

// @lc code=start
public class Solution {
    //由于1号和n号不能同时偷, 考虑两种情况:
    //1. 偷1到n-1号房屋
    //2. 偷2到n号房屋
    //结果转化为两组dp求最大值
    //状态转移方程 dp[n] = max(dp[n-1], dp[n-2] + num[n])
    public int Rob(int[] nums) {
        int len = nums.Length;
        if(len == 0) return 0;
        if(len == 1) return nums[0];
        if(len == 2) return Math.Max(nums[0], nums[1]);
        if(len == 3) return Math.Max(Math.Max(nums[0], nums[1]), nums[2]);
        //偷1到n-1号房屋
        int[] dp1 = new int[len];
        dp1[0] = nums[0];
        dp1[1] = Math.Max(nums[0], nums[1]);
        for(int i = 2; i < len - 1; i++)
        {
            dp1[i] = Math.Max(dp1[i - 2] + nums[i], dp1[i - 1]);
        }
        int ans1 = Math.Max(dp1[len - 3], dp1[len - 2]);
        //偷2到n号房屋
        int[] dp2 = new int[len];
        dp2[1] = nums[1];
        dp2[2] = Math.Max(nums[1], nums[2]);
        for(int i = 3; i < len; i++)
        {
            dp2[i] = Math.Max(dp2[i - 2] + nums[i], dp2[i - 1]);
        }
        int ans2 = Math.Max(dp2[len - 2], dp2[len - 1]);
        return Math.Max(ans1, ans2);
    }
}
// @lc code=end

