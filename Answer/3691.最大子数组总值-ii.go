/*
 * @lc app=leetcode.cn id=3691 lang=golang
 *
 * [3691] 最大子数组总值 II
 */

// @lc code=start

// min returns the smaller of a and b.
func minInt(a, b int) int {
	if a < b {
		return a
	}
	return b
}

func maxTotalValue(nums []int, k int) int64 {
	n := len(nums)

	// 1. find global max and min
	M, mVal := nums[0], nums[0]
	for _, v := range nums {
		if v > M {
			M = v
		}
		if v < mVal {
			mVal = v
		}
	}
	if M == mVal {
		return 0
	}

	// 3. Sparse table for RMQ (range min query)
	logT := make([]int, n+1)
	for i := 2; i <= n; i++ {
		logT[i] = logT[i/2] + 1
	}
	K := logT[n] + 1
	stMin := make([][]int, K)
	for i := range stMin {
		stMin[i] = make([]int, n)
	}
	copy(stMin[0], nums)
	for j := 1; j < K; j++ {
		for i := 0; i+(1<<j)-1 < n; i++ {
			stMin[j][i] = minInt(stMin[j-1][i], stMin[j-1][i+(1<<(j-1))])
		}
	}
	qmin := func(l, r int) int {
		j := logT[r-l+1]
		return minInt(stMin[j][l], stMin[j][r-(1<<j)+1])
	}

	// 4. Monotonic stacks: for each element, find the range where it is the
	//    MAXIMUM.  We use prev:> (strict) and next:>= (non-strict) so that each
	//    subarray is assigned to the RIGHTMOST element that attains its max.
	prevG := make([]int, n)
	nextG := make([]int, n)
	{
		st := make([]int, 0, n)
		for i := 0; i < n; i++ {
			prevG[i] = -1
			for len(st) > 0 && nums[st[len(st)-1]] <= nums[i] {
				st = st[:len(st)-1]
			}
			if len(st) > 0 {
				prevG[i] = st[len(st)-1]
			}
			st = append(st, i)
		}
		st = st[:0]
		for i := n - 1; i >= 0; i-- {
			nextG[i] = n
			for len(st) > 0 && nums[st[len(st)-1]] < nums[i] {
				st = st[:len(st)-1]
			}
			if len(st) > 0 {
				nextG[i] = st[len(st)-1]
			}
			st = append(st, i)
		}
	}

	// 5. Max-heap
	type entry struct {
		val  int64
		l, r int
		ref  int // position of the maximum element
	}
	h := make([]entry, 0, k)
	push := func(e entry) {
		h = append(h, e)
		i := len(h) - 1
		for i > 0 {
			p := (i - 1) / 2
			if h[p].val >= h[i].val {
				break
			}
			h[p], h[i] = h[i], h[p]
			i = p
		}
	}
	pop := func() entry {
		e := h[0]
		h[0] = h[len(h)-1]
		h = h[:len(h)-1]
		i := 0
		sz := len(h)
		for {
			lt := 2*i + 1
			rt := 2*i + 2
			best := i
			if lt < sz && h[lt].val > h[best].val {
				best = lt
			}
			if rt < sz && h[rt].val > h[best].val {
				best = rt
			}
			if best == i {
				break
			}
			h[best], h[i] = h[i], h[best]
			i = best
		}
		return e
	}

	visited := make(map[[2]int]bool)
	tryPush := func(e entry) {
		key := [2]int{e.l, e.r}
		if visited[key] {
			return
		}
		visited[key] = true
		push(e)
	}

	// 6. Push initial candidate for EVERY element as a potential maximum.
	//    For position i, the range where nums[i] is the maximum is
	//    [prevG[i]+1, nextG[i]-1].  The best subarray (largest value) uses the
	//    full range: value = nums[i] - min(fullRange).
	for i := 0; i < n; i++ {
		L := prevG[i] + 1
		R := nextG[i] - 1
		minVal := qmin(L, R)
		val := int64(nums[i] - minVal)
		if val > 0 {
			tryPush(entry{val: val, l: L, r: R, ref: i})
		}
	}

	// 7. Pop top entries and generate shrink variants.
	var ans int64 = 0
	for k > 0 && len(h) > 0 {
		e := pop()
		if e.val <= 0 {
			break
		}
		ans += e.val
		k--

		// Shrink left
		if e.l < e.ref {
			nl := e.l + 1
			nv := int64(nums[e.ref] - qmin(nl, e.r))
			if nv > 0 {
				tryPush(entry{val: nv, l: nl, r: e.r, ref: e.ref})
			}
		}
		// Shrink right (must keep ref inside, and must not include next >= value)
		if e.r > e.ref && e.r-1 < nextG[e.ref] {
			nr := e.r - 1
			nv := int64(nums[e.ref] - qmin(e.l, nr))
			if nv > 0 {
				tryPush(entry{val: nv, l: e.l, r: nr, ref: e.ref})
			}
		}
	}

	return ans
}

// @lc code=end
