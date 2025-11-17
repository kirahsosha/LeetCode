/*
 * @lc app=leetcode.cn id=258 lang=csharp
 *
 * [258] 各位相加
 */

// @lc code=start
public class Solution {
    public int AddDigits(int num)
    {
        while (num >= 10)
        {
            int i = 0;
            while (num > 0)
            {
                i += num % 10;
                num /= 10;
            }
            num = i;
        }
        return num;
    }
}
// @lc code=end

