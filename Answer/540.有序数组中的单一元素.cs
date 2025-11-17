/*
 * @lc app=leetcode.cn id=540 lang=csharp
 *
 * [540] 有序数组中的单一元素
 */

// @lc code=start
public class Solution {
    public int SingleNonDuplicate(int[] nums) {
        if(nums.Length == 1) return nums[0];
        int l = 0;
        int r = nums.Length - 1;
        int m = 0;
        while(l < r)
        {
            m = l + (r - l) / 2;
            if (m % 2 == 1) m--;
            if (nums[m] == nums[m + 1])
            {
                l = m + 2;
            }
            else
            {
                r = m;
            }
        }
        return nums[l];
    }
}
// @lc code=end

