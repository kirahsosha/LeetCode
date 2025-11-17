/*
 * @lc app=leetcode.cn id=83 lang=csharp
 *
 * [83] 删除排序链表中的重复元素
 */

// @lc code=start
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode DeleteDuplicates(ListNode head) {
        if (head == null || head.next == null) return head;
		ListNode l = head;
		while (l.next != null)
		{
			if (l.next.val == l.val)
			{
				l.next = l.next.next;
			}
			else
			{
				l = l.next;
			}
		}
		return head;
    }
}
// @lc code=end

