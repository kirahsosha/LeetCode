/*
 * @lc app=leetcode.cn id=682 lang=csharp
 *
 * [682] 棒球比赛
 */

// @lc code=start
public class Solution {
    public int CalPoints(string[] ops) {
        if(ops.Length == 0) return 0;
        int[] score = new int[ops.Length];
        int i = 0;
        foreach(string s in ops)
        {
            switch(s)
            {
                case "+":
                    if(i > 1) score[i] = score[i - 1] + score[i - 2];
                    else if(i == 1) score[i] = score[i - 1];
                    else score[i] = 0;
                    i++;
                break;
                case "D":
                    if(i > 0) score[i] = 2 * score[i - 1];
                    else score[i] = 0;
                    i++;
                break;
                case "C":
                    if(i > 0) i--;
                break;
                default:
                    score[i] = int.Parse(s);
                    i++;
                break;
            }
        }
        int ans = 0;
        for(int t = 0; t < i; t++)
        {
            ans += score[t];
        }
        return ans;
    }
}
// @lc code=end

