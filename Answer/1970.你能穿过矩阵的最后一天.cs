/*
 * @lc app=leetcode.cn id=1970 lang=csharp
 *
 * [1970] 你能穿过矩阵的最后一天
 */

// @lc code=start
public class Solution
{
    private static readonly int[][] dirs = new int[][] {
        new int[] {-1, 0}, new int[] {1, 0}, new int[] {0, -1}, new int[] {0, 1}
    };

    public int LatestDayToCross(int row, int col, int[][] cells)
    {
        int left = 0, right = row * col, ans = 0;
        while (left <= right)
        {
            int mid = (left + right) / 2;

            int[][] grid = new int[row][];
            for (int i = 0; i < row; i++)
            {
                grid[i] = new int[col];
                Array.Fill(grid[i], 1);
            }
            for (int i = 0; i < mid; i++)
            {
                grid[cells[i][0] - 1][cells[i][1] - 1] = 0;
            }

            Queue<int[]> q = new Queue<int[]>();
            for (int i = 0; i < col; i++)
            {
                if (grid[0][i] == 1)
                {
                    q.Enqueue(new int[] { 0, i });
                    grid[0][i] = 0;
                }
            }

            bool found = false;
            while (q.Count > 0)
            {
                int[] cell = q.Dequeue();
                int x = cell[0], y = cell[1];
                foreach (var dir in dirs)
                {
                    int nx = x + dir[0];
                    int ny = y + dir[1];
                    if (nx >= 0 && nx < row && ny >= 0 && ny < col && grid[nx][ny] == 1)
                    {
                        if (nx == row - 1)
                        {
                            found = true;
                            break;
                        }
                        q.Enqueue(new int[] { nx, ny });
                        grid[nx][ny] = 0;
                    }
                }
                if (found)
                {
                    break;
                }
            }

            if (found)
            {
                ans = mid;
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }
        return ans;
    }
}
// @lc code=end

