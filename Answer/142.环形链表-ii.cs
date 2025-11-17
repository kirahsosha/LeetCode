/*
 * @lc app=leetcode.cn id=142 lang=csharp
 *
 * [142] 环形链表 II
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
    public ListNode DetectCycle(ListNode head) {
        
        //Floyd 算法
        //1. 快指针2步, 慢指针一步, 直到相遇或快指针指向null
        //2. p1从起点, p2从相遇点, 一次都走一步, 直到相遇, 就是环的起点
        if(head == null || head.next == null) return null;
        ListNode fast = head;
        ListNode slow = head;
        //第一阶段
        while(fast != null && fast.next != null)
        {
            fast = fast.next.next;
            slow = slow.next;
            if(fast == null || fast.next == null) return null;
            if(slow == fast) break; //相遇
        }
        if(fast == null || fast.next == null) return null;
        slow = head;
        //第二阶段
        while(slow != fast)
        {
            slow = slow.next;
            fast = fast.next;
        }
        return fast;
    }
}
// @lc code=end