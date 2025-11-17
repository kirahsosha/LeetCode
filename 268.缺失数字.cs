/*
 * @lc app=leetcode.cn id=268 lang=csharp
 *
 * [268] 缺失数字
 */

// @lc code=start
public class Solution {
    public int MissingNumber(int[] nums) {
        int n = nums.Length;
        if(n == 0) return 0;
        int m = 0, t = 0;
        m = (1 + n) * n / 2;
        for(int i = 0; i < n; i++)
        {
            t +=nums[i];
        }
        return m - t;
    }
}
// @lc code=end

