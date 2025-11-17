/*
 * @lc app=leetcode.cn id=19 lang=csharp
 *
 * [19] 删除链表的倒数第 N 个结点
 */

// @lc code=start
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    public ListNode RemoveNthFromEnd(ListNode head, int n) {
        ListNode node = head;
            for(int i = 0; i < n; i++)
            {
                node = node.next;
            }
            if(node == null)
            {
                return head.next;
            }
            ListNode del = head;
            while(node.next != null)
            {
                node = node.next;
                del = del.next;
            }
            del.next = del.next.next;
            return head;
    }
}
// @lc code=end

