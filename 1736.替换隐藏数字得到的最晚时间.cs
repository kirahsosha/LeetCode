/*
 * @lc app=leetcode.cn id=1736 lang=csharp
 *
 * [1736] 替换隐藏数字得到的最晚时间
 */

// @lc code=start
public class Solution {
    public string MaximumTime(string time) {
        char h1 = time[0];
            char h2 = time[1];
            char m1 = time[3];
            char m2 = time[4];
            //hour
            if (h1 == '?' && h2 == '?')
            {
                h1 = '2';
                h2 = '3';
            }
            else if(h1 == '?')
            {
                if(h2 <='3')
                {
                    h1 = '2';
                }
                else
                {
                    h1 = '1';
                }
            }
            else if(h2 =='?')
            {
                if (h1 <= '1')
                {
                    h2 = '9';
                }
                else
                {
                    h2 = '3';
                }
            }
            //minutes
            if(m1 =='?' && m2 == '?')
            {
                m1 = '5';
                m2 = '9';
            }
            else if (m1 == '?')
            {
                m1 = '5';
            }
            else if (m2 == '?')
            {
                m2 = '9';
            }
            return "" + h1 + h2 + ":" + m1 + m2;
    }
}
// @lc code=end

