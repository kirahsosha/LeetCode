/*
 * @lc app=leetcode.cn id=174 lang=csharp
 *
 * [174] 地下城游戏
 */

// @lc code=start
public class Solution {
    //首先按初始为0计算血量
    //minHP[m][n] - 到达每一格的路径中出现的最低血量的最大值
    //curHP[m][n] - 出现minHP的情况时的当前血量
    //预处理
    //minHP/curHP[0][0] = dungeon[0][0]
    //minHP[i][0] = min(minHP[i - 1][0], curHP[i - 1][0] + dungeon[i][0])
    //minHP[0][j] = min(minHP[0][j - 1], curHP[0][j - 1] + dungeon[0][j])
    //curHP[i][0] = curHP[i - 1][0] + dungeon[i][0]
    //curHP[0][j] = curHP[0][j - 1] + dungeon[0][j]
    //状态转移方程
    //minHP[i][j] = max(min(minHP[i - 1][j], curHP[i - 1][j] + dungeon[i][j]),
    //                  min(minHP[i][j - 1], curHP[i][j - 1] + dungeon[i][j]))
    //curHP[i][j] = (curHP[i - 1][j] || curHP[i][j - 1]) + dungeon[i][j]
    //以上会出现局部最优不是整体最优的情况
    //反过来从终点往前倒推
    //dp[m + 1][n + 1] - 从终点往起点走到达每一格的路径中出现的最低需求血量的最大值
    //预处理
    //dp[n][m - 1] = dp[n - 1][m] = 1
    //状态转移方程
    //dp[i][j] = max(1, min(dp[i + 1][j], dp[i][j + 1]) - dungeon[i][j])
    public int CalculateMinimumHP(int[][] dungeon) {
        int m = dungeon.Length;
        int n = dungeon[0].Length;
        int[][] dp = new int[m + 1][];
        for(int i = m; i >= 0; i--)
        {
            dp[i] = new int[n + 1];
            for(int j = n; j >= 0; j--)
            {
                dp[i][j] = int.MaxValue;
            }
        }
        //预处理
        dp[m][n - 1] = 1;
        dp[m - 1][n] = 1;
        //状态转移
        for (int i = m - 1; i >= 0; i--)
        {
            for (int j = n - 1; j >= 0; j--)
            {
                int minHP = Math.Min(dp[i + 1][j], dp[i][j + 1]);
                dp[i][j] = Math.Max(1, minHP - dungeon[i][j]);
            }
        }
        return dp[0][0];
    }
}
// @lc code=end