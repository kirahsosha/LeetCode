/*
 * @lc app=leetcode.cn id=3314 lang=csharp
 *
 * [3314] 构造最小位运算数组 I
 */

// @lc code=start
public class Solution
{
    public int[] MinBitwiseArray(IList<int> nums)
    {
        var n = nums.Count;
        var ans = new int[n];
        for (int i = 0; i < n; i++)
        {
            var min = nums[i] / 2;
            ans[i] = -1;
            for (int j = min; j < nums[i]; j++)
            {
                if ((j | (j + 1)) == nums[i])
                {
                    ans[i] = j;
                    break;
                }
            }
        }
        return ans;
    }
}
// @lc code=end

