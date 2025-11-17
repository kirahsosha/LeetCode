/*
 * @lc app=leetcode.cn id=101 lang=cpp
 *
 * [101] 对称二叉树
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
	bool searchTree(TreeNode* l, TreeNode* r)
	{
		if (l == nullptr && r == nullptr) return true;
		if (l == nullptr || r == nullptr) return false;
		if (l->val != r->val) return false;
		if (searchTree(l->left, r->right) == false) return false;
		else if (searchTree(l->right, r->left) == false) return false;
		return true;
	}
	
    bool isSymmetric(TreeNode* root) {
		if (root == nullptr) return true;
		if (root->left == nullptr && root->right == nullptr) return true;
		if (root->left == nullptr || root->right == nullptr) return false;
		return searchTree(root->left, root->right);
    }
};
// @lc code=end

