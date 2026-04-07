/*
 * @lc app=leetcode.cn id=2069 lang=golang
 *
 * [2069] 模拟行走机器人 II
 */

// @lc code=start
type Robot struct {
	width  int
	height int
	step   int
}

func Constructor(width int, height int) Robot {
	return Robot{width, height, 0}
}

func (this *Robot) Step(num int) {
	this.step = (this.step+num-1)%((this.width+this.height-2)*2) + 1
}

func (this *Robot) getState() (x, y int, dir string) {
	w, h, step := this.width, this.height, this.step
	switch {
	case step < w:
		return step, 0, "East"
	case step < w+h-1:
		return w - 1, step - w + 1, "North"
	case step < w*2+h-2:
		return w*2 + h - step - 3, h - 1, "West"
	default:
		return 0, (w+h)*2 - step - 4, "South"
	}
}

func (this *Robot) GetPos() []int {
	x, y, _ := this.getState()
	return []int{x, y}
}

func (this *Robot) GetDir() string {
	_, _, d := this.getState()
	return d
}

/**
 * Your Robot object will be instantiated and called as such:
 * obj := Constructor(width, height);
 * obj.Step(num);
 * param_2 := obj.GetPos();
 * param_3 := obj.GetDir();
 */
// @lc code=end
