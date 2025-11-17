/*
 * @lc app=leetcode.cn id=119 lang=cpp
 *
 * [119] 杨辉三角 II
 */

// @lc code=start
class Solution {
public:
    vector<int> getRow(int rowIndex) {
		vector<vector<int>> n(rowIndex + 1);
		for (int i = 0; i <= rowIndex; i++)
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
		return n[rowIndex];
    }
};
// @lc code=end

