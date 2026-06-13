/*
 * @lc app=leetcode.cn id=2130 lang=csharp
 *
 * [2130] 链表最大孪生和
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
    public int PairSum(ListNode head) {
        ListNode slow = head, fast = head;
        int cnt = 0;
        while (fast != null) {
            slow = slow.next;
            fast = fast.next.next;
            cnt++;
        }

        int[] stack = new int[cnt];
        for (int i = 0; i < cnt; i++) {
            stack[i] = slow.val;
            slow = slow.next;
        }

        int res = 0;
        ListNode cur = head;
        for (int i = cnt - 1; i >= 0; i--) {
            res = Math.Max(res, cur.val + stack[i]);
            cur = cur.next;
        }
        return res;
    }
}
// @lc code=end
