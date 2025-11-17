/*
 * @lc app=leetcode.cn id=258 lang=cpp
 *
 * [258] 各位相加
 */

// @lc code=start
class Solution {
public:
    int addDigits(int num) {
        if(num < 10) return num;
        while(num >= 10)
        {
            int i = 0;
            while(num > 0)
            {
                i += num % 10;
                num /= 10;
            }
            num = i;
        }
        return num;
    }
};
// @lc code=end

