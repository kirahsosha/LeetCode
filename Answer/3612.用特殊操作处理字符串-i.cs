using System.Text;

/*
 * @lc app=leetcode.cn id=3612 lang=csharp
 *
 * [3612] 用特殊操作处理字符串 I
 */

// @lc code=start
public class Solution
{
    public string ProcessStr(string s)
    {
        var sb = new StringBuilder();
        foreach (var ch in s)
        {
            if (ch == '*')
            {
                if (sb.Length > 0)
                {
                    sb.Length--;
                }
            }
            else if (ch == '#')
            {
                sb.Append(sb.ToString());
            }
            else if (ch == '%')
            {
                for (int l = 0, r = sb.Length - 1; l < r; l++, r--)
                {
                    char tmp = sb[l];
                    sb[l] = sb[r];
                    sb[r] = tmp;
                }
            }
            else
            {
                sb.Append(ch);
            }
        }
        return sb.ToString();
    }
}
// @lc code=end
