/*
 * @lc app=leetcode.cn id=238 lang=csharp
 *
 * [238] 除自身以外数组的乘积
 */

// @lc code=start
public class Solution {
    public int[] ProductExceptSelf(int[] nums) {
        int n = nums.Length;
        int[] ans = new int[n]; //使用数组先保存右侧乘积, 再保存输出结果
        ans[n - 1] = 1;
        int left = 1; //动态计算左侧乘积
        //计算右侧乘积
        for(int i = n - 2; i >= 0; i--)
        {
            ans[i] = ans[i + 1] * nums[i + 1];
        }
        //计算左侧乘积, 再计算输出结果
        for(int i = 1; i < n; i++)
        {
            left *= nums[i - 1];
            ans[i] *= left;
        }
        return ans;
    }
}
// @lc code=end

