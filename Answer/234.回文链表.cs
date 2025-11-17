/*
 * @lc app=leetcode.cn id=234 lang=csharp
 *
 * [234] 回文链表
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
    public bool IsPalindrome(ListNode head) {
        if (head.next == null) return true;
            ListNode t1 = head;
            ListNode t2 = head.next;
            ListNode t3 = head;
            //边向后遍历边拆链
            while(t2 != null && t2.next != null)
            {
                t2 = t2.next.next;
                ListNode t4 = t1.next;
                t1.next = t3;
                t3 = t1;
                t1 = t4;
            }
            if (t2 == null)
            {
                //奇数
                t2 = t1.next;
                t1 = t3;
            }
            else
            {
                //偶数
                t2 = t1.next;
                t1.next = t3;
            }
            while(t2 != null)
            {
                if (t1.val != t2.val) return false;
                t1 = t1.next;
                t2 = t2.next;
            }
            return true;
    }
}
// @lc code=end

