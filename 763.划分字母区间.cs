/*
 * @lc app=leetcode.cn id=763 lang=csharp
 *
 * [763] 划分字母区间
 */

// @lc code=start
public class Solution
{
    public IList<int> PartitionLabels(string s)
    {
        if (s.Length == 1) return new List<int> { 1 };
        Dictionary<char, int[]> dic = new Dictionary<char, int[]>();
        for (int i = 0; i < s.Length; i++)
        {
            char c = s[i];
            if (dic.ContainsKey(c))
            {
                dic[c][1] = i;
            }
            else
            {
                dic.Add(c, new int[] { i, i });
            }
        }
        List<int[]> ranges = new List<int[]>();
        foreach (var c in dic.Values)
        {
            var left = c[0];
            var right = c[1];
            var range = ranges
                .Where(r => r[0] <= left && r[1] >= left
                || r[0] <= right && r[1] >= right
                || r[0] <= left && r[1] >= right
                || r[0] >= left && r[1] <= right);
            if (range.Any())
            {
                left = Math.Min(left, range.Min(r => r[0]));
                right = Math.Max(right, range.Max(r => r[1]));
                ranges.RemoveAll(r => r[0] >= left && r[1] <= right);
                ranges.Add(new int[] { left, right });
            }
            else
            {
                ranges.Add(new int[] { left, right });
            }
        }
        var res = ranges.Select(r => r[1] - r[0] + 1).ToList();
        return res;
    }
}
// @lc code=end

