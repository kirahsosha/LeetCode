/*
 * @lc app=leetcode.cn id=169 lang=csharp
 *
 * [169] 多数元素
 */

// @lc code=start
public class Solution
{
    public int MajorityElement(int[] nums)
    {
        var res = nums[0];
        var count = 1;
        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] == res)
            {
                count++;
            }
            else
            {
                count--;
                if (count == 0)
                {
                    res = nums[i];
                    count = 1;
                }
            }
        }
        return res;
    }
}
// @lc code=end

