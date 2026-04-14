import (
	"math"
	"sort"
)

/*
 * @lc app=leetcode.cn id=2463 lang=golang
 *
 * [2463] 最小移动总距离
 */

// @lc code=start
func minimumTotalDistance(robot []int, factory [][]int) int64 {
	// 设 dp[i][j] 表示使用前 i 个工厂（factory[0..i-1]）修理前 j 个机器人（robot[0..j-1]）所需的最小总距离。
	//
	// 状态转移方程：
	// 考虑第 i 个工厂（位置为 pos，容量为 limit）：
	//   dp[i][j] = dp[i-1][j]                                    // 第 i 个工厂修理 0 个机器人
	//   dp[i][j] = min( dp[i][j],
	//                   dp[i-1][j-k] + sum_{t=j-k}^{j-1} |robot[t] - pos| )
	//   其中 1 <= k <= min(limit, j)
	//   表示第 i 个工厂连续修理第 j-k .. j-1 个机器人。
	//
	// 初始条件：
	//   dp[0][0] = 0
	//   dp[0][j] = +inf  (j > 0)   // 没有工厂时无法修理机器人
	//   dp[i][0] = 0               // 0 个机器人不需要移动
	//
	// 答案：dp[m][n]，m = len(factory)，n = len(robot)

	sort.Ints(robot)
	sort.Slice(factory, func(i, j int) bool {
		return factory[i][0] < factory[j][0]
	})

	m, n := len(factory), len(robot)

	dp := make([][]int64, m+1)
	for i := range dp {
		dp[i] = make([]int64, n+1)
		for j := range dp[i] {
			if j > 0 {
				dp[i][j] = math.MaxInt64
			}
		}
	}

	for i := range m + 1 {
		dp[i][0] = 0
	}

	for i := 1; i <= m; i++ {
		pos, limit := factory[i-1][0], factory[i-1][1]
		for j := 0; j <= n; j++ {
			dp[i][j] = dp[i-1][j] // 不使用第 i 个工厂
			var sum int64
			for k := 1; k <= limit && k <= j; k++ {
				sum += int64(math.Abs(float64(robot[j-k] - pos)))
				if dp[i-1][j-k] != math.MaxInt64 {
					dp[i][j] = min(dp[i][j], dp[i-1][j-k]+sum)
				}
			}
		}
	}

	return dp[m][n]
}

// @lc code=end
