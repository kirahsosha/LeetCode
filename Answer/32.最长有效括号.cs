/*
 * @lc app=leetcode.cn id=32 lang=csharp
 *
 * [32] 最长有效括号
 */

// @lc code=start
public class Solution
{
    public int LongestValidParentheses(string s)
    {
        if (s.Length <= 1) return 0;
        var stack = new Stack<int>();
        var dp = new int[s.Length];
        for (int i = 0; i < s.Length; i++)
        {
            dp[i] = 0;
            if (s[i] == '(')
            {
                stack.Push(i);
            }
            else if (stack.Count != 0)
            {
                var start = stack.Pop();
                dp[start] = i;
            }
        }
        int index = 0, cur = 0, max = 0;
        while (index < s.Length)
        {
            if (dp[index] == 0 && cur == 0)
            {
                index++;
            }
            else if (dp[index] == 0)
            {
                max = Math.Max(max, cur);
                cur = 0;
                index++;
            }
            else
            {
                cur += dp[index] - index + 1;
                index = dp[index] + 1;
            }
        }
        return Math.Max(max, cur);
    }
}
// @lc code=end

