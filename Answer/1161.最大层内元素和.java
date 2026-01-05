
import java.util.ArrayList;
import java.util.List;

/*
 * @lc app=leetcode.cn id=1161 lang=java
 *
 * [1161] 最大层内元素和
 */
// @lc code=start
/**
 * Definition for a binary tree node. public class TreeNode { int val; TreeNode
 * left; TreeNode right; TreeNode() {} TreeNode(int val) { this.val = val; }
 * TreeNode(int val, TreeNode left, TreeNode right) { this.val = val; this.left
 * = left; this.right = right; } }
 */
class Solution {

    public int maxLevelSum(TreeNode root) {
        var max = 0;
        List<Integer> sum = new ArrayList<>();
        Dfs(root, 0, sum);
        for (int i = 0; i < sum.size(); i++) {
            if (sum.get(i) > sum.get(max)) {
                max = i;
            }
        }
        return max + 1;
    }

    private void Dfs(TreeNode root, int level, List<Integer> sum) {
        if (root != null) {
            if (sum.size() > level) {
                sum.set(level, sum.get(level) + root.val);
            } else {
                sum.add(root.val);
            }
            Dfs(root.left, level + 1, sum);
            Dfs(root.right, level + 1, sum);
        }
    }
}
// @lc code=end

