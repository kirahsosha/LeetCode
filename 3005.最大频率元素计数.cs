/*
 * @lc app=leetcode.cn id=3005 lang=csharp
 *
 * [3005] 最大频率元素计数
 */

// @lc code=start
public class Solution {
    public int MaxFrequencyElements(int[] nums)
    {
        int max = 0;
        Dictionary<int, int> dic = new Dictionary<int, int>();
        foreach (var i in nums)
        {
            if (dic.ContainsKey(i))
            {
                dic[i]++;
            }
            else
            {
                dic.Add(i, 1);
            }
            max = Math.Max(max, dic[i]);
        }
        var count = dic.Count(p => p.Value == max);
        return count * max;
    }
}
// @lc code=end

