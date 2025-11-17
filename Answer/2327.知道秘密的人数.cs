/*
 * @lc app=leetcode.cn id=2327 lang=csharp
 *
 * [2327] 知道秘密的人数
 */

// @lc code=start
public class Solution
{
    const int MOD = 1000000007;
    public int PeopleAwareOfSecret(int n, int delay, int forget)
    {
        int[] res = new int[n];
        res[0] = 1;
        int sum = 1;
        //1, 0, 1, 1, 1, 2
        for (int i = 1; i < n; i++)
        {
            res[i] = 0;
            for (int j = i - delay; j > i - forget; j--)
            {
                if (j < 0) break;
                res[i] = (res[i] + res[j]) % MOD;
            }
            if (i - forget >= 0)
            {
                sum = (sum + res[i] - res[i - forget]) % MOD;
            }
            else
            {
                sum = (sum + res[i]) % MOD;
            }
            while (sum < 0)
            {
                sum += MOD;
            }
        }

        return sum;
    }
}
// @lc code=end

