/*
 * @lc app=leetcode.cn id=3741 lang=golang
 *
 * [3741] 三个相等元素之间的最小距离 II
 */

// @lc code=start
func minimumDistance(nums []int) int {
	dic := make(map[int][]int)
	ans := -1
	for i, num := range nums {
		if len(dic[num]) < 3 {
			dic[num] = append(dic[num], i)
		} else {
			dic[num][0], dic[num][1], dic[num][2] = dic[num][1], dic[num][2], i
		}
		if len(dic[num]) == 3 && (ans == -1 || 2*(dic[num][2]-dic[num][0]) < ans) {
			ans = 2 * (dic[num][2] - dic[num][0])
		}
	}
	return ans
}

// @lc code=end
