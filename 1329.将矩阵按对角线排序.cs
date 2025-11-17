/*
 * @lc app=leetcode.cn id=1329 lang=csharp
 *
 * [1329] 将矩阵按对角线排序
 */

// @lc code=start
public class Solution {
    public int[][] DiagonalSort(int[][] mat) {
        int m = mat.Length;
        int n = mat[0].Length;
        if(m == 1 || n == 1) return mat;
        //沿m方向排序
        for(int i = 0; i < m; i++)
        {
            //将对角线的值取出存入数组
            int[] t = new int[Math.Min(m - i, n)];
            for(int j = 0; j < t.Length; j++)
            {
                t[j] = mat[i + j][j];
            }
            Array.Sort(t);
            //将排序后的数组值存回矩阵
            for(int j = 0; j < t.Length; j++)
            {
                mat[i + j][j] = t[j];
            }
        }
        //沿n方向排序
        for(int i = 1; i < n; i++)
        {
            //将对角线的值取出存入数组
            int[] t = new int[Math.Min(m, n - i)];
            for(int j = 0; j < t.Length; j++)
            {
                t[j] = mat[j][i + j];
            }
            Array.Sort(t);
            //将排序后的数组值存回矩阵
            for(int j = 0; j < t.Length; j++)
            {
                mat[j][i + j] = t[j];
            }
        }
        return mat;
    }
}
// @lc code=end

