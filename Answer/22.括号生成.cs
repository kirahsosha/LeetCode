/*
 * @lc app=leetcode.cn id=22 lang=csharp
 *
 * [22] 括号生成
 */

// @lc code=start
public class Solution {
    public IList<string> search(int n, int left, int right, string s, IList<string> brackets)
    {
        if(right == n)
        {
            brackets.Add(s);
            return brackets;
        }
        if(left < n)
        {
            brackets = search(n, left + 1, right, s + '(', brackets);
        }
        if(right < left)
        {
            brackets = search(n, left, right + 1, s + ')', brackets);
        }
        return brackets;
    }

    public IList<string> GenerateParenthesis(int n) {
        IList<string> brackets = new List<string>{};
        brackets = search(n, 1, 0, "(", brackets);
        return brackets;
    }
}
// @lc code=end

