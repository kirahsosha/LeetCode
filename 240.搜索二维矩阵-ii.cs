/*
 * @lc app=leetcode.cn id=240 lang=csharp
 *
 * [240] 搜索二维矩阵 II
 */

// @lc code=start
public class Solution
{
    public bool SearchMatrix(int[][] matrix, int target)
    {
        int m = matrix.Length;
        int n = matrix[0].Length;
        if (target < matrix[0][0] || target > matrix[m - 1][n - 1]) return false;
        for (int i = 0; i < m; i++)
        {
            if (target < matrix[i][0] || target > matrix[i][n - 1]) continue;
            int l = 0;
            int r = n - 1;
            while (l <= r)
            {
                int mid = (l + r) / 2;
                if (matrix[i][mid] == target) return true;
                if (matrix[i][mid] < target) l = mid + 1; //说明target不在左边
                else r = mid - 1; //说明target不在右边边
            }
        }
        return false;
    }
}
// @lc code=end

