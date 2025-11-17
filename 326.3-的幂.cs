/*
 * @lc app=leetcode.cn id=326 lang=csharp
 *
 * [326] 3的幂
 */

// @lc code=start
public class Solution {
    public bool IsPowerOfThree(int n) {
        if(n < 1) return false;
        while(n > 1)
        {
            if(n % 3 != 0) return false;
            n /= 3;
        }
        return true;
    }
}
// @lc code=end

