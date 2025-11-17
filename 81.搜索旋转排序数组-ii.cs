/*
 * @lc app=leetcode.cn id=81 lang=csharp
 *
 * [81] 搜索旋转排序数组 II
 */

// @lc code=start
public class Solution {
    public bool Search(int[] nums, int target) {
        if(nums.Length == 0) return false;
        for(int i = 0; i < nums.Length; i++)
        {
            if(nums[i] == target) return true;
        }
        return false;
    }
}
// @lc code=end

