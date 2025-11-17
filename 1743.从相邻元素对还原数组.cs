/*
 * @lc app=leetcode.cn id=1743 lang=csharp
 *
 * [1743] 从相邻元素对还原数组
 */

// @lc code=start
public class Solution {
    public int[] RestoreArray(int[][] adjacentPairs) {
        Dictionary<int, List<int>> dic = new Dictionary<int, List<int>>();
            foreach(var p in adjacentPairs)
            {
                if(dic.ContainsKey(p[0]))
                {
                    dic[p[0]].Add(p[1]);
                }
                else
                {
                    dic.Add(p[0], new List<int>() { p[1] });
                }
                if (dic.ContainsKey(p[1]))
                {
                    dic[p[1]].Add(p[0]);
                }
                else
                {
                    dic.Add(p[1], new List<int>() { p[0] });
                }
            }
            var t = dic.Where(p => p.Value.Count == 1).FirstOrDefault();
            List<int> ans = new List<int>();
            int key = t.Key;
            int next = t.Value[0];
            ans.Add(key);
            while (key != next)
            {
                var nd = dic[next];
                if(nd.Count ==1)
                {
                    ans.Add(next);
                    break;
                }
                else
                {
                    ans.Add(next);
                    int tt = next;
                    next = nd.Where(p => p != key).First();
                    key = tt;
                }
            }
            return ans.ToArray();
    }
}
// @lc code=end

