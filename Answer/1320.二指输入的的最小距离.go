/*
 * @lc app=leetcode.cn id=1320 lang=golang
 *
 * [1320] 二指输入的的最小距离
 */

// @lc code=start
func minimumDistance(word string) int {
	/* 状态定义:
	 *   dp[i][j] 表示输入到第 i 个字母时(word[i-1]已输入完毕):
	 *   - 当前有一只手指在 word[i-1] 位置
	 *   - 另一只手在位置 j (j=26表示空闲状态)
	 *   - 已输入前 i 个字母的最小总距离
	 *
	 *   注意: j 的范围是 0~26, 其中 26 表示"空闲/未使用"状态
	 *
	 * 状态转移方程:
	 *
	 *   设当前要输入第 i 个字母 to = word[i]-'A'
	 *   设上一个输入的字母 last = word[i-1]-'A'
	 *   设另一只手的位置为 other
	 *
	 *   对于状态 dp[i][other], 有两种转移方式:
	 *
	 *   1) 用按 last 的手指继续按 to:
	 *      代价 = cost(last, to) + dp[i+1][other]
	 *      (另一只手位置不变)
	 *
	 *   2) 用另一只手(other位置)去按 to:
	 *      代价 = cost(other, to) + dp[i+1][last]
	 *      (按last的手指变为"另一只手")
	 *
	 *   取最小值:
	 *   dp[i][other] = min(
	 *       cost(last, to) + dp[i+1][other],           // 同手指继续
	 *       cost(other, to) + dp[i+1][last]            // 换手指
	 *   )
	 *
	 * 边界条件:
	 *   - 当 i == n (所有字母输入完毕), 返回 0
	 *   - cost(26, to) = 0 (从空闲位置移动代价为0)
	 *
	 * 答案:
	 *   min(dp[n-1][j]) 对所有可能的 j
	 *
	 * 优化:
	 *   可以用记忆化搜索或递推, 时间复杂度 O(n * 27), 空间复杂度 O(n * 27)
	 *   其中 27 表示 26个字母 + 1个空闲状态
	 */

	n := len(word)

	// 记忆化搜索
	memo := make([][]int, n)
	for i := range memo {
		memo[i] = make([]int, 27)
		for j := range memo[i] {
			memo[i][j] = -1
		}
	}

	// cost[from][to] 预处理任意两点间距离
	var cost func(from, to int) int
	cost = func(from, to int) int {
		if from == 26 {
			return 0
		}
		x1, y1 := from/6, from%6
		x2, y2 := to/6, to%6
		if x1 > x2 {
			x1, x2 = x2, x1
		}
		if y1 > y2 {
			y1, y2 = y2, y1
		}
		return (x2 - x1) + (y2 - y1)
	}

	// dfs[pos][other] 计算当前输入 word[pos], 另一只手在 other 位置的最小代价
	var dfs func(pos, other int) int
	dfs = func(pos, other int) int {
		if pos >= n {
			return 0
		}
		if memo[pos][other] != -1 {
			return memo[pos][other]
		}

		to := int(word[pos] - 'A')
		if pos == 0 {
			memo[pos][other] = dfs(pos+1, 26)
			return memo[pos][other]
		}

		last := int(word[pos-1] - 'A')

		res1 := cost(last, to) + dfs(pos+1, other)

		res2 := cost(other, to) + dfs(pos+1, last)

		if res1 < res2 {
			memo[pos][other] = res1
		} else {
			memo[pos][other] = res2
		}
		return memo[pos][other]
	}

	return dfs(0, 26)
}

// @lc code=end
