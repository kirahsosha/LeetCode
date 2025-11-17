/*
 * @lc app=leetcode.cn id=342 lang=cpp
 *
 * [342] 4的幂
 */

// @lc code=start
class Solution {
public:
    bool isPowerOfFour(int num) {
        if(num < 1) return false;
        while(num > 1)
        {
            if(num % 4 != 0) return false;
            num /= 4;
        }
        return true;
    }
};
// @lc code=end

