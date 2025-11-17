/*
 * @lc app=leetcode.cn id=1449 lang=csharp
 *
 * [1449] 数位成本和为目标值的最大数字
 */

// @lc code=start
public class Solution {
    public string LargestNumber(int[] cost, int target) {
        //使用前i个数位且花费总成本恰好为j时的最大位数
        //sum[i+1][j] = sum[i][j]
        int[][] sum = new int[9][target];
        for(int i = 0; i < 9; i++)
        {
            for(int j = 1; j < max; j++)
            {
                if(j * cost[i] <= target)
                {
                    sum[i][j] = j * cost[i];
                }
            }
        }
    }
}
// @lc code=end

