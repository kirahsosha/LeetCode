/*
 * @lc app=leetcode.cn id=274 lang=csharp
 *
 * [274] H 指数
 */

// @lc code=start
public class Solution {
    public int HIndex(int[] citations) {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            foreach(int i in citations)
            {
                if(dic.TryGetValue(i,out int value))
                {
                    dic[i] = value + 1;
                }
                else
                {
                    dic.Add(i, 1);
                }
            }
            var list = dic.OrderByDescending(p => p.Key).ToList();
            int ans = 0;
            int sum = 0;
            for(int i = 0; i < list.Count; i++)
            {
                var item = list[i];
                if (ans >= item.Key) return ans;
                sum = sum + item.Value;
                if(sum <= item.Key)
                {
                    ans = sum;
                }
                else
                {
                    ans = Math.Max(ans, item.Key);
                }
            }
            return ans;
    }
}
// @lc code=end

