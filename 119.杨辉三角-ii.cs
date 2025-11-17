/*
 * @lc app=leetcode.cn id=119 lang=csharp
 *
 * [119] 杨辉三角 II
 */

// @lc code=start
public class Solution {
    public IList<int> GetRow(int rowIndex) {
        IList<int> ans = new List<int>();
        ans.Add(1);
        for (int i = 1; i <= rowIndex; i++)
        {
            for (int j = i; j > 0; j--)
            {
                if (j == i) ans.Add(1);
                else ans[j] = ans[j - 1] + ans[j];
            }
        }
        return ans;
    }
}
// @lc code=end

