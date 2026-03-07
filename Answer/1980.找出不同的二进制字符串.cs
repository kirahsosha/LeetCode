/*
 * @lc app=leetcode.cn id=1980 lang=csharp
 *
 * [1980] 找出不同的二进制字符串
 */

// @lc code=start
public class Solution
{
    public string FindDifferentBinaryString(string[] nums)
    {
        var n = nums.Length;
        var res = new char[n];
        for (var i = 0; i < n; i++)
        {
            res[i] = nums[i][i] == '0' ? '1' : '0';
        }
        return new string(res);
    }
}
// @lc code=end

