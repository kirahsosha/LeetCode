/*
 * @lc app=leetcode.cn id=744 lang=csharp
 *
 * [744] 寻找比目标字母大的最小字母
 */

// @lc code=start
public class Solution
{
    public char NextGreatestLetter(char[] letters, char target)
    {
        var index = 0;
        for (int i = 0; i < letters.Length; i++)
        {
            if (letters[i] > target)
            {
                index = i;
                break;
            }
        }
        return letters[index];
    }
}
// @lc code=end

