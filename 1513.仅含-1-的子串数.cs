/*
 * @lc app=leetcode.cn id=1513 lang=csharp
 *
 * [1513] 仅含 1 的子串数
 */

// @lc code=start
public class Solution
{
    const int MOD = 1000000007;
    public int NumSub(string s)
    {
        long res = 0;
        long cnt = 0;
        foreach (char c in s)
        {
            if (c == '1')
            {
                cnt++;
            }
            else if (cnt > 0)
            {
                res = (res + (1 + cnt) * cnt / 2) % MOD;
                cnt = 0;
            }
        }
        if (cnt > 0)
        {
            res = (res + (1 + cnt) * cnt / 2) % MOD;
            cnt = 0;
        }
        return (int)res;
    }
}
// @lc code=end

