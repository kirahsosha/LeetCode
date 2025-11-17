/*
 * @lc app=leetcode.cn id=1337 lang=csharp
 *
 * [1337] 方阵中战斗力最弱的 K 行
 */

// @lc code=start
public class Solution {
    public int getSum(int[] m)
    {
        int t = 0;
        for(int i = 0; i < m.Length; i++)
        {
            t += m[i];
        }
        return t;
    }

    public int[] KWeakestRows(int[][] mat, int k) {
        int m = mat.Length;
        int n = mat[0].Length;
        int[] min = new int[k];
        int[] sum = new int[m];
        //初始化min和sum
        for(int i = 0; i < k; i++)
        {
            min[i] = -1;
        }
        for(int i = 0; i < m; i++)
        {
            sum[i] = getSum(mat[i]);
        }
        for(int i = 0; i < m; i++)
        {
            int x = i;
            //与当前最低k行比较, 注意j是min数组的下标
            for(int j = 0; j < k; j++)
            {
                if(min[j] == -1)
                {
                    min[j] = x;
                    break;
                }
                //值大于当前值, 直接后移
                if(sum[x] > sum[min[j]])
                {
                    continue;
                }
                //值等于当前值, 比较下标
                else if(sum[x] == sum[min[j]])
                {
                    if(x < min[j])
                    {
                        //将x填入当前值，当前值后移
                        int y = x;
                        x = min[j];
                        min[j] = y;
                    }
                    else
                    {
                        continue;
                    }
                }
                else
                {
                    //将x填入当前值，当前值后移
                    int y = x;
                    x = min[j];
                    min[j] = y;
                }
            }
        }
        return min;
    }
}
// @lc code=end

