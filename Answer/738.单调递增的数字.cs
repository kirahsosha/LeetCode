/*
 * @lc app=leetcode.cn id=738 lang=csharp
 *
 * [738] 单调递增的数字
 */

// @lc code=start
public class Solution {
    public int MonotoneIncreasingDigits(int N) {
        //个位数返回自身
        if(N < 10) return N;
        //结果有两种可能
        //1. 从个位开始往最高位，找到单减的最大值
        //2. 最高位比当前最高位的值小1, 其余位都是9
        string s = N.ToString();
        int len = s.Length;
        int t = 10; //当前计算的位数
        int num1 = 0; //情况1的结果
        int num2 = 0; //情况2的结果
        int numMax = N % 10; //计算到当前位满足条件的最大值
        int nine = 9; //情况2的累加值
        for(int i = 1; i < len; i++)
        {
            int k = N / t % 10;
            int km = Math.Min(numMax * 10 / t, k);
            num1 = km * t + numMax;
            if(k == 0)
            {
                num2 = numMax;
            }
            else
            {
                num2 = (k - 1) * t + nine;
            }
            numMax = Math.Max(num1, num2);

            t *= 10;
            nine = nine * 10 + 9;
        }
        return numMax;
    }
}
// @lc code=end

