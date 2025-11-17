/*
 * @lc app=leetcode.cn id=118 lang=cpp
 *
 * [118] 杨辉三角
 */

// @lc code=start
class Solution {
public:
    vector<vector<int>> generate(int numRows) {
		if (numRows == 0)
		{
			vector<vector<int>> n(0);
			return n;
		}
		vector<vector<int>> n(numRows);
		for (int i = 0; i < numRows; i++)
		{
            n[i] = vector<int>(i + 1);
			for (int j = 0; j < i + 1; j++)
			{
				if (j == 0 || j == i) n[i][j] = 1;
				else
				{
					n[i][j] = n[i - 1][j - 1] + n[i - 1][j];
				}
			}
		}
		return n;
    }
};
// @lc code=end

