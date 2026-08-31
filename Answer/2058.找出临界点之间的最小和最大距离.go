/*
 * @lc app=leetcode.cn id=2058 lang=golang
 *
 * [2058] 找出临界点之间的最小和最大距离
 */

// @lc code=start
func nodesBetweenCriticalPoints(head *ListNode) []int {
	if head == nil || head.Next == nil || head.Next.Next == nil {
		return []int{-1, -1}
	}

	first, last := -1, -1
	minDistance := int(^uint(0) >> 1)
	prev := head.Val
	index := 1

	for node := head.Next; node != nil && node.Next != nil; node = node.Next {
		next := node.Next.Val
		isCritical := (node.Val < prev && node.Val < next) || (node.Val > prev && node.Val > next)
		if isCritical {
			if first == -1 {
				first = index
			} else {
				if index-last < minDistance {
					minDistance = index - last
				}
			}
			last = index
		}
		prev = node.Val
		index++
	}

	if minDistance == int(^uint(0)>>1) {
		return []int{-1, -1}
	}
	return []int{minDistance, last - first}
}

// @lc code=end
