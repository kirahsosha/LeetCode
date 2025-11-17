/*
 * @lc app=leetcode.cn id=1111 lang=csharp
 *
 * [1111] 有效括号的嵌套深度
 */

// @lc code=start
public class Solution {
    public int[] MaxDepthAfterSplit(string seq) {
        int[] ans = new int[seq.Length];
        int da = 0, db = 0;
        for(int i = 0; i < seq.Length; i++)
        {
            if(seq[i] == '(')
            {
                if(da<=db)
                {
                    ans[i] = 0;
                    da++;
                }
                else
                {
                    ans[i] = 1;
                    db++;
                }
            }
            else
            {
                if(da>=db)
                {
                    ans[i] = 0;
                    da--;
                }
                else
                {
                    ans[i] = 1;
                    db--;
                }
            }
        }
        return ans;
    }
}
// @lc code=end

