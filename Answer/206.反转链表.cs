/*
 * @lc app=leetcode.cn id=206 lang=csharp
 *
 * [206] 反转链表
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
    public ListNode ReverseList(ListNode head) {
        if(head == null) return head;
        if(head.next == null) return head;
        ListNode a, b, c;
        a = head;
        b = head.next;
        a.next = null;
        while(b.next != null)
        {
            c = b.next;
            b.next = a;
            a = b;
            b = c;
        }
        b.next = a;
        return b;
    }
}
// @lc code=end

