/*
 * @lc app=leetcode.cn id=2141 lang=golang
 *
 * [2141] 同时运行 N 台电脑的最长时间
 */

// @lc code=start
func maxRunTime(n int, batteries []int) int64 {
    //可运行时间不超过平均时间
	total := int64(0)
	for _, num := range batteries {
		total += int64(num)
	}
	l := int64(0)
	r := total / int64(n)
	res := int64(0)
	for l <= r {
		//二分，假设能运行t分钟，b >= t的电池只能给一台电脑使用，b < t的电池可以组合使用
		t := int64(0)
		t = l + (r - l) / 2
		sum := int64(0)
		for _, b := range batteries {
			sum += min(int64(b), t)
		}
		if int64(n) * t <= sum {
			//可以运行t分钟，下一轮查找范围[t,r)
			res = t
			l = t + 1
		} else {
			//无法运行t分钟，下一轮查找范围[l,t)
			r = t - 1
		}
	}
	return res
}
// @lc code=end

