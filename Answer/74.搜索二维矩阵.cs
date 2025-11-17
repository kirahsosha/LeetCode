/*
 * @lc app=leetcode.cn id=74 lang=csharp
 *
 * [74] 搜索二维矩阵
 */

// @lc code=start
public class Solution
{
    public bool SearchMatrix(int[][] matrix, int target)
    {
        if (target < matrix[0][0]) return false;
        //Find n
        var n = 0;
        for (int i = 0; i < matrix.Length; i++)
        {
            if (matrix[i][0] == target) return true;
            else if (matrix[i][0] > target)
            {
                n = i - 1;
                break;
            }
            n = i;
        }
        int left = 0, right = matrix[0].Length - 1;
        while (left < right)
        {
            var mid = (left + right) / 2;
            if (target == matrix[n][left] || target == matrix[n][mid] || target == matrix[n][right])
            {
                return true;
            }
            else if (target < matrix[n][left])
            {
                return false;
            }
            else if (target > matrix[n][right])
            {
                return false;
            }
            else if (target < matrix[n][mid])
            {
                right = mid - 1;
            }
            else
            {
                left = mid + 1;
            }
        }
        return false;
    }
}
// @lc code=end

