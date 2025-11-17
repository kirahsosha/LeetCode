/*
 * @lc app=leetcode.cn id=645 lang=csharp
 *
 * [645] 错误的集合
 */

// @lc code=start
public class Solution {
    public int[] FindErrorNums(int[] nums) {
        int n = nums.Length;
        int[] count = new int[n + 1];
        for(int i = 0; i < n ; i++)
        {
            count[nums[i]]++;
        }
        int[] ans = new int[2];
        int k = 1;
        while((ans[0] == 0 || ans[1] == 0) && k <= n)
        {
            if(count[k] == 0) ans[1] = k;
            if(count[k] == 2) ans[0] = k;
            k++;
        }
        return ans;
    }
}
// @lc code=end

