/*
 * @lc app=leetcode.cn id=3418 lang=csharp
 *
 * [3418] 机器人可以获得的最大金币数
 */

// @lc code=start
public class Solution
{
    public int MaximumAmount(int[][] coins)
    {
        var m = coins.Length;
        var n = coins[0].Length;
        return n <= m ? Solve(m, n, false) : Solve(n, m, true);

        int Solve(int rows, int cols, bool transposed)
        {
            const int NegInf = int.MinValue / 4;
            var dp0 = new int[cols];
            var dp1 = new int[cols];
            var dp2 = new int[cols];
            Array.Fill(dp0, NegInf);
            Array.Fill(dp1, NegInf);
            Array.Fill(dp2, NegInf);

            for (var r = 0; r < rows; r++)
            {
                var left0 = NegInf;
                var left1 = NegInf;
                var left2 = NegInf;
                for (var c = 0; c < cols; c++)
                {
                    var up0 = dp0[c];
                    var up1 = dp1[c];
                    var up2 = dp2[c];

                    int best0;
                    int best1;
                    int best2;
                    if (r == 0 && c == 0)
                    {
                        best0 = 0;
                        best1 = 0;
                        best2 = 0;
                    }
                    else
                    {
                        best0 = Math.Max(up0, left0);
                        best1 = Math.Max(up1, left1);
                        best2 = Math.Max(up2, left2);
                    }

                    var coin = transposed ? coins[c][r] : coins[r][c];
                    var cur0 = best0 + coin;
                    var cur1 = Math.Max(best1 + coin, best0);
                    var cur2 = Math.Max(best2 + coin, best1);

                    dp0[c] = cur0;
                    dp1[c] = cur1;
                    dp2[c] = cur2;

                    left0 = cur0;
                    left1 = cur1;
                    left2 = cur2;
                }
            }

            var last = cols - 1;
            return Math.Max(dp0[last], Math.Max(dp1[last], dp2[last]));
        }
    }
}
// @lc code=end

