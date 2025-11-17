/*
 * @lc app=leetcode.cn id=122 lang=cpp
 *
 * [122] 买卖股票的最佳时机 II
 */

// @lc code=start
class Solution {
public:
    int maxProfit(vector<int>& prices) {
        if (prices.size() < 2) return 0;
		int min = prices[0], maxp = 0;
		for (int i = 1; i < prices.size(); i++)
		{
			if (prices[i] < min)
			{
				min = prices[i];
			}
			else
			{
				maxp += (prices[i] - min);
				min = prices[i];
			}
		}
        return maxp;
    }
};
// @lc code=end

