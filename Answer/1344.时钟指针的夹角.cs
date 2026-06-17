/*
 * @lc app=leetcode.cn id=1344 lang=csharp
 *
 * [1344] 时钟指针的夹角
 */

// @lc code=start
public class Solution {
    public double AngleClock(int hour, int minutes) {
        double hourAngle = (hour % 12) * 30 + minutes * 0.5;
        double minuteAngle = minutes * 6;
        double angle = Math.Abs(hourAngle - minuteAngle);
        return Math.Min(angle, 360 - angle);
    }
}
// @lc code=end
