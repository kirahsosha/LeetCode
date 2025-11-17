/*
 * @lc app=leetcode.cn id=347 lang=csharp
 *
 * [347] 前 K 个高频元素
 */

// @lc code=start
public class Solution
{
    public int[] TopKFrequent(int[] nums, int k)
    {
        if (nums.Length == k) return nums;
        Dictionary<int, int> count = new Dictionary<int, int>();
        SortedDictionary<int, List<int>> dic = new SortedDictionary<int, List<int>>
        {
            { 1, new List<int>() }
        };
        foreach (int i in nums)
        {
            if (count.ContainsKey(i))
            {
                dic[count[i]].Remove(i);
                count[i]++;
                if (dic.ContainsKey(count[i]))
                {
                    dic[count[i]].Add(i);
                }
                else
                {
                    dic.Add(count[i], new List<int>() { i });
                }
            }
            else
            {
                count.Add(i, 1);
                dic[1].Add(i);
            }
        }
        var res = new List<int>();
        foreach (var item in dic.OrderByDescending(d=>d.Key))
        {
            res.AddRange(item.Value);
            if (res.Count >= k) break;
        }
        return res.Skip(res.Count - k).Take(k).ToArray();
    }
}
// @lc code=end

