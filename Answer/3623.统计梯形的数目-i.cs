/*
 * @lc app=leetcode.cn id=3623 lang=csharp
 *
 * [3623] 统计梯形的数目 I
 */

// @lc code=start
public class Solution
{
    const int MOD = 1000000007;
    public int CountTrapezoids(int[][] points)
    {
        //key：纵坐标；value：线段数量
        var dic = new Dictionary<int, long>();
        foreach (var point in points)
        {
            int y = point[1];
            if (dic.ContainsKey(y))
            {
                dic[y]++;
            }
            else
            {
                dic.Add(y, 1);
            }
        }
        long res = 0;
        long side = 0;
        foreach (var point in dic.Values)
        {
            long edge = point * (point - 1) / 2;
            res = (res + edge * side) % MOD;
            side = (side + edge) % MOD;
        }
        return (int)res;
    }
}
// @lc code=end

