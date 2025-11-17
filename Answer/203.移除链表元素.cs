/*
 * @lc app=leetcode.cn id=203 lang=csharp
 *
 * [203] 移除链表元素
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
    public ListNode RemoveElements(ListNode head, int val) {
        if(head == null) return head;
        if(head.val == val && head.next == null) return null;
        if(head.next == null) return head;
        while(head.next != null)
        {
            if(head.val == val)
            {
                head = head.next;
            }
            else
            {
                break;
            }
        }
        if(head == null) return head;
        if(head.val == val && head.next == null) return null;
        if(head.next == null) return head;
        ListNode l;
        l = head;
        while(l.next != null)
        {
            if(l.next.val == val)
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

