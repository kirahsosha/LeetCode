/*
 * @lc app=leetcode.cn id=48 lang=csharp
 *
 * [48] 旋转图像
 */

// @lc code=start
public class Solution
{
    public void Rotate(int[][] matrix)
    {
        int n = matrix.Length;
        if (n == 1) return;
        //Step.1 flip horizontal
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n / 2; j++)
            {
                var t = matrix[i][j];
                matrix[i][j] = matrix[i][n - j - 1];
                matrix[i][n - j - 1] = t;
            }
        }
        //Step.2 flip diagonal
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n - i; j++)
            {
                var t = matrix[i][j];
                matrix[i][j] = matrix[n - j - 1][n - i - 1];
                matrix[n - j - 1][n - i - 1] = t;
            }
        }
    }
}
// @lc code=end

