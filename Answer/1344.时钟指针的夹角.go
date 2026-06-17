/*
 * @lc app=leetcode.cn id=1344 lang=golang
 *
 * [1344] 时钟指针的夹角
 */

// @lc code=start
func angleClock(hour int, minutes int) float64 {
	hourAngle := float64(hour%12)*30 + float64(minutes)*0.5
	minuteAngle := float64(minutes) * 6
	angle := hourAngle - minuteAngle
	if angle < 0 {
		angle = -angle
	}
	if angle > 180 {
		angle = 360 - angle
	}
	return angle
}

// @lc code=end
