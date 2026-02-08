using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

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

        public static TreeNode CreateTreeNode(string s)
        {
            var nums = JsonConvert.DeserializeObject<int?[]>(s);
            if (nums.Length == 0)
            {
                return null;
            }
            var nodes = new Queue<TreeNode>();
            foreach (var n in nums)
            {
                if (n.HasValue)
                {
                    var node = new TreeNode(n.Value);
                    nodes.Enqueue(node);
                }
                else
                {
                    nodes.Enqueue(null);
                }
            }
            TreeNode root = nodes.Dequeue();
            var q = new Queue<TreeNode>();
            q.Enqueue(root);
            while (nodes.Count > 0)
            {
                var node = q.Dequeue();
                node.left = nodes.Dequeue();
                node.right = nodes.Count > 0 ? nodes.Dequeue() : null;
                if (node.left != null)
                {
                    q.Enqueue(node.left);
                }
                if (node.right != null)
                {
                    q.Enqueue(node.right);
                }
            }
            return root;
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

    public class ArrayComparer : IEqualityComparer<int[]>
    {
        public bool Equals(int[] x, int[] y)
        {
            if (x.Length != y.Length) return false;
            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] != y[i]) return false;
            }
            return true;
        }

        public int GetHashCode([DisallowNull] int[] obj)
        {
            return obj.Sum();
        }
    }

    class Event : IComparable<Event>
    {
        public int Ts { get; set; }
        public int Op { get; set; }
        public int Val { get; set; }

        public Event(int ts, int op, int val)
        {
            Ts = ts;
            Op = op;
            Val = val;
        }

        public int CompareTo(Event other)
        {
            if (Ts != other.Ts)
            {
                return Ts.CompareTo(other.Ts);
            }
            return Op.CompareTo(other.Op);
        }
    }

    public class SegmentTree
    {
        private int n;
        private int[] cover;
        private int[] length;
        private int[] maxLength;

        public SegmentTree(IList<int> nums)
        {
            this.n = nums.Count;
            this.cover = new int[n * 4 + 1];
            this.length = new int[n * 4 + 1];
            this.maxLength = new int[n * 4 + 1];
            Build(0, n - 2, 0, nums);
        }

        public int GetLength()
        {
            return length[0];
        }

        public void Update(int index, int delta, int start, int end)
        {
            Update(index, delta, start, end, 1, n - 1);
        }

        private void Build(int start, int end, int treeIndex, IList<int> nums)
        {
            if (start == end)
            {
                maxLength[treeIndex] = nums[start + 1] - nums[start];
                return;
            }
            int mid = start + (end - start) / 2;
            Build(start, mid, treeIndex * 2 + 1, nums);
            Build(mid + 1, end, treeIndex * 2 + 2, nums);
            maxLength[treeIndex] = maxLength[treeIndex * 2 + 1] + maxLength[treeIndex * 2 + 2];
        }

        private void Update(int index, int delta, int rangeStart, int rangeEnd, int treeStart, int treeEnd)
        {
            if (treeStart > rangeEnd || treeEnd < rangeStart)
            {
                return;
            }
            if (treeStart >= rangeStart && treeEnd <= rangeEnd)
            {
                cover[index] += delta;
                UpdateLength(index, treeStart, treeEnd);
                return;
            }
            int mid = treeStart + (treeEnd - treeStart) / 2;
            Update(index * 2 + 1, delta, rangeStart, rangeEnd, treeStart, mid);
            Update(index * 2 + 2, delta, rangeStart, rangeEnd, mid + 1, treeEnd);
            UpdateLength(index, treeStart, treeEnd);
        }

        private void UpdateLength(int index, int treeStart, int treeEnd)
        {
            if (cover[index] > 0)
            {
                length[index] = maxLength[index];
            }
            else if (treeStart == treeEnd)
            {
                length[index] = 0;
            }
            else
            {
                length[index] = length[index * 2 + 1] + length[index * 2 + 2];
            }
        }
    }
}
