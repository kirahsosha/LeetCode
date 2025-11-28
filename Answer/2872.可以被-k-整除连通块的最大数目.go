/*
 * @lc app=leetcode.cn id=2872 lang=golang
 *
 * [2872] 可以被 K 整除连通块的最大数目
 */

// @lc code=start
func maxKDivisibleComponents(n int, edges [][]int, values []int, k int) int {
    nodes := make([][]int, n)
	res := 0
	for _, edge := range edges {
		l, r := edge[0], edge[1]
		nodes[l] = append(nodes[l], r)
		nodes[r] = append(nodes[r], l)
	}

	var dfs func(int, int) int64
	dfs = func(parent, child int) int64 {
		sum := int64(values[child])
		for _, neighbor := range nodes[child]{
			if neighbor != parent {
				sum += dfs(child, neighbor)
			}
		}
		if sum % int64(k) == 0 {
			res += 1
			return 0
		}
		return sum
	}

	dfs(-1, 0)
	return res
}
// @lc code=end

