/*
 * @lc app=leetcode.cn id=112 lang=cpp
 *
 * [112] 路径总和
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
	bool searchTree(TreeNode* t, int d, int sum)
	{
		if (t->left == nullptr && t->right == nullptr)
		{
			if (d == sum) return true;
			return false;
		}
		if (t->left != nullptr)
		{
			if (searchTree(t->left, d + t->left->val, sum)) return true;
		}
		if (t->right != nullptr)
		{
			if (searchTree(t->right, d + t->right->val, sum)) return true;
		}
		return false;
	}
	
    bool hasPathSum(TreeNode* root, int sum) {
		if (root == nullptr) return false;
		return searchTree(root, root->val, sum);
    }
};
// @lc code=end

