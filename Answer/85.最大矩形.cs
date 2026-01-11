/*
 * @lc app=leetcode.cn id=85 lang=csharp
 *
 * [85] 最大矩形
 */

// @lc code=start
public class Solution
{
    public int MaximalRectangle(char[][] matrix)
    {
        var rows = matrix.Length;
        var cols = matrix[0].Length;
        var maxRow = new int[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            maxRow[i, 0] = matrix[i][0] - '0';
            for (int j = 1; j < cols; j++)
            {
                maxRow[i, j] = matrix[i][j] == '0' ? 0 : maxRow[i, j - 1] + 1;
            }
        }

        var res = 0;
        for (int j = 0; j < cols; j++)
        {
            int[] up = new int[rows];
            int[] down = new int[rows];
            Stack<int> stk = new Stack<int>();

            for (int i = 0; i < rows; i++)
            {
                while (stk.Count > 0 && maxRow[stk.Peek(), j] >= maxRow[i, j])
                    stk.Pop();
                up[i] = stk.Count == 0 ? -1 : stk.Peek();
                stk.Push(i);
            }

            stk.Clear();
            for (int i = rows - 1; i >= 0; i--)
            {
                while (stk.Count > 0 && maxRow[stk.Peek(), j] >= maxRow[i, j])
                    stk.Pop();
                down[i] = stk.Count == 0 ? rows : stk.Peek();
                stk.Push(i);
            }

            for (int i = 0; i < rows; i++)
            {
                int height = down[i] - up[i] - 1;
                res = Math.Max(res, height * maxRow[i, j]);
            }
        }
        return res;
    }
}
// @lc code=end

