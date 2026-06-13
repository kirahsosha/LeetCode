/*
 * @lc app=leetcode.cn id=2130 lang=typescript
 *
 * [2130] 链表最大孪生和
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

function pairSum(head: ListNode | null): number {
    let slow: ListNode | null = head;
    let fast: ListNode | null = head;
    let cnt = 0;
    while (fast !== null) {
        slow = slow!.next;
        fast = fast.next!.next;
        cnt++;
    }

    const stack: number[] = new Array(cnt);
    for (let i = 0; i < cnt; i++) {
        stack[i] = slow!.val;
        slow = slow!.next;
    }

    let res = 0;
    let cur: ListNode | null = head;
    for (let i = cnt - 1; i >= 0; i--) {
        res = Math.max(res, cur!.val + stack[i]);
        cur = cur!.next;
    }
    return res;
}
// @lc code=end
