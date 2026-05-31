/*
 * @lc app=leetcode.cn id=2126 lang=csharp
 *
 * [2126] 摧毁小行星
 */

// @lc code=start
using System;

public class Solution
{
    public bool AsteroidsDestroyed(int mass, int[] asteroids)
    {
        Array.Sort(asteroids);
        long currentMass = mass;
        foreach (int asteroid in asteroids)
        {
            if (currentMass < asteroid)
            {
                return false;
            }
            currentMass += asteroid;
        }
        return true;
    }
}
// @lc code=end
