/*
 * @lc app=leetcode.cn id=551 lang=csharp
 *
 * [551] 学生出勤记录 I
 */

// @lc code=start
public class Solution {
    public bool CheckRecord(string s) {
        int num_ab = 0;
            int num_la = 0;
            foreach(var c in s)
            {
                if(c =='A')
                {
                    num_ab++;
                    num_la = 0;
                    if (num_ab == 2) return false;
                }
                else if(c == 'L')
                {
                    num_la++;
                    if (num_la == 3) return false;
                }
                else
                {
                    num_la = 0;
                }
            }
            return true;
    }
}
// @lc code=end

