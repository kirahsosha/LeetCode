/*
 * @lc app=leetcode.cn id=1356 lang=csharp
 *
 * [1356] 根据数字二进制下 1 的数目排序
 */

// @lc code=start
public class Solution
{
    public int[] SortByBits(int[] arr)
    {
        var dic = new Dictionary<int, List<int>>();
        foreach (var num in arr)
        {
            var count = 0;
            var t = num;
            while (t > 0)
            {
                count += t & 1;
                t >>= 1;
            }
            if (!dic.ContainsKey(count))
            {
                dic[count] = new List<int>();
            }
            dic[count].Add(num);
        }
        return dic.OrderBy(x => x.Key).SelectMany(x => x.Value.OrderBy(y => y)).ToArray();
    }
}
// @lc code=end

