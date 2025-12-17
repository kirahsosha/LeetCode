using System.Collections.Generic;

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

    public class NumberConcatComparer : Comparer<int>
    {
        public override int Compare(int x, int y)
        {
            if (x == y) return 0;
            if (x == 0) return 1;
            if (y == 0) return -1;
            if (Concat(x, y) > Concat(y, x))
            {
                return -1;
            }
            return 1;
        }

        private long Concat(int x, int y)
        {
            int i = 1;
            while (i <= y)
            {
                i *= 10;
            }
            return (long)x * i + y;
        }
    }

    public class StringConcatComparer : IComparer<string>
    {
        public  int Compare(string x, string y)
        {
            int i = 0;
            while(i < x.Length && i < y.Length)
            {
                if(x[i] == y[i])
                {
                    i++;
                }
                else
                {
                    return x[i] - y[i];
                }
            }
            if(x.Length < y.Length)
            {
                return -1;
            }
            else if(x.Length > y.Length)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
