/*
 * @lc app=leetcode.cn id=542 lang=csharp
 *
 * [542] 01 矩阵
 */

// @lc code=start
public class Solution {
    public int[][] UpdateMatrix(int[][] matrix) {
        int m = matrix.Length;
        int n = matrix[0].Length;
        // 初始化动态规划的数组，所有的距离值都设置为一个很大的数
        int[][] dis = new int[m][];
        for(int i = 0; i < m; i++)
        {
            dis[i] = new int[n];
        }
        // 如果 (i, j) 的元素为 0，那么距离为 0
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (matrix[i][j] == 0) dis[i][j] = 0;
                else dis[i][j] = int.MaxValue / 2;
            }
        }
        // 只有 水平向左移动 和 竖直向上移动，注意动态规划的计算顺序
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (i - 1 >= 0)
                {
                    dis[i][j] = Math.Min(dis[i][j], dis[i - 1][j] + 1);
                }
                if (j - 1 >= 0)
                {
                    dis[i][j] = Math.Min(dis[i][j], dis[i][j - 1] + 1);
                }
            }
        }
        // 只有 水平向右移动 和 竖直向下移动，注意动态规划的计算顺序
        for (int i = m - 1; i >= 0; i--)
        {
            for (int j = n - 1; j >= 0; j--)
            {
                if (i + 1 < m)
                {
                    dis[i][j] = Math.Min(dis[i][j], dis[i + 1][j] + 1);
                }
                if (j + 1 < n)
                {
                    dis[i][j] = Math.Min(dis[i][j], dis[i][j + 1] + 1);
                }
            }
        }
        return dis;
    }
}
// @lc code=end

