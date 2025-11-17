/*
 * @lc app=leetcode.cn id=8 lang=csharp
 *
 * [8] 字符串转换整数 (atoi)
 */

// @lc code=start
public class Solution {
    public int MyAtoi(string str) {
        str = str.Trim();
        if(string.IsNullOrEmpty(str)) return 0;
        System.Text.RegularExpressions.Regex reg = 
            new System.Text.RegularExpressions.Regex(@"^[+-]?\d+");
        str = reg.Match(str).Value;
        if(string.IsNullOrEmpty(str)) return 0;
        int num = 0;
        if(int.TryParse(str, out num))
        {
            return num;
        }
        if(str.Length > 1 && str[0].Equals('-')) return int.MinValue;
        else return int.MaxValue;
    }
}
// @lc code=end

