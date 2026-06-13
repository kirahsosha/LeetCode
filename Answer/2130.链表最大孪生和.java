/*
 * @lc app=leetcode.cn id=2130 lang=java
 *
 * [2130] 链表最大孪生和
 */

// @lc code=start
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     int val;
 *     ListNode next;
 *     ListNode() {}
 *     ListNode(int val) { this.val = val; }
 *     ListNode(int val, ListNode next) { this.val = val; this.next = next; }
 * }
 */
class Solution {
    public int pairSum(ListNode head) {
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
            res = Math.max(res, cur.val + stack[i]);
            cur = cur.next;
        }
        return res;
    }
}
// @lc code=end
