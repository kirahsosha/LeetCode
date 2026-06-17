/*
 * @lc app=leetcode.cn id=1344 lang=typescript
 *
 * [1344] 时钟指针的夹角
 */

// @lc code=start
function angleClock(hour: number, minutes: number): number {
    const hourAngle = (hour % 12) * 30 + minutes * 0.5;
    const minuteAngle = minutes * 6;
    const angle = Math.abs(hourAngle - minuteAngle);
    return Math.min(angle, 360 - angle);
}
// @lc code=end
