/*
 * @lc app=leetcode.cn id=7 lang=cpp
 *
 * [7] 整数反转
 */

// @lc code=start
class Solution {
public:
    int reverse(int x) {
        int d[10] = { 0 }, len = 0;
        if(x == 0) return 0;
        if(x == INT_MIN) return 0;
        long y = 0;
        while(x != 0)
        {
            d[len] = x % 10;
            x /= 10;
            len++;
        }
        for(int i = 0; i < len; i++)
        {
            y = y * 10 + d[i];
        }
        if(y < INT_MIN || y > INT_MAX)
        {
            return 0;
        }
        x = (int)y;
        return x;
    }
};
// @lc code=end

