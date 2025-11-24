/*
 * @lc app=leetcode.cn id=1018 lang=csharp
 *
 * [1018] 可被 5 整除的二进制前缀
 */

// @lc code=start
public class Solution
{
    public IList<bool> PrefixesDivBy5(int[] nums)
    {
        int num = 0;
        var res = new List<bool>();
        foreach (int i in nums)
        {
            num = num * 2 + i;
            if (num % 5 == 0)
            {
                res.Add(true);
            }
            else
            {
                res.Add(false);
            }
            num = num % 10;
        }
        return res;
    }
}
// @lc code=end

