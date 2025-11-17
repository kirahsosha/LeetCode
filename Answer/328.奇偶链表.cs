/*
 * @lc app=leetcode.cn id=328 lang=csharp
 *
 * [328] 奇偶链表
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
    public ListNode OddEvenList(ListNode head) {
        if(head == null) return head;
        if(head.next == null) return head;
        if(head.next.next == null) return head;
        ListNode sec = head.next;
        ListNode t1 = head;
        ListNode t2 = sec;
        while(t2.next != null && t2.next.next != null)
        {
            t1.next = t2.next;
            t2.next = t1.next.next;
            t1 = t1.next;
            t2 = t2.next;
        }
        if(t2.next != null)
        {
            t1.next = t2.next;
            t1 = t1.next;
            t2.next = null;
        }
        t1.next = sec;
        return head;
    }
}
// @lc code=end

