/*
 * @lc app=leetcode.cn id=3075 lang=csharp
 *
 * [3075] 幸福值最大化的选择方案
 */

// @lc code=start
public class Solution
{
    public long MaximumHappinessSum(int[] happiness, int k)
    {
        Array.Sort(happiness, new DescendingComparer());
        long res = 0;
        for (int i = 0; i < k; i++)
        {
            res += Math.Max(0, happiness[i] - i);
        }
        return res;
    }

    public class DescendingComparer : Comparer<int>
    {
        public override int Compare(int x, int y)
        {
            return y - x;
        }
    }

}
// @lc code=end

