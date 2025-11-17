/*
 * @lc app=leetcode.cn id=429 lang=csharp
 *
 * [429] N叉树的层序遍历
 */

// @lc code=start
/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> children;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val, IList<Node> _children) {
        val = _val;
        children = _children;
    }
}
*/

public class Solution {
    public IList<IList<int>> LevelOrder(Node root) {
        IList<IList<int>> ans = new List<IList<int>>{};
        if(root == null) return ans;
        Queue<Node> breadth = new Queue<Node>{};
        breadth.Enqueue(root);
        while(breadth.Count() != 0)
        {
            Queue<Node> q = new Queue<Node>{};
            Node t;
            IList<int> list = new List<int>{};
            while(breadth.Count() != 0)
            {
                t = breadth.Dequeue();
                q.Enqueue(t);
            }
            while(q.Count() != 0)
            {
                t = q.Dequeue();
                list.Add(t.val);
                foreach(Node n in t.children)
                {
                    breadth.Enqueue(n);
                }
            }
            ans.Add(list);
        }
        return ans;
    }
}
// @lc code=end

