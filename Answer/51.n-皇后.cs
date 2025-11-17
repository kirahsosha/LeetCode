/*
 * @lc app=leetcode.cn id=51 lang=csharp
 *
 * [51] N 皇后
 */

// @lc code=start
public class Solution
{
    public IList<IList<string>> SolveNQueens(int n)
    {
        List<char[]> board = new List<char[]>();
        for (int i = 0; i < n; i++)
        {
            board.Add((new string(' ', n)).ToCharArray());
        }
        List<IList<string>> res = SolveNQueens(n, board, 0);
        return res;
    }

    private List<IList<string>> SolveNQueens(int n, List<char[]> board, int num)
    {
        var res = new List<IList<string>>();
        if (num == n)
        {
            res.Add(board.Select(b => new string(b)).ToList());
            return res;
        }
        //Put new queen in the num-th line.
        for (int i = 0; i < n; i++)
        {
            if (board[num][i] == '.') continue;
            var pos = SolveNQueens(num, i, n);
            var valid = true;
            foreach (var item in pos)
            {
                if (board[item[0]][item[1]] == 'Q')
                {
                    valid = false;
                    break;
                }
            }
            if (valid)
            {
                var newBoard = board.Select(b => new string(b).ToCharArray()).ToList();
                pos.ForEach(p => newBoard[p[0]][p[1]] = '.');
                newBoard[num][i] = 'Q';
                res.AddRange(SolveNQueens(n, newBoard, num + 1));
            }
        }
        return res;
    }

    private List<int[]> SolveNQueens(int x, int y, int n)
    {
        int[,] Moves = new[,] { { 1, 1 }, { 1, -1 }, { -1, 1 }, { -1, -1 }, { 1, 0 }, { -1, 0 }, { 0, 1 }, { 0, -1 } };
        var positions = new List<int[]>();
        for (var i = 0; i <= Moves.GetUpperBound(0); i++)
        {
            var index = 1;
            var newX = x + Moves[i, 0] * index;
            var newY = y + Moves[i, 1] * index;
            while (newX < n && newX >= 0 && newY < n && newY >= 0)
            {
                positions.Add(new int[] { newX, newY });
                index++;
                newX = x + Moves[i, 0] * index;
                newY = y + Moves[i, 1] * index;
            }
        }
        return positions;
    }
}
// @lc code=end

