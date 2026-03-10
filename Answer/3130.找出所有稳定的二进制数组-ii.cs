/*
 * @lc app=leetcode.cn id=3130 lang=csharp
 *
 * [3130] 找出所有稳定的二进制数组 II
 */

// @lc code=start
public class Solution
{
    const int MOD = 1000000007;
    public int NumberOfStableArrays(int zero, int one, int limit)
    {
        int dfs(int i, int j, int k, int limit, int[][][] memo)
        {
            if (i == 0)
            {
                // 递归边界
                return k == 1 && j <= limit ? 1 : 0;
            }
            if (j == 0)
            {
                // 递归边界
                return k == 0 && i <= limit ? 1 : 0;
            }
            if (memo[i][j][k] != -1)
            {
                // 之前计算过
                return memo[i][j][k];
            }
            if (k == 0)
            {
                // + MOD 保证答案非负
                memo[i][j][k] = (int)(((long)dfs(i - 1, j, 0, limit, memo) + dfs(i - 1, j, 1, limit, memo) +
                        (i > limit ? MOD - dfs(i - limit - 1, j, 1, limit, memo) : 0)) % MOD);
            }
            else
            {
                memo[i][j][k] = (int)(((long)dfs(i, j - 1, 0, limit, memo) + dfs(i, j - 1, 1, limit, memo) +
                        (j > limit ? MOD - dfs(i, j - limit - 1, 0, limit, memo) : 0)) % MOD);
            }
            return memo[i][j][k];
        }

        var memo = new int[zero + 1][][];
        for (var i = 0; i <= zero; i++)
        {
            memo[i] = new int[one + 1][];
            for (var j = 0; j <= one; j++)
            {
                memo[i][j] = [-1, -1]; // -1 表示没有计算过
            }
        }
        return (dfs(zero, one, 0, limit, memo) + dfs(zero, one, 1, limit, memo)) % MOD;
    }
}
// @lc code=end

