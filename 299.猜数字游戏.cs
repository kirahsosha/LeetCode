/*
 * @lc app=leetcode.cn id=299 lang=csharp
 *
 * [299] 猜数字游戏
 */

// @lc code=start
public class Solution {
    public string GetHint(string secret, string guess) {
        bool[] t = new bool[secret.Length];
        int a = 0, b = 0;
        for (int i = 0; i < secret.Length; i++)
        {
            if (secret[i] == guess[i])
            {
                t[i] = true;
                a++;
            }
            else
            {
                for (int j = 0; j < secret.Length; j++)
                {
                    if (secret[i] == guess[j] && !t[j] && secret[j] != guess[j])
                    {
                        t[j] = true;
                        b++;
                        break;
                    }
                }
            }
        }
        return a + "A" + b + "B";
    }
}
// @lc code=end

