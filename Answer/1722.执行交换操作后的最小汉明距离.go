/*
 * @lc app=leetcode.cn id=1722 lang=golang
 *
 * [1722] 执行交换操作后的最小汉明距离
 */

// @lc code=start
func minimumHammingDistance(source []int, target []int, allowedSwaps [][]int) int {
	n := len(source)
	parent := make([]int, n)
	sz := make([]int, n)
	for i := range parent {
		parent[i] = i
		sz[i] = 1
	}

	// 迭代路径压缩，避免递归开销
	find := func(x int) int {
		root := x
		for parent[root] != root {
			root = parent[root]
		}
		for parent[x] != x {
			parent[x], x = root, parent[x]
		}
		return root
	}

	// 按大小合并，保持树平衡
	for _, swap := range allowedSwaps {
		a, b := swap[0], swap[1]
		pa, pb := find(a), find(b)
		if pa != pb {
			if sz[pa] < sz[pb] {
				pa, pb = pb, pa
			}
			parent[pb] = pa
			sz[pa] += sz[pb]
		}
	}

	// 缓存每个位置的最终根节点，避免后续重复查找
	roots := make([]int, n)
	for i := 0; i < n; i++ {
		roots[i] = find(i)
	}

	// 按连通分量统计 source 中各数值出现次数
	groups := make(map[int]map[int]int, n)
	for i := 0; i < n; i++ {
		r := roots[i]
		if groups[r] == nil {
			groups[r] = make(map[int]int)
		}
		groups[r][source[i]]++
	}

	res := 0
	for i := 0; i < n; i++ {
		r := roots[i]
		if groups[r][target[i]] > 0 {
			groups[r][target[i]]--
		} else {
			res++
		}
	}
	return res
}

// @lc code=end
