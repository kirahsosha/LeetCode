/*
 * @lc app=leetcode.cn id=138 lang=csharp
 *
 * [138] 随机链表的复制
 */

// @lc code=start
/*
// Definition for a Node.
public class Node {
    public int val;
    public Node next;
    public Node random;
    
    public Node(int _val) {
        val = _val;
        next = null;
        random = null;
    }
}
*/

public class Solution
{
    public Node CopyRandomList(Node head)
    {
        if(head == null) return null;
        Node t = head;
        while (t != null)
        {
            Node n = new Node(t.val);
            n.next = t.next;
            t.next = n;
            t = n.next;
        }
        t = head;
        while (t != null)
        {
            Node n = t.next;
            if (t.random != null)
            {
                n.random = t.random.next;
            }
            t = n.next;
        }
        Node ans = head.next;
        t = head;
        while (t != null)
        {
            Node n = t.next;
            t.next = n.next;
            t = t.next;
            if (t != null)
            {
                n.next = t.next;
            }
            else
            {
                n.next = null;
            }
        }
        return ans;
    }
}
// @lc code=end

