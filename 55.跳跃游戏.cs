/*
 * @lc app=leetcode.cn id=55 lang=csharp
 *
 * [55] 跳跃游戏
 */

// @lc code=start
public class Solution
{
    public bool CanJump(int[] nums)
    {
        if (nums.Length == 1) return true;
        if (nums[0] == 0) return false;
        int len = nums.Length;
        int max = nums[0];
        //初始化每个点能跳跃到的最远位置
        for (int i = 1; i < len; i++)
        {
            if (max < i) return false;
            if (max >= len - 1) return true;
            max = Math.Max(max, i + nums[i]);
        }
        return true;
    }
}
// @lc code=end

