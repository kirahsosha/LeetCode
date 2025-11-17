/*
 * @lc app=leetcode.cn id=374 lang=csharp
 *
 * [374] 猜数字大小
 */

// @lc code=start
/** 
 * Forward declaration of guess API.
 * @param  num   your guess
 * @return 	     -1 if num is lower than the guess number
 *			      1 if num is higher than the guess number
 *               otherwise return 0
 * int guess(int num);
 */

public class Solution : GuessGame {
    public int GuessNumber(int n) {
        if(guess(1) == 0) return 1;
        if(guess(n) == 0) return n;
        int left = 1;
        int right = n;
        int ans = left + (right - left) / 2;
        int check = guess(ans);
        while(left < right)
        {
            if(check > 0)
            {
                left = ans + 1;
            }
            else if(check < 0)
            {
                right = ans - 1;
            }
            else
            {
                return ans;
            }
            ans = left + (right - left) / 2;
            check = guess(ans);
        }
        return ans;
    }
}
// @lc code=end

