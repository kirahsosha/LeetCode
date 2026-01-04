/*
 * @lc app=leetcode.cn id=961 lang=csharp
 *
 * [961] 在长度 2N 的数组中找出重复 N 次的元素
 */

// @lc code=start
public class Solution
{
    public int RepeatedNTimes(int[] nums)
    {
        var res = 0;
        var set = new HashSet<int>();
        foreach (var n in nums)
        {
            if (set.Contains(n))
            {
                res = n;
                break;
            }
            set.Add(n);
        }
        return res;
    }
}
// @lc code=end

