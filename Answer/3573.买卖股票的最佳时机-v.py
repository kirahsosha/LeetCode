#
# @lc app=leetcode.cn id=3573 lang=python3
#
# [3573] 买卖股票的最佳时机 V
#

# @lc code=start
class Solution:
    def maximumProfit(self, prices: List[int], k: int) -> int:
        # dp[prices.Length][k + 1][3]
        # i - 天数
        # j - 完成进行交易数
        # 0 - 当前不持有股票，如果有交易，完成交易
        # 1 - 当前持有普通交易的股票
        # 2 - 当前持有做空交易的股票
        # 状态转移：
        # dp[i][j][0] - 前一天没交易或卖出前一天的普通交易或买进前一天的做空交易: max(dp[i - 1][j][0], dp[i - 1][j][1] + prices[i], dp[i - 1][j][2] - prices[i])
        # dp[i][j][1] - 保持前一天的普通交易或买进新的普通交易: max(dp[i - 1][j][1], dp[i - 1][j - 1][0] - prices[i])
        # dp[i][j][2] - 保持前一天的做空交易或卖出新的做空交易: max(dp[i - 1][j][2], dp[i - 1][j - 1][0] + prices[i])
        # 优化：只需要i - 1交易情况
        # dp[k + 1][3]
        # dp[j][0] = max(dp[j][0], dp[j][1] + prices[i], dp[j][2] - prices[i])
        # dp[j][1] = max(dp[j][1], dp[j - 1][0] - prices[i])
        # dp[j][2] = max(dp[j][2], dp[j - 1][0] + prices[i])
        # 初始i == 0：
        # dp[j][0] = 0
        # dp[j][1] = -prices[0]
        # dp[j][2] = prices[0]

        n = len(prices)
        dp = [[0] * 3 for _ in range(k + 1)]
        for j in range(0, k + 1):
            dp[j] = [0, -prices[0], prices[0]]

        for i in range(1, n):
            # 由于j的状态取决于[前一天]的j - 1的状态，所以倒序遍历j，保证在计算j的时候j - 1还是前一天的结果
            for j in range(k, 0, -1):
                dp[j][0] = max(dp[j][0], dp[j][1] + prices[i], dp[j][2] - prices[i])
                dp[j][1] = max(dp[j][1], dp[j - 1][0] - prices[i])
                dp[j][2] = max(dp[j][2], dp[j - 1][0] + prices[i])
        return dp[k][0]
        
# @lc code=end

