/*
 * @lc app=leetcode.cn id=19 lang=csharp
 *
 * [19] 删除链表的倒数第N个节点
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
    public ListNode RemoveNthFromEnd(ListNode head, int n) {
        ListNode p = head;
        for(int i = 0; i < n; i++)
        {
            p = p.next;
        }
        if(p == null)
        {
            return head.next;
        }
        ListNode t = head;
        while(p.next != null)
        {
            p = p.next;
            t = t.next;
        }
        t.next = t.next.next;
        return head;
    }
}
// @lc code=end

