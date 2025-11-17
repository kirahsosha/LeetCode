/*
 * @lc app=leetcode.cn id=200 lang=csharp
 *
 * [200] 岛屿数量
 */

// @lc code=start
public class Solution {

    //将当前这块岛屿值改为2，并找它的上下左右是否存在1
    public void Change(char[][] grid, int i, int j, int m, int n)
    {
        grid[i][j] = '2';//岛屿为2
        
        if (j < (n - 1) && grid[i][j + 1] == '1')//他的右边是否有1，有就进入
        {
            Change(grid, i, j + 1, m, n);
        }
        if (i < (m - 1) && grid[i + 1][j] == '1')//他的下边是否有1，有就进入
        {
            Change(grid, i + 1, j, m, n);
        }
        if (j > 0 && grid[i][j - 1] == '1')//他的左边是否有1，有就进入
        {
            Change(grid, i, j - 1, m, n);
        }
        if(i > 0 && grid[i - 1][j]=='1')//他的上边是否有1，有就进入
        {
            Change(grid, i - 1, j, m, n);
        }
    }
        
    public int NumIslands(char[][] grid) {
        if(grid.Length == 0) return 0;
        if(grid[0].Length == 0) return 0;
        int m = grid.Length;
        int n = grid[0].Length;
        int counts = 0;
 
        for (int i = 0; i < m; i++)//循环遍历一遍
        {
            for (int j = 0; j < n; j++)
            {
                if (grid[i][j] == '1')
                {
                    Change(grid, i, j, m, n);
                    counts++;//完成一次算有一个岛屿
                }                  
            }
        }
        return counts;
    }
}
// @lc code=end

