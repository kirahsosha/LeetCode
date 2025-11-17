/*
 * @lc app=leetcode.cn id=1395 lang=csharp
 *
 * [1395] 统计作战单位数
 */

// @lc code=start
public class Solution {
    public int NumTeams(int[] rating) {
        if(rating.Length < 3) return 0;
        int ans = 0;
        int n = rating.Length;
        for(int i = 0; i < n - 2; i++)
        {
            for(int j = i + 1; j < n - 1; j++)
            {
                if(rating[j] > rating[i])
                {
                    for(int k = j + 1; k < n; k++)
                    {
                        if(rating[k] > rating[j]) ans++;
                    }
                }
                else if(rating[j] < rating[i])
                {
                    for(int k = j + 1; k < n; k++)
                    {
                        if(rating[k] < rating[j]) ans++;
                    }
                }
            }
        }
        return ans;
    }
}
// @lc code=end

