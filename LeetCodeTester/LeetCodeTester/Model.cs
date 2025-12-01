using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeTester
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class DoubleListNode
    {
        public int val;
        public int index;
        public DoubleListNode pre;
        public DoubleListNode next;
        public DoubleListNode(int val = 0, DoubleListNode pre = null, DoubleListNode next = null)
        {
            this.val = val;
            this.pre = pre;
            this.next = next;
        }
    }

    public class DescendingComparer : Comparer<int>
    {
        public override int Compare(int x, int y)
        {
            return y - x;
        }
    }
}
