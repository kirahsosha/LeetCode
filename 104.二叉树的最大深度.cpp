/*
 * @lc app=leetcode.cn id=104 lang=cpp
 *
 * [104] 二叉树的最大深度
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
	int searchTree(TreeNode* t, int d)
	{
		if (t->left == nullptr && t->right == nullptr) return d;
		int d1 = d, d2 = d;
		if (t->left != nullptr)
		{
			d1 = searchTree(t->left, d + 1);
		}
		if (t->right != nullptr)
		{
			d2 = searchTree(t->right, d + 1);
		}
		return d1 > d2 ? d1 : d2;
	}
    int maxDepth(TreeNode* root) {
		if (root == nullptr) return 0;
		return searchTree(root, 1);
    }
};
// @lc code=end

