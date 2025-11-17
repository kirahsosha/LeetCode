/*
 * @lc app=leetcode.cn id=45 lang=csharp
 *
 * [45] 跳跃游戏 II
 */

// @lc code=start
public class Solution {
    //记录本次跳跃可到达的范围, 和在这个范围内能跳跃到的下一次的范围
    public int Jump(int[] nums) {
        if(nums.Length == 1) return 0;
        if(nums[0] >= nums.Length) return 1;
        int pNowLeft = 0, pNowRight = 0;
        int pNextLeft = 0, pNextRight = 0;
        int step = 0;
        while(pNextRight < nums.Length - 1)
        {
            pNextLeft = pNowLeft + 1;
            pNextRight = pNextLeft;
            for(int i = pNowLeft; i <= pNowRight; i++)
            {
                pNextRight = Math.Max(pNextRight, i + nums[i]);
            }
            step++;
            pNowLeft = pNextLeft;
            pNowRight = pNextRight;
        }
        return step;
    }
}
// @lc code=end

