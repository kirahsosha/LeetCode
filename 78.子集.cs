/*
 * @lc app=leetcode.cn id=78 lang=csharp
 *
 * [78] 子集
 */

// @lc code=start
public class Solution
{
    public IList<IList<int>> Subsets(int[] nums)
    {
        List<IList<int>> res = new List<IList<int>>()
            {
                new List<int>()
            };
        foreach (var i in nums)
        {
            var count = res.Count;
            for (int k = 0; k < count; k++)
            {
                var nlist = new List<int>(res[k]);
                nlist.Add(i);
                res.Add(nlist);
            }
        }

        return res;
    }
}
// @lc code=end

