/*
 * @lc app=leetcode.cn id=2 lang=cpp
 *
 * [2] 两数相加
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
    ListNode* addTwoNumbers(ListNode* l1, ListNode* l2) {
        int a = 0;
        ListNode *l, *l3, *l4;
        l = l1;
        l3 = l1;
        l4 = l2;
        while(l1 != nullptr && l2 != nullptr)
        {
            a += l1->val + l2->val;
            l1->val = a % 10;
            a /= 10;
            l3 = l1;
            l1 = l1->next;
            l2 = l2->next;
        }
        if(l1 != nullptr)
        {
            while(l1 != nullptr)
            {
                a += l1->val;
                l1->val = a % 10;
                a /= 10;
                l3 = l1;
                l1 = l1->next;
            }
            if(a > 0 && a < 10)
            {
                l3->next = l4;
                l4->val = a;
                l4->next = nullptr;
            }
            else if(a > 10)
            {
                l3->next = l4;
                l4->val = a % 10;
                l3 = l4;
                l4 = new ListNode(1);
                l3->next = l4;
                l4->val = 1;
                l4->next = nullptr;
            }
        }
        else if(l2 != nullptr)
        {
            l3->next = l2;
            l1 = l3->next;
            while(l1 != nullptr)
            {
                a += l1->val;
                l1->val = a % 10;
                a /= 10;
                l3 = l1;
                l1 = l1->next;
            }
            if(a > 0 && a < 10)
            {
                l3->next = l4;
                l4->val = a;
                l4->next = nullptr;
            }
            else if(a > 10)
            {
                l3->next = l4;
                l4->val = a % 10;
                l3 = l4;
                l4 = new ListNode(1);
                l3->next = l4;
                l4->val = 1;
                l4->next = nullptr;
            }
        }
        else if(a != 0)
        {
            if(a < 10)
            {
                l3->next = l4;
                l4->val = a;
                l4->next = nullptr;
            }
            else
            {
                l3->next = l4;
                l4->val = a % 10;
                l4 = l4->next;
                l4->val = 1;
                l4->next = nullptr;
            }
        }
        return l;
    }
};
// @lc code=end

