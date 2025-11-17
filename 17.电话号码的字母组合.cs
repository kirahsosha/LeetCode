/*
 * @lc app=leetcode.cn id=17 lang=csharp
 *
 * [17] 电话号码的字母组合
 */

// @lc code=start
public class Solution
{
    public IList<string> LetterCombinations(string digits)
    {
        if (digits.Length == 0) return new List<string>();
        var dic = new Dictionary<char, string>()
            {
                { '2', "abc" },
                { '3', "def" },
                { '4', "ghi" },
                { '5', "jkl" },
                { '6', "mno" },
                { '7', "pqrs" },
                { '8', "tuv" },
                { '9', "wxyz" },
            };
        var result = new List<string>();
        Combination(digits, 0, "", dic, result);
        return result;
    }

    private void Combination(string digits, int index, string combine, Dictionary<char, string> dic, List<string> result)
    {
        var mid = new List<string>();
        foreach (var c in dic[digits[index]])
        {
            mid.Add(combine + c);
        }
        if (index == digits.Length - 1)
        {
            result.AddRange(mid);
            return;
        }
        foreach (var s in mid)
        {
            Combination(digits, index + 1, s, dic, result);
        }
    }
}
// @lc code=end

