import "strconv"

/*
 * @lc app=leetcode.cn id=3753 lang=golang
 *
 * [3753] 范围内总波动值 II
 */

// @lc code=start

func totalWaviness(num1 int64, num2 int64) int64 {
	return calc(num2) - calc(num1-1)
}

func calc(n int64) int64 {
	if n < 100 {
		return 0
	}
	s := strconv.FormatInt(n, 10)

	var memo [20][2][11][11]struct {
		cnt int64
		sum int64
		vis bool
	}

	var dfs func(pos int, tight int, lead int, pre int, ppre int) (int64, int64)
	dfs = func(pos int, tight int, lead int, pre int, ppre int) (int64, int64) {
		if pos == len(s) {
			return 1, 0
		}
		if tight == 0 && memo[pos][lead][pre+1][ppre+1].vis {
			return memo[pos][lead][pre+1][ppre+1].cnt, memo[pos][lead][pre+1][ppre+1].sum
		}

		limit := 9
		if tight == 1 {
			limit = int(s[pos] - '0')
		}

		var cnt int64
		var sum int64

		for d := 0; d <= limit; d++ {
			newTight := 0
			if tight == 1 && d == limit {
				newTight = 1
			}

			if lead == 1 && d == 0 {
				subCnt, subSum := dfs(pos+1, newTight, 1, -1, -1)
				cnt += subCnt
				sum += subSum
			} else {
				var add int64
				if lead == 0 && pre != -1 && ppre != -1 {
					if (pre > ppre && pre > d) || (pre < ppre && pre < d) {
						add = 1
					}
				}
				subCnt, subSum := dfs(pos+1, newTight, 0, d, pre)
				cnt += subCnt
				sum += subSum + add*subCnt
			}
		}

		if tight == 0 {
			memo[pos][lead][pre+1][ppre+1] = struct {
				cnt int64
				sum int64
				vis bool
			}{cnt, sum, true}
		}

		return cnt, sum
	}

	_, res := dfs(0, 1, 1, -1, -1)
	return res
}

// @lc code=end
