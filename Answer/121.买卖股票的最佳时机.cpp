/*
 * @lc app=leetcode.cn id=121 lang=cpp
 *
 * [121] 买卖股票的最佳时机
 */

// @lc code=start
class Solution {
public:
    int maxProfit(vector<int>& prices) {
		if (prices.size() < 2) return 0;
		int min = prices[0], max = prices[0], maxp = 0;
		for (int i = 1; i < prices.size(); i++)
		{
			if (prices[i] < min)
			{
				maxp = maxp > (max - min) ? maxp : (max - min);
				min = prices[i];
				max = 0;
			}
			else if (prices[i] > max)
			{
				max = prices[i];
			}
		}
		maxp = maxp > (max - min) ? maxp : (max - min);
        return maxp;
    }
};
// @lc code=end

