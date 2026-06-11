/*
 * @lc app=leetcode.cn id=3558 lang=golang
 *
 * [3558] 给边赋权值的方案数 I
 */

// @lc code=start
func assignEdgeWeights(edges [][]int) int {
	const MOD = 1_000_000_007
	n := len(edges) + 1

	// 建邻接表
	adj := make([][]int, n+1)
	for _, e := range edges {
		u, v := e[0], e[1]
		adj[u] = append(adj[u], v)
		adj[v] = append(adj[v], u)
	}

	// BFS 求从节点 1 出发的最大深度（边数）
	type pair struct {
		node, depth int
	}
	maxDepth := 0
	visited := make([]bool, n+1)
	queue := []pair{{1, 0}}
	visited[1] = true

	for len(queue) > 0 {
		p := queue[0]
		queue = queue[1:]
		if p.depth > maxDepth {
			maxDepth = p.depth
		}
		for _, nb := range adj[p.node] {
			if !visited[nb] {
				visited[nb] = true
				queue = append(queue, pair{nb, p.depth + 1})
			}
		}
	}

	// 快速幂求 2^(maxDepth-1) % MOD
	pow, base := 1, 2
	exp := maxDepth - 1
	for exp > 0 {
		if exp&1 == 1 {
			pow = (pow * base) % MOD
		}
		base = (base * base) % MOD
		exp >>= 1
	}

	return pow
}

// @lc code=end
