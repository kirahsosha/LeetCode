/*
 * @lc app=leetcode.cn id=974 lang=csharp
 *
 * [974] 和可被 K 整除的子数组
 */

// @lc code=start
public class Solution {
    public int overMod(int n, int K)
    {
        while(n >= K || n <= -K)
        {
            n %= K;
        }
        if(n < 0) n += K;
        return n;
    }

    public int SubarraysDivByK(int[] A, int K) {
        if(A.Length == 1) return A[0] % K == 0 ? 1 : 0;
        int ans = 0;
        Hashtable sum = new Hashtable();
        int add = 0;
        sum.Add(0, 1);
        for(int i = 1; i < K; i++)
        {
            sum.Add(i, 0);
        }
        for(int i = 0; i < A.Length; i++)
        {
            add = overMod(add + A[i], K);
            ans += (int)sum[add];
            sum[add] = (int)sum[add] + 1;
        }
        return ans;
    }
}
// @lc code=end

