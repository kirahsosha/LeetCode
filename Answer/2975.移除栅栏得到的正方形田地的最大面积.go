import "sort"

/*
 * @lc app=leetcode.cn id=2975 lang=golang
 *
 * [2975] 移除栅栏得到的正方形田地的最大面积
 */

// @lc code=start
func maximizeSquareArea(m int, n int, hFences []int, vFences []int) int {
	MOD := int64(1000000007)
	sort.Ints(hFences)
	hLength := make(map[int]bool)
	hLength[m-1] = true
	for i := 0; i < len(hFences); i++ {
		hLength[hFences[i]-1] = true
		hLength[m-hFences[i]] = true
		for j := i + 1; j < len(hFences); j++ {
			hLength[hFences[j]-hFences[i]] = true
		}
	}

	sort.Ints(vFences)
	vLength := make(map[int]bool)
	vLength[n-1] = true
	for i := 0; i < len(vFences); i++ {
		vLength[vFences[i]-1] = true
		vLength[n-vFences[i]] = true
		for j := i + 1; j < len(vFences); j++ {
			vLength[vFences[j]-vFences[i]] = true
		}
	}

	res := int64(0)
	for length, _ := range hLength {
		if vLength[length] {
			res = max(res, int64(length))
		}
	}

	if res == int64(0) {
		return -1
	} else {
		return int(res * res % MOD)
	}
}

// @lc code=end
