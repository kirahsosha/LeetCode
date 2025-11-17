/*
 * @lc app=leetcode.cn id=206 lang=cpp
 *
 * [206] 反转链表
 */

// @lc code=start
/**
 * Definition for singly-linked list.
 * struct ListNode {
 *     int val;
 *     ListNode *next;
 *     ListNode(int x) : val(x), next(NULL) {}
 * };
 */
class Solution {
public:
    ListNode* reverseList(ListNode* head) {
        if(head == nullptr) return head;
        if(head->next == nullptr) return head;
        ListNode *a, *b, *c;
        a = head;
        b = head->next;
        a->next = nullptr;
        while(b->next != nullptr)
        {
            c = b->next;
            b->next = a;
            a = b;
            b = c;
        }
        b->next = a;
        return b;
    }
};
// @lc code=end

