/*
 * @lc app=leetcode.cn id=576 lang=csharp
 *
 * [576] 出界的路径数
 */

// @lc code=start
public class Solution {
    public int FindPaths(int m, int n, int maxMove, int startRow, int startColumn)
    {
        if (maxMove == 0) return 0;
        const int MOD = 1000000007;
            //int[k][i][j] path 每一步到每个坐标的路径数
            //k - 当前步数
            //i - x坐标
            //j - y坐标
            //path[k][i][j] = path[k-1][i-1][j] + path[k-1][i+1][j] + path[k-1][i][j-1] + path[k-1][i][j+1]
            int[][][] path = new int[2][][];
            path[0] = new int[m][];
            path[1] = new int[m][];
            for (int i = 0; i < m; i++)
            {
                path[0][i] = new int[n];
                path[1][i] = new int[n];
            }
            path[0][startRow][startColumn] = 1;
            int po = 1;
            int pn = 0;
            int ans = 0;
            if (startRow == 0) ans++;
            if (startRow == m - 1) ans++;
            if (startColumn == 0) ans++;
            if (startColumn == n - 1) ans++;
            for (int k = 1; k < maxMove; k++)
            {
                po = 1 - po;
                pn = 1 - pn;
                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        path[pn][i][j] = 0;
                        if (i > 0) path[pn][i][j] = (path[pn][i][j] + path[po][i - 1][j]) % MOD;
                        if (i < m - 1) path[pn][i][j] = (path[pn][i][j] + path[po][i + 1][j]) % MOD;
                        if (j > 0) path[pn][i][j] = (path[pn][i][j] + path[po][i][j - 1]) % MOD;
                        if (j < n - 1) path[pn][i][j] = (path[pn][i][j] + path[po][i][j + 1]) % MOD;
                        //如果是靠边的点，下一步就可以出界
                        if (i == 0) ans = (ans + path[pn][i][j]) % MOD;
                        if (i == m - 1) ans = (ans + path[pn][i][j]) % MOD;
                        if (j == 0) ans = (ans + path[pn][i][j]) % MOD;
                        if (j == n - 1) ans = (ans + path[pn][i][j]) % MOD;
                    }
                }
            }
            return ans;
    }
}
// @lc code=end

