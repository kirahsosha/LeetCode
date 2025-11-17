/*
 * @lc app=leetcode.cn id=27 lang=csharp
 *
 * [27] 移除元素
 */

// @lc code=start
public class Solution {
    public int RemoveElement(int[] nums, int val) {
        if(nums.Length == 0) return 0;
        int i = 0, j = 0;
        while(j < nums.Length)
        {
            if(nums[j] != val)
            {
                nums[i++] = nums[j];
            }
            j++;
        }
        return i;
    }
}
// @lc code=end

