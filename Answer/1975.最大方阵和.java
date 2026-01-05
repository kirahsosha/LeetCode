
import java.util.PriorityQueue;

/*
 * @lc app=leetcode.cn id=1975 lang=java
 *
 * [1975] 最大方阵和
 */
// @lc code=start
class Solution {

    public long maxMatrixSum(int[][] matrix) {
        var n = matrix.length;
        long sumPos = 0;
        long sumNeg = 0;
        int maxNeg = Integer.MIN_VALUE;
        int minPos = Integer.MAX_VALUE;
        int countPos = 0;
        int countNeg = 0;
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                var k = matrix[i][j];
                if (k >= 0) {
                    countPos++;
                    sumPos += k;
                    minPos = Math.min(minPos, k);
                } else {
                    countNeg++;
                    sumNeg -= k;
                    maxNeg = Math.max(maxNeg, k);
                }
            }
        }
        if (countNeg % 2 == 0) {
            return sumPos + sumNeg;
        } else if (countPos == 0) {
            return sumPos + sumNeg + 2 * maxNeg;
        } else {
            return Math.max(sumPos + sumNeg + 2 * maxNeg, sumPos + sumNeg - 2 * minPos);
        }
    }
}
// @lc code=end

