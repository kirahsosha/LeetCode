/*
 * @lc app=leetcode.cn id=111 lang=cpp
 *
 * [111] 二叉树的最小深度
 */

// @lc code=start
/**
 * Definition for a binary tree node.
 * struct TreeNode {
 *     int val;
 *     TreeNode *left;
 *     TreeNode *right;
 *     TreeNode(int x) : val(x), left(NULL), right(NULL) {}
 * };
 */
class Solution {
public:
	struct Queue
	{
		TreeNode *t;
		Queue *next;
		int d;
	};
	
    int minDepth(TreeNode* root) {
		if (root == nullptr) return 0;
		int min = 0;
		Queue *head = new Queue, *last, *n;
		head->next = nullptr;
		head->t = root;
		head->d = 1;
		last = head;
		while (head != nullptr)
		{
			if (head->t->left == nullptr && head->t->right == nullptr) return head->d;
			else if (head->t->left != nullptr && head->t->right == nullptr)
			{
				n = new Queue;
				n->next = nullptr;
				n->t = head->t->left;
				n->d = head->d + 1;
				last->next = n;
				last = n;
			}
			else if (head->t->left == nullptr && head->t->right != nullptr)
			{
				n = new Queue;
				n->next = nullptr;
				n->t = head->t->right;
				n->d = head->d + 1;
				last->next = n;
				last = n;
			}
			else
			{
				n = new Queue;
				n->next = nullptr;
				n->t = head->t->left;
				n->d = head->d + 1;
				last->next = n;
				last = n;
				n = new Queue;
				n->next = nullptr;
				n->t = head->t->right;
				n->d = head->d + 1;
				last->next = n;
				last = n;
			}
			min = head->d;
			n = head;
			head = head->next;
			delete(n);
		}
		return min;
    }
};
// @lc code=end