/*
 * @lc app=leetcode.cn id=172 lang=cpp
 *
 * [172] 阶乘后的零
 */

// @lc code=start
class Solution {
public:
    int trailingZeroes(int n) {
        if(n == 0) return 0;
        int f = 0;
        while(n > 0)
        {
            n /= 5;
            f += n;
        }
        return f;
    }
};
// @lc code=end

