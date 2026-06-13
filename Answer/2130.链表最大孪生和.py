#
# @lc app=leetcode.cn id=2130 lang=python3
#
# [2130] 链表最大孪生和
#

# @lc code=start
# Definition for singly-linked list.
# class ListNode:
#     def __init__(self, val=0, next=None):
#         self.val = val
#         self.next = next
class Solution:
    def pairSum(self, head: Optional[ListNode]) -> int:
        slow = fast = head
        cnt = 0
        while fast:
            slow = slow.next
            fast = fast.next.next
            cnt += 1

        stack = [0] * cnt
        for i in range(cnt):
            stack[i] = slow.val
            slow = slow.next

        res = 0
        cur = head
        for i in range(cnt - 1, -1, -1):
            res = max(res, cur.val + stack[i])
            cur = cur.next
        return res
# @lc code=end
