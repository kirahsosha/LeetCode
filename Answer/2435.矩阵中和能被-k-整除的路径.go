/*
 * @lc app=leetcode.cn id=2435 lang=golang
 *
 * [2435] 矩阵中和能被 K 整除的路径
 */

// @lc code=start
func numberOfPaths(grid [][]int, k int) int {
    m := len(grid)
	n := len(grid[0])
	dpOld := make([][]int, n)
	dpNew := make([][]int, n)
	MOD := 1000000007
	for i := 0; i < m; i++ {
		if i != 0 {
			dpOld = dpNew
		}
		dpNew = make([][]int, n)
		for j := 0; j < n; j++ {
			dpNew[j] = make([]int, k)
			if i == 0 && j == 0 {
				x := grid[0][0] % k
				dpNew[0][x] = 1
			}
			if j != 0 {
				for x := 0; x < k; x++ {
					if dpNew[j - 1][x] == 0 {
						continue
					}
					y := (x + grid[i][j]) % k
					dpNew[j][y] = (dpNew[j][y] + dpNew[j - 1][x]) % MOD
				}
			}
			if i != 0 {
				for x := 0; x < k; x++ {
					if dpOld[j][x] == 0 {
						continue
					}
					y := (x + grid[i][j]) % k
					dpNew[j][y] = (dpNew[j][y] + dpOld[j][x]) % MOD
				}
			}
		}
	}
	return dpNew[n - 1][0]
}
// @lc code=end

