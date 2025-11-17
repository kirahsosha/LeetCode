/*
 * @lc app=leetcode.cn id=9 lang=csharp
 *
 * [9] 回文数
 */

// @lc code=start
public class Solution {
    public bool IsPalindrome(int x)
    {
        if (x < 0) return false;
        if (x == 0) return true;
        int len = 0;
        int[] s = new int[10] {0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
        while (x != 0)
        {
            s[len] = x % 10;
            x /= 10;
            len++;
        }

        for (int i = 0; i < (len + 1) / 2; i++)
        {
            if (s[i] != s[len - i - 1]) return false;
        }

        return true;
    }
}
// @lc code=end

