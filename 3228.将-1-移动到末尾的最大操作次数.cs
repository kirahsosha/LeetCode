/*
 * @lc app=leetcode.cn id=3228 lang=csharp
 *
 * [3228] 将 1 移动到末尾的最大操作次数
 */

// @lc code=start
public class Solution
{
    public int MaxOperations(string s)
    {
        if (s.Length == 1) return 0;
        int count = 0;
        int moves = 0;
        int index = 0;
        while (index < s.Length)
        {
            int cnt = 0;
            while (index < s.Length && s[index] == '1')
            {
                cnt++;
                index++;
            }
            if (cnt > 0 && index != s.Length)
            {
                count += cnt;
                moves += count;
            }
            index++;
        }
        return moves;
    }
}
// @lc code=end

