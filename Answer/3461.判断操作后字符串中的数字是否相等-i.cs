/*
 * @lc app=leetcode.cn id=3461 lang=csharp
 *
 * [3461] 判断操作后字符串中的数字是否相等 I
 */

// @lc code=start
public class Solution
{
    public bool HasSameDigits(string s)
    {
        int index = s.Length;
        var chars = s.Select(c => c - '0').ToArray();
        while (index > 2)
        {
            int i = 0;
            while (i < index - 1)
            {
                chars[i] = (chars[i] + chars[i + 1]) % 10;
                i++;
            }
            index--;
        }
        return chars[0] == chars[1];
    }
}
// @lc code=end

