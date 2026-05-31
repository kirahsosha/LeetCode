/*
 * @lc app=leetcode.cn id=2126 lang=golang
 *
 * [2126] 摧毁小行星
 */

// @lc code=start
import "sort"

func asteroidsDestroyed(mass int, asteroids []int) bool {
	sort.Ints(asteroids)
	currentMass := int64(mass)
	for _, a := range asteroids {
		asteroidMass := int64(a)
		if currentMass < asteroidMass {
			return false
		}
		currentMass += asteroidMass
	}
	return true
}

// @lc code=end
