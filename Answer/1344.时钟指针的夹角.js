/*
 * @lc app=leetcode.cn id=1344 lang=javascript
 *
 * [1344] 时钟指针的夹角
 */

// @lc code=start
/**
 * @param {number} hour
 * @param {number} minutes
 * @return {number}
 */
var angleClock = function (hour, minutes) {
    var hourAngle = (hour % 12) * 30 + minutes * 0.5;
    var minuteAngle = minutes * 6;
    var angle = Math.abs(hourAngle - minuteAngle);
    return Math.min(angle, 360 - angle);
};
// @lc code=end
