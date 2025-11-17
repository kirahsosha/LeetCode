/*
 * @lc app=leetcode.cn id=21 lang=cpp
 *
 * [21] 合并两个有序链表
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
    ListNode* mergeTwoLists(ListNode* l1, ListNode* l2) {
        ListNode *l, *l3;
        if(l1 == nullptr) return l2;
        if(l2 == nullptr) return l1;
        if(l1->val > l2->val)
        {
            l3 = l2;
            l2 = l1;
            l1 = l3;
        }
        l = l1;
        while(l1->next != nullptr && l2->next != nullptr)
        {
            if(l1->next->val > l2->val)
            {
                l3 = l2;
                l2 = l2->next;
                l3->next = l1->next;
                l1->next = l3;
            }
            l1 = l1->next;
        }
        if(l1->next == nullptr)
        {
            l1->next = l2;
        }
        else
        {
            while(l1->next != nullptr)
            {
                if(l1->next->val > l2->val)
                {
                    l3 = l2;
                    l2 = l2->next;
                    l3->next = l1->next;
                    l1->next = l3;
                    return l;
                }
                l1 = l1->next;
            }
            l1->next = l2;
        }
        return l;
    }
};
// @lc code=end

