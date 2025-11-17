/*
 * @lc app=leetcode.cn id=1711 lang=csharp
 *
 * [1711] 大餐计数
 */

// @lc code=start
public class Solution {
    public const int MOD = 1000000007;
    public int CountPairs(int[] deliciousness) {
        if (deliciousness.Length <= 1) return 0;
        int maxVal = 0;
            foreach (int val in deliciousness)
            {
                maxVal = Math.Max(maxVal, val);
            }
            int maxSum = maxVal * 2;
            int ans = 0;
            Dictionary<int, int> dic = new Dictionary<int, int>();
            int n = deliciousness.Length;
            for (int i = 0; i < n; i++)
            {
                int val = deliciousness[i];
                for (int sum = 1; sum <= maxSum; sum <<= 1)
                {
                    int count = 0;
                    dic.TryGetValue(sum - val, out count);
                    ans = (ans + count) % MOD;
                }
                if (dic.ContainsKey(val))
                {
                    dic[val]++;
                }
                else
                {
                    dic.Add(val, 1);
                }
            }
            return ans;
    }
}
// @lc code=end

