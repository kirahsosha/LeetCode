/*
 * @lc app=leetcode.cn id=2095 lang=typescript
 *
 * [2095] 删除链表的中间节点
 */

// @lc code=start
/**
 * Definition for singly-linked list.
 * class ListNode {
 *     val: number
 *     next: ListNode | null
 *     constructor(val?: number, next?: ListNode | null) {
 *         this.val = (val===undefined ? 0 : val)
 *         this.next = (next===undefined ? null : next)
 *     }
 * }
 */

function deleteMiddle(head: ListNode | null): ListNode | null {
    if (!head || !head.next) {
        return null;
    }
    let slow: ListNode = head;
    let fast: ListNode | null = head.next.next;
    while (fast && fast.next) {
        slow = slow.next!;
        fast = fast.next.next;
    }
    slow.next = slow.next!.next;
    return head;
}
// @lc code=end
