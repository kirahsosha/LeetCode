/*
 * @lc app=leetcode.cn id=179 lang=csharp
 *
 * [179] 最大数
 */

// @lc code=start
public class Solution
{
    public string LargestNumber(int[] nums)
    {
        Array.Sort(nums, new NumberConcatComparer());
        var res = string.Join("", nums).TrimStart('0');
        return string.IsNullOrEmpty(res) ? "0" : res;
    }

    public class NumberConcatComparer : Comparer<int>
    {
        public override int Compare(int x, int y)
        {
            if (x == y) return 0;
            if (x == 0) return 1;
            if (y == 0) return -1;
            if (Concat(x, y) > Concat(y, x))
            {
                return -1;
            }
            return 1;
        }

        private long Concat(int x, int y)
        {
            int i = 1;
            while (i <= y)
            {
                i *= 10;
            }
            return (long)x * i + y;
        }
    }
}
// @lc code=end

