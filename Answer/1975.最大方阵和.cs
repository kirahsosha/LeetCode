/*
 * @lc app=leetcode.cn id=1975 lang=csharp
 *
 * [1975] 最大方阵和
 */

// @lc code=start
public class Solution
{
    public long MaxMatrixSum(int[][] matrix)
    {
        var n = matrix.Length;
        long sumPos = 0;
        long sumNeg = 0;
        int maxNeg = int.MinValue;
        int minPos = int.MaxValue;
        int countPos = 0;
        int countNeg = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                var k = matrix[i][j];
                if (k >= 0)
                {
                    countPos++;
                    sumPos += k;
                    minPos = Math.Min(minPos, k);
                }
                else
                {
                    countNeg++;
                    sumNeg -= k;
                    maxNeg = Math.Max(maxNeg, k);
                }
            }
        }
        if (countNeg % 2 == 0)
        {
            return sumPos + sumNeg;
        }
        else if (countPos == 0)
        {
            return sumPos + sumNeg + 2 * maxNeg;
        }
        else
        {
            return Math.Max(sumPos + sumNeg + 2 * maxNeg, sumPos + sumNeg - 2 * minPos);
        }
    }
}
// @lc code=end

