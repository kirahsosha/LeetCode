/*
 * @lc app=leetcode.cn id=1518 lang=csharp
 *
 * [1518] 换水问题
 */

// @lc code=start
public class Solution {
    public int NumWaterBottles(int numBottles, int numExchange)
    {
        int res = numBottles;
        while (numBottles >= numExchange)
        {
            res += numBottles / numExchange;
            numBottles = numBottles / numExchange + numBottles % numExchange;
        }
        return res;
    }
}
// @lc code=end

