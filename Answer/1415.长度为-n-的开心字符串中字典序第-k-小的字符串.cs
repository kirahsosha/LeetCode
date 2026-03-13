/*
 * @lc app=leetcode.cn id=1415 lang=csharp
 *
 * [1415] 长度为 n 的开心字符串中字典序第 k 小的字符串
 */

// @lc code=start
public class Solution
{
    public string GetHappyString(int n, int k)
    {
        var chars = new char[] { 'a', 'b', 'c' };
        var res = new StringBuilder();
        if (k > 3 * (1 << (n - 1)))
        {
            return res.ToString();
        }
        for (int i = 0; i < n; i++)
        {
            int count = 1 << (n - i - 1);
            foreach (char c in chars)
            {
                if (res.Length > 0 && res[^1] == c)
                {
                    continue;
                }
                if (k <= count)
                {
                    res.Append(c);
                    break;
                }
                k -= count;
            }
        }
        return res.ToString();
    }
}
// @lc code=end

