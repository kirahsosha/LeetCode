/*
 * @lc app=leetcode.cn id=26 lang=csharp
 *
 * [26] 删除排序数组中的重复项
 */

// @lc code=start
public class Solution {
    public int RemoveDuplicates(int[] nums) {
        if(nums.Length == 0) return 0;
        if(nums.Length == 1) return 1;
        int a = 0, b = 1;
        while(b < nums.Length)
        {
            if(nums[b] > nums[a])
            {
                nums[++a] = nums[b];
                b++;
            }
            else
            {
                b++;
            }
        }
        return a + 1;
    }
}
// @lc code=end

