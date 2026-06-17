/*
 * @lc app=leetcode.cn id=1344 lang=java
 *
 * [1344] 时钟指针的夹角
 */

// @lc code=start
class Solution {

    public double angleClock(int hour, int minutes) {
        var hourAngle = (hour % 12) * 30 + minutes * 0.5;
        var minuteAngle = minutes * 6;
        var angle = Math.abs(hourAngle - minuteAngle);
        return Math.min(angle, 360 - angle);
    }
}
// @lc code=end

