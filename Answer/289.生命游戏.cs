/*
 * @lc app=leetcode.cn id=289 lang=csharp
 *
 * [289] 生命游戏
 */

// @lc code=start
public class Solution {
    public void GameOfLife(int[][] board) {
        int m = board.Length;
        int n = board[0].Length;
        int[,] newBoard = new int[m + 2, n + 2];
        //扩展数组，在边界添加0
        for(int i = 0; i < m + 2; i++)
        {
            for(int j = 0; j < n + 2; j++)
            {
                if(i == 0 
                || j == 0 
                || i == m + 1 
                || j == n + 1)
                {
                    newBoard[i, j] = 0;
                }
                else
                {
                    newBoard[i, j] = board[i - 1][j - 1];
                }
            }
        }
        //使用扩展后的数组计算新的状态，更新到原数组里
        for(int i = 1; i < m + 1; i++)
        {
            for(int j = 1; j < n + 1; j++)
            {
                int k = newBoard[i - 1, j - 1] 
                      + newBoard[i - 1, j] 
                      + newBoard[i - 1, j + 1] 
                      + newBoard[i, j - 1] 
                      + newBoard[i, j + 1] 
                      + newBoard[i + 1, j - 1] 
                      + newBoard[i + 1, j] 
                      + newBoard[i + 1, j + 1];
                if((board[i - 1][j - 1] == 1)
                    && (k < 2 || k > 3))
                {
                    board[i - 1][j - 1] = 0;
                }
                if(board[i - 1][j - 1] == 0
                    && k == 3)
                {
                    board[i - 1][j - 1] = 1;
                }
            }
        }
    }
}
// @lc code=end

