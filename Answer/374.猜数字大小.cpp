/*
 * @lc app=leetcode.cn id=374 lang=cpp
 *
 * [374] 猜数字大小
 */

// @lc code=start
// Forward declaration of guess API.
// @param num, your guess
// @return -1 if my number is lower, 1 if my number is higher, otherwise return 0
int guess(int num);

class Solution {
public:
    int guessNumber(int n) {
        if(guess(n) == 0) return n;
        long a = 1, b = n;
        int c = 0;
        while(a != b)
        {
            c = guess((a + b) / 2);
            if(c == 0) return (a + b) / 2;
            else if(c == 1)
            {
                a = (a + b) / 2;
            }
            else
            {
                b = (a + b) / 2;
            }
        }
        return a;
    }
};
// @lc code=end

