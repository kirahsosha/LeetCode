/*
 * @lc app=leetcode.cn id=3577 lang=csharp
 *
 * [3577] 统计计算机解锁顺序排列数
 */

// @lc code=start
public class Solution
{
    public int CountPermutations(int[] complexity)
    {
        int MOD = 1000000007;
        //complexity[0]必须是唯一最小值
        if (complexity.Count(c => c <= complexity[0]) > 1)
        {
            return 0;
        }
        long res = 1;
        for (int i = 1; i < complexity.Length; i++)
        {
            res = res * i % MOD;
        }
        return (int)res;
    }
}
// @lc code=end

