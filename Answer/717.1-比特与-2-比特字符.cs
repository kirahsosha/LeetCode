/*
 * @lc app=leetcode.cn id=717 lang=csharp
 *
 * [717] 1 比特与 2 比特字符
 */

// @lc code=start
public class Solution
{
    public bool IsOneBitCharacter(int[] bits)
    {
        if (bits.Length == 1) return true;
        var n = bits.Length;
        var index = 0;
        while (index < n)
        {
            if (bits[index] == 1)
            {
                index += 2;
                if (index >= n) return false;
            }
            else
            {
                index += 1;
                if (index == n) return true;
            }
        }
        return true;
    }
}
// @lc code=end

