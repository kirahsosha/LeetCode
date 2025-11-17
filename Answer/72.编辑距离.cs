/*
 * @lc app=leetcode.cn id=72 lang=csharp
 *
 * [72] 编辑距离
 */

// @lc code=start
public class Solution {
    public int MinDistance(string word1, string word2) {
        if(word1.Length == 0) return word2.Length;
        if(word2.Length == 0) return word1.Length;
        int l1 = word1.Length;
        int l2 = word2.Length;
        //表示word1的前i个字母转换成word2的前j个字母所使用的最少操作
        //状态转移:
        //i指向word1, j指向word2, 若当前字母相同，则:
        //dp[i][j] = dp[i - 1][j - 1];
        //否则取增删替三个操作的最小值 + 1, 即:
        //dp[i][j] = min(dp[i][j - 1], dp[i - 1][j], dp[i - 1][j - 1]) + 1
        int[,] dp = new int[l1 + 1, l2 + 1];

        //基础情形, word1为空或word2为空
        for(int i = 0; i <= l1; i++)
        {
            dp[i, 0] = i;
        }
        for(int j = 0; j <= l2; j++)
        {
            dp[0, j] = j;
        }

        for(int i = 1; i <= l1; i++)
        {
            for(int j = 1; j <= l2; j++)
            {
                //当前字母相同
                if(word1[i - 1].Equals(word2[j - 1]))
                {
                    dp[i, j] = dp[i - 1, j - 1];
                }
                else
                {
                    //取增删替三个操作的最小值 + 1
                    dp[i, j] = 1 + Math.Min(Math.Min(
                        dp[i - 1, j], 
                        dp[i, j - 1]), 
                        dp[i - 1, j - 1]);
                }
            }
        }
        return dp[l1, l2];
    }
}
// @lc code=end

