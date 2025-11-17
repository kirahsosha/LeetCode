/*
 * @lc app=leetcode.cn id=264 lang=csharp
 *
 * [264] 丑数 II
 */

// @lc code=start
public class Solution {
    //状态转移方程 dp[i + 1] = min(dp[p2] * 2, dp[p3] * 3, dp[p5] * 5)
    public int NthUglyNumber(int n) {
        if(n == 1) return 1;
        int[] ans = new int[n + 1];
        int p2 = 1, p3 = 1, p5 = 1;
        ans[1] = 1;
        for(int i = 2; i <= n; i++)
        {
            ans[i] = Math.Min(ans[p2] * 2,
                     Math.Min(ans[p3] * 3, ans[p5] * 5));
            int t = p2;
            while(t <= i)
            {
                if(ans[t] * 2 > ans[i])
                {
                    p2 = t;
                    break;
                }
                t++;
            }
            t = p3;
            while(t <= i)
            {
                if(ans[t] * 3 > ans[i])
                {
                    p3 = t;
                    break;
                }
                t++;
            }
            t = p5;
            while(t <= i)
            {
                if(ans[t] * 5 > ans[i])
                {
                    p5 = t;
                    break;
                }
                t++;
            }
        }
        return ans[n];
    }
}
// @lc code=end

