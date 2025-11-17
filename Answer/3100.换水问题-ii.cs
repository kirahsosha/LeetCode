/*
 * @lc app=leetcode.cn id=3100 lang=csharp
 *
 * [3100] 换水问题 II
 */

// @lc code=start
public class Solution
{
    public int MaxBottlesDrunk(int numBottles, int numExchange)
    {
        int res = numBottles;
        while (numBottles >= numExchange)
        {
            numBottles = numBottles - numExchange + 1;
            numExchange++;
            res++;
        }
        return res;
    }
}
// @lc code=end

