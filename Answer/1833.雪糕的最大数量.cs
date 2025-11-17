/*
 * @lc app=leetcode.cn id=1833 lang=csharp
 *
 * [1833] 雪糕的最大数量
 */

// @lc code=start
public class Solution {
    public int MaxIceCream(int[] costs, int coins) {
        costs = costs.OrderBy(p => p).ToArray();
        for (int i = 0; i < costs.Length; i++)
        {
            if(coins >= costs[i])
            {
                coins -= costs[i];
            }
            else
            {
                return i;
            }
        }
        return costs.Length;
    }
}
// @lc code=end

