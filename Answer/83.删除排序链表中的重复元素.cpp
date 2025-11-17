/*
 * @lc app=leetcode.cn id=83 lang=cpp
 *
 * [83] 删除排序链表中的重复元素
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
    ListNode* deleteDuplicates(ListNode* head) {
		if (head == nullptr || head->next == nullptr) return head;
		ListNode *l = head;
		while (l->next != nullptr)
		{
			if (l->next->val == l->val)
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

