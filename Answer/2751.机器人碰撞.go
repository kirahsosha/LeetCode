import "sort"

/*
 * @lc app=leetcode.cn id=2751 lang=golang
 *
 * [2751] 机器人碰撞
 */

// @lc code=start
func survivedRobotsHealths(positions []int, healths []int, directions string) []int {
	n := len(positions)
	order := make([]int, n)
	for i := 0; i < n; i++ {
		order[i] = i
	}

	sort.Slice(order, func(i, j int) bool {
		return positions[order[i]] < positions[order[j]]
	})

	rightStack := make([]int, 0, n)
	for _, i := range order {
		if directions[i] == 'R' {
			rightStack = append(rightStack, i)
			continue
		}

		for len(rightStack) > 0 && healths[i] > 0 {
			j := rightStack[len(rightStack)-1]
			if healths[j] < healths[i] {
				rightStack = rightStack[:len(rightStack)-1]
				healths[i]--
				healths[j] = 0
			} else if healths[j] > healths[i] {
				healths[j]--
				healths[i] = 0
			} else {
				rightStack = rightStack[:len(rightStack)-1]
				healths[j] = 0
				healths[i] = 0
			}
		}
	}

	ans := make([]int, 0, n)
	for i := 0; i < n; i++ {
		if healths[i] > 0 {
			ans = append(ans, healths[i])
		}
	}

	return ans
}

// @lc code=end
