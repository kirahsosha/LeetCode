/*
 * @lc app=leetcode.cn id=283 lang=csharp
 *
 * [283] 移动零
 */

// @lc code=start
public class Solution {
    public void MoveZeroes(int[] nums) {
        if(nums.Length == 0) return;
        int p = 0, q = 0; //p - 顺序遍历指针; q - 非0值位置的指针
        while(p < nums.Length)
        {
            if(nums[p] == 0)
            {
                p++;
            }
            else
            {
                nums[q++] = nums[p++];
            }
        }
        while(q < nums.Length)
        {
            nums[q++] = 0;
        }
        return;
    }
}
// @lc code=end

