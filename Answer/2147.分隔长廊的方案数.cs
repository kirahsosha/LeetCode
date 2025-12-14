/*
 * @lc app=leetcode.cn id=2147 lang=csharp
 *
 * [2147] 分隔长廊的方案数
 */

// @lc code=start
public class Solution
{
    const int MOD = 1000000007;
    public int NumberOfWays(string corridor)
    {
        var list = new List<int>();
        for (int i = 0; i < corridor.Length; i++)
        {
            if (corridor[i] == 'S')
            {
                list.Add(i);
            }
        }
        if (list.Count == 0 || list.Count % 2 == 1)
        {
            return 0;
        }
        int index = 0;
        long res = 1;
        for (int i = 1; i < list.Count - 1; i++)
        {
            if (index == 0)
            {
                index = list[i];
            }
            else
            {
                res = res * (list[i] - index) % MOD;
                index = 0;
            }
        }
        return (int)res;
    }
}
// @lc code=end

