/*
 * @lc app=leetcode.cn id=1137 lang=csharp
 *
 * [1137] 第 N 个泰波那契数
 */

// @lc code=start
public class Solution {
    public static int[] T = new int[38];

    public int Tribonacci(int n) {
        if(n == 0) return 0;
        T[0] = 0;
        T[1] = 1;
        T[2] = 1;
        if(T[n] != 0) return T[n];
        T[n] = GetTribonacci(n);
        return T[n];
    }

    public int GetTribonacci(int i)
    {
        if(i == 0) return 0;
        if(T[i] != 0) return T[i];
        T[i] = GetTribonacci(i - 1) + GetTribonacci(i - 2) + GetTribonacci(i - 3);
        return T[i];
    }
}
// @lc code=end

