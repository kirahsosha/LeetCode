/*
 * @lc app=leetcode.cn id=739 lang=csharp
 *
 * [739] 每日温度
 */

// @lc code=start
public class Solution {
    public int[] DailyTemperatures(int[] T) {
        int n = T.Length;
        int[] ans = new int[n];
        Stack<int> q = new Stack<int>();
        for(int i = 0; i < n - 1; i++)
        {
            if(T[i] < T[i + 1])
            {
                ans[i] = 1;
                while(q.Count > 0 && T[q.Peek()] < T[i + 1])
                {
                    int index = q.Pop();
                    ans[index] = i + 1 - index;
                }
            }
            else
            {
                q.Push(i);
            }
        }
        return ans;
    }
}
// @lc code=end

