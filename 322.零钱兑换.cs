/*
 * @lc app=leetcode.cn id=322 lang=csharp
 *
 * [322] 零钱兑换
 */

// @lc code=start
public class Solution {
    public int CoinChange(int[] coins, int amount) {
        Dictionary<int, int> dic = new Dictionary<int, int>();
        dic.Add(0, 0);
        for(int i = 1; i <= amount; i++)
        {
            for(int j = coins.Length - 1; j >= 0; j--)
            {
                if (i - coins[j] < 0) continue;
                if (dic.ContainsKey(i) && dic.ContainsKey(i - coins[j]))
                {
                    dic[i] = Math.Min(dic[i], dic[i - coins[j]] + 1);
                }
                else if (dic.ContainsKey(i - coins[j]))
                {
                    dic.Add(i, dic[i - coins[j]] + 1);
                }
            }
        }
        if(dic.ContainsKey(amount)) return dic[amount];
        else return -1;
    }
}
// @lc code=end

