/*
 * @lc app=leetcode.cn id=42 lang=csharp
 *
 * [42] 接雨水
 */

// @lc code=start
public class Solution {
    public int Trap(int[] height) {
        if(height.Length < 3) return 0;
        int len = height.Length;
        int[] lheight = new int[len];
        int[] rheight = new int[len];
        //第一次遍历, 从左往右, 找到每个点左侧的最高点
        lheight[0] = height[0];
        for(int i = 1; i < len; i++)
        {
            lheight[i] = Math.Max(height[i], lheight[i - 1]);
        }
        //第二次遍历, 从右往左, 找到每个点的右侧最高点
        rheight[len - 1] = height[len - 1];
        for(int i = len - 2; i >= 0; i--)
        {
            rheight[i] = Math.Max(height[i], rheight[i + 1]);
        }
        //第三次遍历，根据每个点两侧最高点计算接水量
        int w = 0;
        for(int i = 0; i < len; i++)
        {
            w += Math.Min(lheight[i], rheight[i]) - height[i];
        }
        return w;
    }
}
// @lc code=end

