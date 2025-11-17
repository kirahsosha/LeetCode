/*
 * @lc app=leetcode.cn id=203 lang=cpp
 *
 * [203] 移除链表元素
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
    ListNode* removeElements(ListNode* head, int val) {
        if(head == nullptr) return head;
        if(head->val == val && head->next == nullptr) return nullptr;
        if(head->next == nullptr) return head;
        while(head->next != nullptr)
        {
            if(head->val == val)
            {
                head = head->next;
            }
            else
            {
                break;
            }
        }
        if(head == nullptr) return head;
        if(head->val == val && head->next == nullptr) return nullptr;
        if(head->next == nullptr) return head;
        ListNode *l;
        l = head;
        while(l->next != nullptr)
        {
            if(l->next->val == val)
            {
                l->next = l->next->next;
            }
            else
            {
                l = l->next;
            }
        }
        return head;
    }
};
// @lc code=end

