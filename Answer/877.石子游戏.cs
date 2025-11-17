/*
 * @lc app=leetcode.cn id=877 lang=csharp
 *
 * [877] 石子游戏
 */

// @lc code=start
public class Solution {
    public bool StoneGame(int[] piles) {
        int N = piles.Length;
        int[,] dp = new int[N,N]; //i, j之间先手能赢的最大点数
        //初始化
        for(int i = 0; i < N; i++)
        {
            dp[i,i] = piles[i];
        }
        for(int dis = 1; dis < N; dis++) //下标间隔
        {
            for(int i = 0; i < N - dis; i++) //本次dp范围: i ~ i+dis
            {
                dp[i,i + dis] = 
                    Math.Max(piles[i] - dp[i+ 1,i + dis], 
                        piles[i + dis] - dp[i,i + dis - 1]);
            }
        }
        return dp[0,N - 1] > 0;
    }
}
// @lc code=end

