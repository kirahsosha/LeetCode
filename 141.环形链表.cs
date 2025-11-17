/*
 * @lc app=leetcode.cn id=141 lang=csharp
 *
 * [141] 环形链表
 */

// @lc code=start
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) {
 *         val = x;
 *         next = null;
 *     }
 * }
 */
public class Solution {
    public bool HasCycle(ListNode head) {
        if(head == null) return false;
        if(head.next == null) return false;
        ListNode fast = head.next.next;
        ListNode slow = head.next;
        while(fast != null)
        {
            if(fast == slow) return true;
            if(fast.next == null) return false;
            fast = fast.next.next;
            slow = slow.next;
        }
        return false;
    }
}
// @lc code=end

