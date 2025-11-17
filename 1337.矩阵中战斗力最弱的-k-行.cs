/*
 * @lc app=leetcode.cn id=1337 lang=csharp
 *
 * [1337] 矩阵中战斗力最弱的 K 行
 */

// @lc code=start
public class Solution {
    public int[] KWeakestRows(int[][] mat, int k) {
        List<int[]> list = new List<int[]>();
            for(int i = 0; i < mat.Length; i++)
            {
                int sum = mat[i].Sum();
                list.Add(new int[] { sum, i });
            }
            return list.OrderBy(p => p[0]).ThenBy(p => p[1]).Take(k).Select(p => p[1]).ToArray();
    }
}
// @lc code=end

