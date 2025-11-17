/*
 * @lc app=leetcode.cn id=204 lang=csharp
 *
 * [204] 计数质数
 */

// @lc code=start
public class Solution {
    public int CountPrimes(int n) {
        if(n < 3) return 0;
        if(n == 3) return 1;
        if(n == 4) return 2;
        int c = 2;
        for(int i = 4; i < n; i++)
        {
            int k = 2;
            while(k * k <= i)
            {
                if(i % k == 0) break;
                k++;
            }
            if(k * k > i) c++;
        }
        return c;
    }
}
// @lc code=end

