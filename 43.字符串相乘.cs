/*
 * @lc app=leetcode.cn id=43 lang=csharp
 *
 * [43] 字符串相乘
 */

// @lc code=start
public class Solution {

    public int MultiNum(char c, int n2, int n3)
    {
        int n1 = int.Parse(c);
        return n1 * n2 + n3;
    }

    public string MultiOne(string num1, int n, int index)
    {
        int t = 0;
        foreach(char c in num1)
        {
            t = MultiNum(c, n, t);
        }
    }

    public string Multiply(string num1, string num2) {
        int l1 = num1.Length;
        int l2 = num2.Length;
    }
}
// @lc code=end

