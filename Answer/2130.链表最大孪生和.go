/*
 * @lc app=leetcode.cn id=2130 lang=golang
 *
 * [2130] 链表最大孪生和
 */

// @lc code=start
/**
 * Definition for singly-linked list.
 * type ListNode struct {
 *     Val int
 *     Next *ListNode
 * }
 */
func pairSum(head *ListNode) int {
	slow := head
	fast := head
	cnt := 0
	for fast != nil {
		slow = slow.Next
		fast = fast.Next.Next
		cnt++
	}

	stack := make([]int, cnt)
	res := 0
	for i := 0; i < cnt; i++ {
		stack[i] = slow.Val
		slow = slow.Next
	}

	cur := head
	for i := len(stack) - 1; i >= 0; i-- {
		if cur.Val+stack[i] > res {
			res = cur.Val + stack[i]
		}
		cur = cur.Next
	}

	return res
}

// @lc code=end
