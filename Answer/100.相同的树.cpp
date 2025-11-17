/*
 * @lc app=leetcode.cn id=100 lang=cpp
 *
 * [100] 相同的树
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
	bool searchTree(TreeNode* p, TreeNode* q)
	{
		if (p == nullptr && q == nullptr) return true;
		if (p == nullptr || q == nullptr) return false;
		if (p->val != q->val) return false;
		if (searchTree(p->left, q->left) == false) return false;
		else if (searchTree(p->right, q->right) == false) return false;
		return true;
	}
	
    bool isSameTree(TreeNode* p, TreeNode* q) {
		return searchTree(p, q);
    }
};
// @lc code=end

