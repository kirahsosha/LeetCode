/*
 * @lc app=leetcode.cn id=342 lang=csharp
 *
 * [342] 4的幂
 */

// @lc code=start
public class Solution
{
    public bool IsPowerOfFour(int num)
    {
        if (num < 1) return false;
        if (num == 1) return true;
        if ((num & (num - 1)) != 0) return false;
        int checknum = 1431655764;
        if ((num & checknum) != num) return false;
        if ((num | checknum) != checknum) return false;
        return true;
    }
}
// @lc code=end

