/*
 * @lc app=leetcode.cn id=3660 lang=golang
 *
 * [3660] 跳跃游戏 IX
 */

// @lc code=start
func maxValue(nums []int) []int {
	n := len(nums)
	dp := make([][2]int, n)

	// dp[i][0] 表示 i 左侧的最大值的下标
	dp[0][0] = 0
	for i := 1; i < n; i++ {
		if nums[i] >= nums[dp[i-1][0]] {
			dp[i][0] = i
		} else {
			dp[i][0] = dp[i-1][0]
		}
	}

	// dp[i][1] 表示 i 右侧从右数第一个比 nums[i] 小的数的下标
	// 使用离散化 + 树状数组优化，从右往左查询值域小于 nums[i] 的最大下标
	sorted := make([]int, n)
	copy(sorted, nums)
	sort.Ints(sorted)
	uniq := sorted[:0]
	for _, v := range sorted {
		if len(uniq) == 0 || v != uniq[len(uniq)-1] {
			uniq = append(uniq, v)
		}
	}
	m := len(uniq)
	bit := make([]int, m+1)
	for i := range bit {
		bit[i] = -1
	}
	update := func(idx, val int) {
		for idx <= m {
			if val > bit[idx] {
				bit[idx] = val
			}
			idx += idx & -idx
		}
	}
	query := func(idx int) int {
		res := -1
		for idx > 0 {
			if bit[idx] > res {
				res = bit[idx]
			}
			idx -= idx & -idx
		}
		return res
	}
	getRank := func(val int) int {
		return sort.Search(len(uniq), func(i int) bool { return uniq[i] >= val }) + 1
	}

	dp[n-1][1] = n - 1
	rank := getRank(nums[n-1])
	update(rank, n-1)
	for i := n - 2; i >= 0; i-- {
		rank = getRank(nums[i])
		q := query(rank - 1)
		if q == -1 {
			dp[i][1] = i
		} else {
			dp[i][1] = q
		}
		update(rank, i)
	}

	// 预处理 jump[i] = dp[dp[i][1]][0]
	jump := make([]int, n)
	for i := 0; i < n; i++ {
		jump[i] = dp[dp[i][1]][0]
	}

	// 利用递推关系优化 ans 计算：
	// ans[i] = nums[i]               if nums[jump[i]] <= nums[i]
	// ans[i] = ans[jump[i]]          if nums[jump[i]] > nums[i]
	// 按 nums 值从大到小排序下标，确保依赖先计算
	type pair struct{ idx, val int }
	pairs := make([]pair, n)
	for i := 0; i < n; i++ {
		pairs[i] = pair{i, nums[i]}
	}
	sort.Slice(pairs, func(i, j int) bool {
		return pairs[i].val > pairs[j].val
	})

	ans := make([]int, n)
	for _, p := range pairs {
		i := p.idx
		j := jump[i]
		if nums[j] <= nums[i] {
			ans[i] = nums[i]
		} else {
			ans[i] = ans[j]
		}
	}
	return ans
}
// @lc code=end
