/*
 * @lc app=leetcode.cn id=191 lang=csharp
 *
 * [191] 位1的个数
 */

// @lc code=start
public class Solution {
    public int HammingWeight(uint n) {
        uint ans = 0;
        while(n > 0)
        {
            ans += n % 2;
            n = n / 2;
        }
        return (int)ans;
    }
}
// @lc code=end

