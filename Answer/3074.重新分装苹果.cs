/*
 * @lc app=leetcode.cn id=3074 lang=csharp
 *
 * [3074] 重新分装苹果
 */

// @lc code=start
public class Solution
{
    public int MinimumBoxes(int[] apple, int[] capacity)
    {
        var apples = apple.Sum();
        Array.Sort(capacity, new DescendingComparer());
        var res = 0;
        foreach (var cap in capacity)
        {
            apples -= cap;
            res++;
            if (apples <= 0)
            {
                break;
            }
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

