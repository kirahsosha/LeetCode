/*
 * @lc app=leetcode.cn id=412 lang=csharp
 *
 * [412] Fizz Buzz
 */

// @lc code=start
public class Solution {
    public IList<string> FizzBuzz(int n) {
        IList<string> s = new List<string>();
        for(int i = 0; i < n; i++)
        {
            if((i + 1) % 15 == 0) s.Add("FizzBuzz");
            else if((i + 1) % 5 == 0) s.Add("Buzz");
            else if((i + 1) % 3 == 0) s.Add("Fizz");
            else s.Add((i + 1).ToString());
        }
        return s;
    }
}
// @lc code=end