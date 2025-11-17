/*
 * @lc app=leetcode.cn id=118 lang=csharp
 *
 * [118] 杨辉三角
 */

// @lc code=start
public class Solution
{
    public IList<IList<int>> Generate(int numRows)
    {
        var res = new List<IList<int>>();
        res.Add(new List<int> { 1 });
        for (int i = 1; i < numRows; i++)
        {
            var row = new List<int>();
            row.Add(1);
            for (int j = 1; j < i; j++)
            {
                row.Add(res[i - 1][j - 1] + res[i - 1][j]);
            }
            row.Add(1);
            res.Add(row);
        }
        return res;
    }
}
// @lc code=end

