/*
 * @lc app=leetcode.cn id=263 lang=csharp
 *
 * [263] 丑数
 */

// @lc code=start
public class Solution {
    public bool IsUgly(int num) {
        if (num < 1) return false;
        if (num < 6) return true;
        while (num % 2 == 0)
        {
            num /= 2;
        }
        while (num % 3 == 0)
        {
            num /= 3;
        }
        while (num % 5 == 0)
        {
            num /= 5;
        }
        if (num == 1) return true;
        return false;
    }
}
// @lc code=end

