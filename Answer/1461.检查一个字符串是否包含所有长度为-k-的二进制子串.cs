/*
 * @lc app=leetcode.cn id=1461 lang=csharp
 *
 * [1461] 检查一个字符串是否包含所有长度为 K 的二进制子串
 */

// @lc code=start
public class Solution
{
    public bool HasAllCodes(string s, int k)
    {
        if (s.Length <= k) return false;
        var num = 0;
        var check = 0;
        var set = new HashSet<int>();
        for (int i = 0; i < k; i++)
        {
            var t = s[i] - '0';
            num = (num << 1) + t;
            check = (check << 1) + 1;
        }
        set.Add(num);
        for (int i = k; i < s.Length; i++)
        {
            var t = s[i] - '0';
            num = ((num << 1) + t) & check;
            set.Add(num);
        }
        return set.Count == (int)Math.Pow(2, k);
    }
}
// @lc code=end

