import "sort"

/*
 * @lc app=leetcode.cn id=1200 lang=golang
 *
 * [1200] 最小绝对差
 */

// @lc code=start
func minimumAbsDifference(arr []int) [][]int {
	ans := make([][]int, 0)
	minAbs := 1000000
	n := len(arr)
	sort.Ints(arr)
	for i := 0; i < n-1; i++ {
		currAbs := arr[i+1] - arr[i]
		if currAbs < minAbs {
			minAbs = currAbs
			ans = [][]int{{arr[i], arr[i+1]}}
		} else if currAbs == minAbs {
			ans = append(ans, []int{arr[i], arr[i+1]})
		}
	}
	return ans
}

// @lc code=end
