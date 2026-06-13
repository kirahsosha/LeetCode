/*
 * @lc app=leetcode.cn id=2130 lang=javascript
 *
 * [2130] 链表最大孪生和
 */

// @lc code=start
/**
 * Definition for singly-linked list.
 * function ListNode(val, next) {
 *     this.val = (val===undefined ? 0 : val)
 *     this.next = (next===undefined ? null : next)
 * }
 */
/**
 * @param {ListNode} head
 * @return {number}
 */
var pairSum = function (head) {
    var slow = head, fast = head, cnt = 0;
    while (fast !== null) {
        slow = slow.next;
        fast = fast.next.next;
        cnt++;
    }

    var stack = new Array(cnt);
    for (var i = 0; i < cnt; i++) {
        stack[i] = slow.val;
        slow = slow.next;
    }

    var res = 0;
    var cur = head;
    for (var i = cnt - 1; i >= 0; i--) {
        res = Math.max(res, cur.val + stack[i]);
        cur = cur.next;
    }
    return res;
};
// @lc code=end
