/*
 * @lc app=leetcode.cn id=299 lang=cpp
 *
 * [299] 猜数字游戏
 */

// @lc code=start
class Solution {
public:
    string getHint(string secret, string guess) {
        vector<bool> t(secret.length(), false);
        int a = 0, b = 0;
        for(int i = 0; i < secret.length(); i++)
        {
            if(secret[i] == guess[i])
            {
                t[i] = true;
                a++;
            }
            else
            {
                for(int j = 0; j < secret.length(); j++)
                {
                    if(secret[i] == guess[j] && !t[j] && secret[j] != guess[j])
                    {
                        t[j] = true;
                        b++;
                        break;
                    }
                }
            }
        }
        //string s = to_string(a);
        //s += "A";
        //s += to_string(b);
        //s += "B";
        return to_string(a) + "A" + to_string(b) + "B";
    }
};
// @lc code=end

