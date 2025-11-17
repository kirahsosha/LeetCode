/*
 * @lc app=leetcode.cn id=79 lang=csharp
 *
 * [79] 单词搜索
 */

// @lc code=start
public class Solution
{
    public bool Exist(char[][] board, string word)
    {
        int row = board.GetLength(0);
        int col = board[0].GetLength(0);
        bool[,] used = new bool[row, col];

        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                if (CheckExist(board, word, i, j, 0, used)) return true;
            }
        }
        return false;
    }

    private bool CheckExist(char[][] board, string word, int i, int j, int k, bool[,] used)
    {
        if (board[i][j] != word[k])
        {
            return false;
        }
        if (k == word.Length - 1)
        {
            return true;
        }
        used[i, j] = true;
        if (i > 0 && used[i - 1, j] == false)
        {
            if (CheckExist(board, word, i - 1, j, k + 1, used)) return true;
        }
        if (j > 0 && used[i, j - 1] == false)
        {
            if (CheckExist(board, word, i, j - 1, k + 1, used)) return true;
        }
        if (i < board.Length - 1 && used[i + 1, j] == false)
        {
            if (CheckExist(board, word, i + 1, j, k + 1, used)) return true;
        }
        if (j < board[0].Length - 1 && used[i, j + 1] == false)
        {
            if (CheckExist(board, word, i, j + 1, k + 1, used)) return true;
        }
        used[i, j] = false;
        return false;
    }
}
// @lc code=end

