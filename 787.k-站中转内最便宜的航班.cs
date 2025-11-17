/*
 * @lc app=leetcode.cn id=787 lang=csharp
 *
 * [787] K 站中转内最便宜的航班
 */

// @lc code=start
public class Solution {
    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k)
        {
            Dictionary<int, Dictionary<int, int>> dic = new Dictionary<int, Dictionary<int, int>>();
            foreach(var p in flights)
            {
                int from = p[0];
                int to = p[1];
                int price = p[2];
                if(dic.ContainsKey(from))
                {
                    dic[from].Add(to, price);
                }
                else
                {

                    dic.Add(from, new Dictionary<int, int>());
                    dic[from].Add(to, price);
                }
            }
            return FindPrice(dic, src, dst, 0, k);
        }

        public int FindPrice(Dictionary<int, Dictionary<int, int>> dic, int src, int dst,int index, int k)
        {
            if (index > k) return -1;
            index++;
            int ans = -1;
            foreach(var lines in dic[src])
            {
                int to = lines.Key;
                int price = lines.Value;
                if(to == dst)
                {
                    ans = ans == -1 ? price : Math.Min(ans, price);
                    continue;
                }
                int next = FindPrice(dic, to, dst, index, k);
                ans = next == -1 ? ans : (ans == -1 ? price + next : Math.Min(ans, price + next));
            }
            return ans;
        }
}
// @lc code=end

