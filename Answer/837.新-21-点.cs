/*
 * @lc app=leetcode.cn id=837 lang=csharp
 *
 * [837] 新21点
 */

// @lc code=start
public class Solution {
    public double New21Game(int N, int K, int W) {
        if (K == 0)
        {
            return 1.0;
        }
        double[] dp = new double[K + W];
        //获胜的分数区间[k, min(n, k+w-1)],当分数落到这个区间，胜率为1
        //分数不少于k时，抽牌就停止
        //所以，还需要抽牌的最大分数是就是k-1 (换言之，分数大于k-1就不再抽卡了)
        //当分数是k - 1时，再从[1, w]中抽一张卡，可得到的分数是[k, k + w]
        //又因为分数不超过n才胜利，所以：胜利区间是：[k, min(n, k+w-1)]
        for (int i = K; i <= N && i < K + W; i++)
        {
            dp[i] = 1.0;
        }
        //当目前分数x=k-1时，再抽一张牌结束。如果再抽的牌在区间[1, n - (k-1)], 则胜利
        dp[K - 1] = 1.0 * Math.Min(N - K + 1, W) / W;
            
        for (int i = K - 2; i >= 0; i--)
        {
            //状态转移方程
            dp[i] = (dp[i + 1] - dp[i + W + 1])/W + dp[i + 1];
        }

        return dp[0];
    }
}
// @lc code=end

