using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace LeetCodeTester.Solutions
{
    public partial class Solution
    {
        const int MOD = 1000000007;

        public Solution() { }

        /// <summary>
        /// 443. 压缩字符串
        /// </summary>
        /// <param name="chars"></param>
        /// <returns></returns>
        /// 
        public int Compress(char[] chars)
        {
            if (chars.Length == 1) return 1;
            int ans = 0;
            char n = chars[0];
            int index = 0;
            int cindex = 0;
            foreach (var c in chars)
            {
                if (c == n)
                {
                    index++;
                }
                else
                {
                    ans += 1 + (index == 1 ? 0 : index.ToString().Length);
                    chars[cindex++] = n;
                    if (index != 1)
                    {
                        foreach (var cc in index.ToString())
                        {
                            chars[cindex++] = cc;
                        }
                    }
                    index = 1;
                    n = c;
                }
            }
            ans += 1 + (index == 1 ? 0 : index.ToString().Length);
            chars[cindex++] = n;
            if (index != 1)
            {
                foreach (var cc in index.ToString())
                {
                    chars[cindex++] = cc;
                }
            }
            chars = chars.Take(cindex).ToArray();
            return ans;
        }

        /// <summary>
        /// 457. 环形数组是否存在循环
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public bool CircularArrayLoop(int[] nums)
        {
            int len = nums.Length;
            if (len == 1) return false;
            Dictionary<int, bool> tested = new Dictionary<int, bool>();
            int index = 0;

            while (index < len)
            {
                if (!tested.ContainsKey(index))
                {
                    bool res = TestLoop(index, nums, tested);
                    if (res) return true;
                }
                index++;
            }
            return false;
        }

        public bool TestLoop(int index, int[] nums, Dictionary<int, bool> tested)
        {
            if (tested.ContainsKey(index) && tested[index])
            {
                //之前检查过的点，说明从这点开始不构成循环，返回false
                return false;
            }
            else if (tested.ContainsKey(index))
            {
                //这一次的点，说明构成了循环，返回true
                return true;
            }
            int next = (index + nums[index] + nums.Length * (Math.Abs(nums[index]) / nums.Length + 1)) % nums.Length;
            if (next == index)
            {
                //循环长度为1，返回false
                tested[index] = true;
                return false;
            }
            if (nums[next] / Math.Abs(nums[next]) != nums[index] / Math.Abs(nums[index]))
            {
                //方向不同，返回false
                tested[index] = true;
                return false;
            }
            tested.Add(index, false);
            bool res = TestLoop(next, nums, tested);
            tested[index] = !res;

            return res;
        }

        /// <summary>
        /// 551. 学生出勤记录 I
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool CheckRecord(string s)
        {
            int num_ab = 0;
            int num_la = 0;
            foreach (var c in s)
            {
                if (c == 'A')
                {
                    num_ab++;
                    num_la = 0;
                    if (num_ab == 2) return false;
                }
                else if (c == 'L')
                {
                    num_la++;
                    if (num_la == 3) return false;
                }
                else
                {
                    num_la = 0;
                }
            }
            return true;
        }

        public Dictionary<int, long> Absent0Late0 = new Dictionary<int, long>();
        public Dictionary<int, long> Absent1Late0 = new Dictionary<int, long>();
        public Dictionary<int, long> Absent0Late1 = new Dictionary<int, long>();
        public Dictionary<int, long> Absent1Late1 = new Dictionary<int, long>();
        public Dictionary<int, long> Absent0Late2 = new Dictionary<int, long>();
        public Dictionary<int, long> Absent1Late2 = new Dictionary<int, long>();

        /// <summary>
        /// 552. 学生出勤记录 II
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int CheckRecord(int n)
        {
            //初始化
            if (!Absent0Late0.ContainsKey(1))
            {
                Absent0Late0.Add(1, 1);
                Absent1Late0.Add(1, 1);
                Absent0Late1.Add(1, 1);
                Absent1Late1.Add(1, 0);
                Absent0Late2.Add(1, 0);
                Absent1Late2.Add(1, 0);
            }
            if (!Absent0Late0.ContainsKey(n))
            {
                CalRecord(n);
            }
            long num = Absent0Late0[n] + Absent1Late0[n] + Absent0Late1[n] + Absent1Late1[n] + Absent0Late2[n] + Absent1Late2[n];
            return (int)(num % MOD);
        }

        public void CalRecord(int n)
        {
            if (!Absent0Late0.ContainsKey(n - 1))
            {
                CalRecord(n - 1);
            }
            //Absent0Late0 + 'P' = Absent0Late0
            //Absent0Late0 + 'A' = Absent1Late0
            //Absent0Late0 + 'L' = Absent0Late1
            //Absent1Late0 + 'P' = Absent1Late0
            //Absent1Late0 + 'A' X
            //Absent1Late0 + 'L' = Absent1Late1
            //Absent0Late1 + 'P' = Absent0Late0
            //Absent0Late1 + 'A' = Absent1Late0
            //Absent0Late1 + 'L' = Absent0Late2
            //Absent1Late1 + 'P' = Absent1Late0
            //Absent1Late1 + 'A' X
            //Absent1Late1 + 'L' = Absent1Late2
            //Absent0Late2 + 'P' = Absent0Late0
            //Absent0Late2 + 'A' = Absent1Late0
            //Absent0Late2 + 'L' X
            //Absent1Late2 + 'P' = Absent1Late0
            //Absent1Late2 + 'A' X
            //Absent1Late2 + 'L' X
            Absent0Late0.Add(n, (Absent0Late0[n - 1] + Absent0Late1[n - 1] + Absent0Late2[n - 1]) % MOD);
            Absent1Late0.Add(n, (Absent0Late0[n - 1] + Absent1Late0[n - 1] + Absent0Late1[n - 1] + Absent1Late1[n - 1] + Absent0Late2[n - 1] + Absent1Late2[n - 1]) % MOD);
            Absent0Late1.Add(n, Absent0Late0[n - 1] % MOD);
            Absent1Late1.Add(n, Absent1Late0[n - 1] % MOD);
            Absent0Late2.Add(n, Absent0Late1[n - 1] % MOD);
            Absent1Late2.Add(n, Absent1Late1[n - 1] % MOD);
        }

        /// <summary>
        /// 576. 出界的路径数
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <param name="maxMove"></param>
        /// <param name="startRow"></param>
        /// <param name="startColumn"></param>
        /// <returns></returns>
        public int FindPaths(int m, int n, int maxMove, int startRow, int startColumn)
        {
            if (maxMove == 0) return 0;
            //int[k][i][j] path 每一步到每个坐标的路径数
            //k - 当前步数
            //i - x坐标
            //j - y坐标
            //path[k][i][j] = path[k-1][i-1][j] + path[k-1][i+1][j] + path[k-1][i][j-1] + path[k-1][i][j+1]
            int[][][] path = new int[2][][];
            path[0] = new int[m][];
            path[1] = new int[m][];
            for (int i = 0; i < m; i++)
            {
                path[0][i] = new int[n];
                path[1][i] = new int[n];
            }
            path[0][startRow][startColumn] = 1;
            int po = 1;
            int pn = 0;
            int ans = 0;
            if (startRow == 0) ans++;
            if (startRow == m - 1) ans++;
            if (startColumn == 0) ans++;
            if (startColumn == n - 1) ans++;
            for (int k = 1; k < maxMove; k++)
            {
                po = 1 - po;
                pn = 1 - pn;
                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        path[pn][i][j] = 0;
                        if (i > 0) path[pn][i][j] = (path[pn][i][j] + path[po][i - 1][j]) % MOD;
                        if (i < m - 1) path[pn][i][j] = (path[pn][i][j] + path[po][i + 1][j]) % MOD;
                        if (j > 0) path[pn][i][j] = (path[pn][i][j] + path[po][i][j - 1]) % MOD;
                        if (j < n - 1) path[pn][i][j] = (path[pn][i][j] + path[po][i][j + 1]) % MOD;
                        //如果是靠边的点，下一步就可以出界
                        if (i == 0) ans = (ans + path[pn][i][j]) % MOD;
                        if (i == m - 1) ans = (ans + path[pn][i][j]) % MOD;
                        if (j == 0) ans = (ans + path[pn][i][j]) % MOD;
                        if (j == n - 1) ans = (ans + path[pn][i][j]) % MOD;
                    }
                }
            }
            return ans;
        }

        /// <summary>
        /// 787. K 站中转内最便宜的航班
        /// </summary>
        /// <param name="n"></param>
        /// <param name="flights"></param>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k)
        {
            Dictionary<int, Dictionary<int, int>> dic = flights.GroupBy(p => p[0]).ToDictionary(p => p.Key, p => p.ToDictionary(q => q[1], q => q[2]));
            return FindPrice(dic, src, dst, 0, k);
        }

        public int FindPrice(Dictionary<int, Dictionary<int, int>> dic, int src, int dst, int index, int k)
        {
            if (index > k) return -1;
            index++;
            int ans = -1;
            if (!dic.ContainsKey(src)) return -1;
            foreach (var lines in dic[src])
            {
                int to = lines.Key;
                int price = lines.Value;
                if (to == dst)
                {
                    ans = ans == -1 ? price : Math.Min(ans, price);
                    continue;
                }
                int next = FindPrice(dic, to, dst, index, k);
                ans = next == -1 ? ans : (ans == -1 ? price + next : Math.Min(ans, price + next));
            }
            return ans;
        }

        /// <summary>
        /// 1337. 矩阵中战斗力最弱的 K 行
        /// </summary>
        /// <param name="mat"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[] KWeakestRows(int[][] mat, int k)
        {
            List<int[]> list = new List<int[]>();
            for (int i = 0; i < mat.Length; i++)
            {
                int sum = mat[i].Sum();
                list.Add(new int[] { sum, i });
            }
            return list.OrderBy(p => p[0]).ThenBy(p => p[1]).Take(k).Select(p => p[1]).ToArray();
        }

        /// <summary>
        /// 49. 字母异位词分组
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            var dic = new Dictionary<string, List<string>>();
            foreach (var str in strs)
            {
                var sortedStr = new string(str.OrderBy(c => c).ToArray());
                if (dic.ContainsKey(sortedStr))
                {
                    dic[sortedStr].Add(str);
                }
                else
                {
                    dic.Add(sortedStr, new List<string> { str });
                }
            }
            return dic.Select(p => p.Value).Cast<IList<string>>().ToList();
        }

        /// <summary>
        /// [438] 找到字符串中所有字母异位词
        /// </summary>
        /// <param name="s"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public IList<int> FindAnagrams(string s, string p)
        {
            var ns = p + s;
            var res = new List<int>();
            var cs = p.ToList();
            var lostChar = cs.Distinct().Select(c => new KeyValuePair<char, int>(c, 0)).ToDictionary(p => p.Key, p => p.Value);
            for (int i = 0; i < s.Length; i++)
            {
                //移除前一个字符
                cs.Remove(ns[i]);
                //添加后一个字符
                cs.Add(ns[i + p.Length]);
                //前一个字符符合条件时添加
                if (lostChar.ContainsKey(ns[i]))
                {
                    lostChar[ns[i]]++;
                }
                //后一个字符符合条件时移除
                if (lostChar.ContainsKey(ns[i + p.Length]))
                {
                    lostChar[ns[i + p.Length]]--;
                }
                if (lostChar.Values.All(p => p == 0) && i + 1 - p.Length >= 0)
                {
                    res.Add(i + 1 - p.Length);
                }
            }
            return res;
        }

        /// <summary>
        /// [160] 相交链表
        /// </summary>
        /// <param name="headA"></param>
        /// <param name="headB"></param>
        /// <returns></returns>
        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            int a = 0;
            var na = headA;
            while (na != null)
            {
                a++;
                na = na.next;
            }
            int b = 0;
            var nb = headB;
            while (nb != null)
            {
                b++;
                nb = nb.next;
            }
            if (a < b)
            {
                na = headB;
                nb = headA;
                var c = a;
                a = b;
                b = c;
            }
            else
            {
                na = headA;
                nb = headB;
            }
            for (int i = 0; i < a - b; i++)
            {
                na = na.next;
            }
            while (na != null && nb != null)
            {
                if (na == nb) return na;
                na = na.next;
                nb = nb.next;
            }
            return null;
        }

        /// <summary>
        /// [543] 二叉树的直径
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int DiameterOfBinaryTree(TreeNode root)
        {
            CheckDepth(root, out var maxDepth);
            return maxDepth;
        }

        private int CheckDepth(TreeNode node, out int maxDepth)
        {
            int leftDepth = 0;
            int rightDepth = 0;
            int lmax = 0;
            int rmax = 0;
            if (node.left != null)
            {
                leftDepth = CheckDepth(node.left, out lmax) + 1;
            }

            if (node.right != null)
            {
                rightDepth = CheckDepth(node.right, out rmax) + 1;
            }
            maxDepth = Math.Max(Math.Max(lmax, rmax), leftDepth + rightDepth);
            return Math.Max(leftDepth, rightDepth);
        }

        /// <summary>
        /// [2327] 知道秘密的人数
        /// </summary>
        /// <param name="n"></param>
        /// <param name="delay"></param>
        /// <param name="forget"></param>
        /// <returns></returns>
        public int PeopleAwareOfSecret(int n, int delay, int forget)
        {
            int[] res = new int[n];
            res[0] = 1;
            int sum = 1;
            //1, 0, 1, 1, 1, 2
            for (int i = 1; i < n; i++)
            {
                res[i] = 0;
                for (int j = i - delay; j > i - forget; j--)
                {
                    if (j < 0) break;
                    res[i] = (res[i] + res[j]) % MOD;
                }
                if (i - forget >= 0)
                {
                    sum = (sum + res[i] - res[i - forget]) % MOD;
                }
                else
                {
                    sum = (sum + res[i]) % MOD;
                }
            }

            return sum;
        }

        /// <summary>
        /// 31. 下一个排列
        /// </summary>
        /// <param name="nums"></param>
        public void NextPermutation(int[] nums)
        {
            if (nums.Length == 1) return;
            int i = nums.Length - 2;
            int j = nums.Length - 1;
            int k = nums.Length - 1;

            // find: A[i] < A[j]
            while (i >= 0 && nums[i] >= nums[j])
            {
                i--;
                j--;
            }

            if (i >= 0)
            {
                // 不是最后一个排列
                // find: A[i] < A[k]
                while (nums[i] >= nums[k])
                {
                    k--;
                }
                // swap A[i], A[k]
                var t = nums[i];
                nums[i] = nums[k];
                nums[k] = t;
            }

            // reverse A[j:end]
            int left = j, right = nums.Length - 1;
            Reverse(nums, left, right);
        }

        private void Reverse(int[] nums, int left, int right)
        {
            while (left < right)
            {
                int temp = nums[left];
                nums[left] = nums[right];
                nums[right] = temp;
                left++;
                right--;
            }
        }

        /// <summary>
        /// [108] 将有序数组转换为二叉搜索树
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public TreeNode SortedArrayToBST(int[] nums)
        {
            return GetChildBST(nums, 0, nums.Length - 1);
        }

        private TreeNode GetChildBST(int[] nums, int left, int right)
        {
            if (left < 0 || right > nums.Length - 1 || left > right) return null;
            var n = (left + right) / 2;
            var root = new TreeNode
            {
                val = nums[n],
                left = GetChildBST(nums, left, n - 1),
                right = GetChildBST(nums, n + 1, right)
            };
            return root;
        }

        /// <summary>
        /// [24] 两两交换链表中的节点
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode SwapPairs(ListNode head)
        {
            if (head == null || head.next == null) return head;

            //Swap head
            var node = head;
            head = node.next;
            node.next = head.next;
            head.next = node;

            //Swap next
            while (node.next != null && node.next.next != null)
            {
                var t = node.next;
                var k = t.next;
                node.next = k;
                t.next = k.next;
                k.next = t;
                node = t;
            }
            return head;
        }

        /// <summary>
        /// [73] 矩阵置零
        /// </summary>
        /// <param name="matrix"></param>
        public void SetZeroes(int[][] matrix)
        {
            var m = matrix.Length;
            var n = matrix[0].Length;
            var a = 1;
            var b = 1;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        if (i == 0)
                        {
                            a = 0;
                        }
                        if (j == 0)
                        {
                            b = 0;
                        }
                        matrix[i][0] = 0;
                        matrix[0][j] = 0;
                    }
                }
            }
            for (int i = 1; i < m; i++)
            {
                if (matrix[i][0] == 0)
                {
                    for (int j = 0; j < n; j++)
                    {
                        matrix[i][j] = 0;
                    }
                }
            }
            for (int j = 1; j < n; j++)
            {
                if (matrix[0][j] == 0)
                {
                    for (int i = 0; i < m; i++)
                    {
                        matrix[i][j] = 0;
                    }
                }
            }
            if (a == 0)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[0][j] = 0;
                }
            }
            if (b == 0)
            {
                for (int i = 0; i < m; i++)
                {
                    matrix[i][0] = 0;
                }
            }
        }

        /// <summary>
        /// [437] 路径总和 III
        /// </summary>
        /// <param name="root"></param>
        /// <param name="targetSum"></param>
        /// <returns></returns>
        public int PathSum(TreeNode root, int targetSum)
        {
            return CheckRoot(root, targetSum, new List<long>());
        }

        private int CheckRoot(TreeNode root, int targetSum, List<long> parentSum)
        {
            var count = 0;
            if (root == null) return 0;
            parentSum.Add(0);
            for (int i = 0; i < parentSum.Count; i++)
            {
                parentSum[i] += root.val;
                if (parentSum[i] == targetSum) count++;
            }
            var leftSum = CheckRoot(root.left, targetSum, new List<long>(parentSum));
            var rightSum = CheckRoot(root.right, targetSum, new List<long>(parentSum));
            return count + leftSum + rightSum;
        }

        /// <summary>
        /// [994] 腐烂的橘子
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int OrangesRotting(int[][] grid)
        {
            var rot = new List<Tuple<int, int>>();
            var fresh = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] == 2)
                    {
                        rot.Add(new Tuple<int, int>(i, j));
                    }
                    else if (grid[i][j] == 1)
                    {
                        fresh++;
                    }
                }
            }
            if (fresh == 0) return 0;
            if (rot.Count == 0) return -1;
            int d = 0;
            while (d >= 0)
            {
                d++;
                var rot2 = new List<Tuple<int, int>>();
                int count = 0;
                foreach (var r in rot)
                {
                    int i = r.Item1;
                    int j = r.Item2;
                    if (i - 1 >= 0 && grid[i - 1][j] == 1)
                    {
                        grid[i - 1][j] = 2;
                        rot2.Add(new Tuple<int, int>(i - 1, j));
                        count++;
                        fresh--;
                    }
                    if (j - 1 >= 0 && grid[i][j - 1] == 1)
                    {
                        grid[i][j - 1] = 2;
                        rot2.Add(new Tuple<int, int>(i, j - 1));
                        count++;
                        fresh--;
                    }
                    if (i + 1 < grid.Length && grid[i + 1][j] == 1)
                    {
                        grid[i + 1][j] = 2;
                        rot2.Add(new Tuple<int, int>(i + 1, j));
                        count++;
                        fresh--;
                    }
                    if (j + 1 < grid[0].Length && grid[i][j + 1] == 1)
                    {
                        grid[i][j + 1] = 2;
                        rot2.Add(new Tuple<int, int>(i, j + 1));
                        count++;
                        fresh--;
                    }
                }
                if (count == 0 || fresh == 0) break;
                rot = rot2;
            }
            if (fresh == 0) return d;
            return -1;
        }

        /// <summary>
        /// [94] 二叉树的中序遍历
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> InorderTraversal(TreeNode root)
        {
            List<int> list = new List<int> { };
            if (root == null) return list;
            list.AddRange(InorderTraversal(root.left));
            list.Add(root.val);
            list.AddRange(InorderTraversal(root.right));
            return list;
        }

        /// <summary>
        /// [3541] 找到频率最高的元音和辅音
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int MaxFreqSum(string s)
        {
            if (s.Length == 1) return 1;
            var vowel = new Dictionary<char, int>
            {
                { ' ', 0 }
            };
            var consonant = new Dictionary<char, int>
            {
                { ' ', 0 }
            };
            foreach (var c in s)
            {
                if ("aeiou".Contains(c))
                {
                    if (vowel.ContainsKey(c))
                    {
                        vowel[c]++;
                    }
                    else
                    {
                        vowel.Add(c, 1);
                    }
                }
                else
                {
                    if (consonant.ContainsKey(c))
                    {
                        consonant[c]++;
                    }
                    else
                    {
                        consonant.Add(c, 1);
                    }
                }
            }
            return vowel.Values.Max() + consonant.Values.Max();
        }

        /// <summary>
        /// [78] 子集
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> Subsets(int[] nums)
        {
            List<IList<int>> res = new List<IList<int>>()
            {
                new List<int>()
            };
            foreach (var i in nums)
            {
                var count = res.Count;
                for (int k = 0; k < count; k++)
                {
                    var nlist = new List<int>(res[k]);
                    nlist.Add(i);
                    res.Add(nlist);
                }
            }

            return res;
        }

        public int SmallestAbsent(int[] nums)
        {
            double avg = (nums.Sum() * 1.0) / nums.Length;
            if (avg < 0) avg = 0;
            int min = (int)Math.Floor(avg) + 1;
            while (nums.Contains(min))
            {
                min++;
            }
            return min;
        }

        public int MinArrivalsToDiscard(int[] arrivals, int w, int m)
        {
            var ans = 0;
            Dictionary<int, int> window = new Dictionary<int, int>();
            for (int i = 0; i < arrivals.Length; i++)
            {
                if (window.ContainsKey(arrivals[i]))
                {
                    window[arrivals[i]]++;
                }
                else
                {
                    window.Add(arrivals[i], 1);
                }
                if (i >= w)
                {
                    if (arrivals[i - w] > 0)
                    {
                        window[arrivals[i - w]]--;
                    }
                }

                if (window[arrivals[i]] > m)
                {
                    window[arrivals[i]]--;
                    arrivals[i] = 0;
                    ans++;
                }
            }
            return ans;
        }

        public int EarliestTime(int[][] tasks)
        {
            int min = tasks.Min(p => p[0] + p[1]);
            return min;
        }

        public int[] MaxKDistinct(int[] nums, int k)
        {
            List<int> res = new List<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (res.Contains(nums[i])) continue;
                for (int j = 0; j <= res.Count; j++)
                {
                    if (j == res.Count)
                    {
                        res.Add(nums[i]);
                        break;
                    }
                    else if (nums[i] > res[j])
                    {
                        res.Insert(j, nums[i]);
                        break;
                    }
                }
            }
            return res.Take(k).ToArray();
        }

        public bool[] SubsequenceSumAfterCapping(int[] nums, int k)
        {
            int n = nums.Length;
            List<List<int>> res = new List<List<int>>();
            int min = 4000;

            //Find smallest
            for (int i = 0; i < n; i++)
            {
                if (nums[i] == k)
                {
                    min = Math.Min(min, nums[i]);
                    break;
                }
                else if (nums[i] > k)
                {
                    break;
                }
                int r = res.Count;
                res.Add(new List<int> { nums[i] });
                for (int j = 0; j < r; j++)
                {
                    var sum = res[j].Sum() + nums[i];
                    if (sum == k)
                    {
                        min = Math.Min(min, Math.Max(nums[i], res[j].Max()));
                    }
                    else if (sum < k)
                    {
                        var t = new List<int>(res[j]);
                        t.Add(nums[i]);
                        res.Add(t);
                    }
                }
            }
            var ans = new List<bool>();
            for (int i = 0; i < n; i++)
            {
                if (i + 1 < min)
                {
                    ans.Add(false);
                }
                else
                {
                    ans.Add(true);
                }
            }
            return ans.ToArray();
        }

        /// <summary>
        /// [966] 元音拼写检查器
        /// </summary>
        /// <param name="wordlist"></param>
        /// <param name="queries"></param>
        /// <returns></returns>
        public string[] Spellchecker(string[] wordlist, string[] queries)
        {
            ISet<string> match = new HashSet<string>();
            IDictionary<string, string> matchIgnoreCase = new Dictionary<string, string>();
            IDictionary<string, string> matchIgnoreVowel = new Dictionary<string, string>();
            foreach (string word in wordlist)
            {
                match.Add(word);
                string wordLower = word.ToLower();
                matchIgnoreCase.TryAdd(wordLower, word);
                string ignoreVowel = IgnoreVowel(wordLower);
                matchIgnoreVowel.TryAdd(ignoreVowel, word);
            }
            int length = queries.Length;
            string[] answer = new string[length];
            for (int i = 0; i < length; i++)
            {
                string query, queryLower, queryLowerIgnoreVowel;
                if (match.Contains(query = queries[i]))
                {
                    answer[i] = query;
                }
                else if (matchIgnoreCase.ContainsKey(queryLower = query.ToLower()))
                {
                    answer[i] = matchIgnoreCase[queryLower];
                }
                else if (matchIgnoreVowel.ContainsKey(queryLowerIgnoreVowel = IgnoreVowel(queryLower)))
                {
                    answer[i] = matchIgnoreVowel[queryLowerIgnoreVowel];
                }
                else
                {
                    answer[i] = "";
                }
            }
            return answer;
        }

        public string IgnoreVowel(string str)
        {
            char[] array = str.ToCharArray();
            int length = array.Length;
            for (int i = 0; i < length; i++)
            {
                if (IsVowel(array[i]))
                {
                    array[i] = '.';
                }
            }
            return new string(array);
        }

        public bool IsVowel(char c)
        {
            return c == 'A' || c == 'E' || c == 'I' || c == 'O' || c == 'U' || c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u';
        }

        /// <summary>
        /// [207] 课程表
        /// </summary>
        /// <param name="numCourses"></param>
        /// <param name="prerequisites"></param>
        /// <returns></returns>
        public bool CanFinish(int numCourses, int[][] prerequisites)
        {
            var learned = new List<int>();
            var preDic = new Dictionary<int, HashSet<int>>();
            foreach (var pre in prerequisites)
            {
                if (preDic.ContainsKey(pre[0]))
                {
                    preDic[pre[0]].Add(pre[1]);
                }
                else
                {
                    preDic.Add(pre[0], new HashSet<int>() { pre[1] });
                }
            }
            for (int i = 0; i < numCourses; i++)
            {
                if (learned.Contains(i)) continue;
                var res = LearnCourse(i, learned, new List<int>(), preDic);
                if (res == false) return false;
            }
            return true;
        }

        private bool LearnCourse(int course, List<int> learned, List<int> needLearn, Dictionary<int, HashSet<int>> preDic)
        {
            if (learned.Contains(course))
            {
                return true;
            }
            if (needLearn.Contains(course))
            {
                return false;
            }
            if (!preDic.TryGetValue(course, out var pre))
            {
                learned.Add(course);
                return true;
            }
            if (pre.Count == 0)
            {
                learned.Add(course);
                preDic.Remove(course);
                return true;
            }
            needLearn.Add(course);
            foreach (var preCourse in pre)
            {
                var res = LearnCourse(preCourse, learned, needLearn, preDic);
                if (res == false) return false;
            }
            learned.Add(course);
            needLearn.Remove(course);
            preDic.Remove(course);
            return true;
        }

        /// <summary>
        /// [17] 电话号码的字母组合
        /// </summary>
        /// <param name="digits"></param>
        /// <returns></returns>
        public IList<string> LetterCombinations(string digits)
        {
            if (digits.Length == 0) return new List<string>();
            var dic = new Dictionary<char, string>()
            {
                { '2', "abc" },
                { '3', "def" },
                { '4', "ghi" },
                { '5', "jkl" },
                { '6', "mno" },
                { '7', "pqrs" },
                { '8', "tuv" },
                { '9', "wxyz" },
            };
            var result = new List<string>();
            Combination(digits, 0, "", dic, result);
            return result;
        }

        private void Combination(string digits, int index, string combine, Dictionary<char, string> dic, List<string> result)
        {
            var mid = new List<string>();
            foreach (var c in dic[digits[index]])
            {
                mid.Add(combine + c);
            }
            if (index == digits.Length - 1)
            {
                result.AddRange(mid);
                return;
            }
            foreach (var s in mid)
            {
                Combination(digits, index + 1, s, dic, result);
            }
        }

        /// <summary>
        /// [34] 在排序数组中查找元素的第一个和最后一个位置
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] SearchRange(int[] nums, int target)
        {
            int start = SearchStart(nums, target);
            if (start < 0)
            {
                return new int[] { -1, -1 };
            }
            int end = SearchEnd(nums, target);
            return new int[] { start, end };
        }

        public int SearchStart(int[] nums, int target)
        {
            int low = 0, high = nums.Length - 1;
            while (low < high)
            {
                int mid = low + (high - low) / 2;
                if (nums[mid] >= target)
                {
                    high = mid;
                }
                else
                {
                    low = mid + 1;
                }
            }
            return low < nums.Length && nums[low] == target ? low : -1;
        }

        public int SearchEnd(int[] nums, int target)
        {
            int low = 0, high = nums.Length - 1;
            while (low < high)
            {
                int mid = low + (high - low + 1) / 2;
                if (nums[mid] <= target)
                {
                    low = mid;
                }
                else
                {
                    high = mid - 1;
                }
            }
            return low < nums.Length && nums[low] == target ? low : -1;
        }

        /// <summary>
        /// [2197] 替换数组中的非互质数
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<int> ReplaceNonCoprimes(int[] nums)
        {
            if (nums.Length <= 1) return nums.ToList();

            var res = new List<int>();
            var left = nums[0];

            for (int i = 0; i < nums.Length; i++)
            {
                int num = nums[i];
                while (res.Count > 0)
                {
                    int last = res[res.Count - 1];
                    int gcd = Common.GCD(last, num);
                    if (gcd > 1)
                    {
                        num = last / gcd * num;
                        res.RemoveAt(res.Count - 1);
                    }
                    else
                    {
                        break;
                    }
                }
                res.Add(num);
            }
            return res;
        }

        /// <summary>
        /// [215] 数组中的第K个最大元素
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int FindKthLargest(int[] nums, int k)
        {
            var s = nums.OrderByDescending(p => p).ToList();
            return s[k - 1];
        }

        /// <summary>
        /// [39] 组合总和
        /// </summary>
        /// <param name="candidates"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            var res = new List<IList<int>>();
            if (target == 0) return res;
            foreach (var i in candidates)
            {
                if (i > target)
                {
                    continue;
                }
                else if (i == target)
                {
                    res.Add(new List<int>(i));
                }
                else
                {
                    var can = CombinationSum(candidates, target - i).ToList();
                    can.ForEach(c => c.Add(i));
                    res.AddRange(can);
                }
            }
            return res;
        }

        /// <summary>
        /// [124] 二叉树中的最大路径和
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int MaxPathSum(TreeNode root)
        {
            return MaxChildValue(root, out _);
        }

        private int MaxChildValue(TreeNode root, out int child)
        {
            int mid = root.val;
            child = root.val;
            int left = -1001;
            int lChild = -1001;
            int right = -1001;
            int rChild = -1001;
            if (root.left != null)
            {
                left = MaxChildValue(root.left, out lChild);
            }
            if (root.right != null)
            {
                right = MaxChildValue(root.right, out rChild);
            }
            var max = Math.Max(mid, Math.Max(left, Math.Max(right, Math.Max(mid + lChild, Math.Max(mid + rChild, mid + lChild + rChild)))));
            child = Math.Max(mid, Math.Max(mid + lChild, mid + rChild));
            return max;
        }

        /// <summary>
        /// [189] 轮转数组
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        public void Rotate(int[] nums, int k)
        {
            int n = nums.Length;
            k = k % n;
            if (k == 0)
            {
                return;
            }
            int t = 0;
            //全体反转
            int i = 0, j = n - 1;
            while (i < j)
            {
                t = nums[i];
                nums[i] = nums[j];
                nums[j] = t;
                i++;
                j--;
            }
            //前半反转
            i = 0;
            j = k - 1;
            while (i < j)
            {
                t = nums[i];
                nums[i] = nums[j];
                nums[j] = t;
                i++;
                j--;
            }
            //后半反转
            i = k;
            j = n - 1;
            while (i < j)
            {
                t = nums[i];
                nums[i] = nums[j];
                nums[j] = t;
                i++;
                j--;
            }
            return;
        }

        /// <summary>
        /// [79] 单词搜索
        /// </summary>
        /// <param name="board"></param>
        /// <param name="word"></param>
        /// <returns></returns>
        public bool Exist(char[][] board, string word)
        {
            int row = board.GetLength(0);
            int col = board[0].GetLength(0);
            bool[,] used = new bool[row, col];

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (Exist(board, word, i, j, 0, used)) return true;
                }
            }
            return false;
        }

        private bool Exist(char[][] board, string word, int i, int j, int k, bool[,] used)
        {
            if (board[i][j] != word[k])
            {
                return false;
            }
            if (k == word.Length - 1)
            {
                return true;
            }
            used[i, j] = true;
            if (i > 0 && used[i - 1, j] == false)
            {
                if (Exist(board, word, i - 1, j, k + 1, used)) return true;
            }
            if (j > 0 && used[i, j - 1] == false)
            {
                if (Exist(board, word, i, j - 1, k + 1, used)) return true;
            }
            if (i < board.Length - 1 && used[i + 1, j] == false)
            {
                if (Exist(board, word, i + 1, j, k + 1, used)) return true;
            }
            if (j < board[0].Length - 1 && used[i, j + 1] == false)
            {
                if (Exist(board, word, i, j + 1, k + 1, used)) return true;
            }
            used[i, j] = false;
            return false;
        }

        /// <summary>
        /// [139] 单词拆分
        /// </summary>
        /// <param name="s"></param>
        /// <param name="wordDict"></param>
        /// <returns></returns>
        public bool WordBreak(string s, IList<string> wordDict)
        {
            if (wordDict.Contains(s)) return true;
            wordDict = wordDict.OrderByDescending(p => p.Length).ToList();
            foreach (var word in wordDict)
            {
                if (WordBreak(s, wordDict, word))
                {
                    return true;
                }
            }
            return false;
        }

        private bool WordBreak(string s, IList<string> wordDict, string word)
        {
            if (string.IsNullOrEmpty(s)) return true;
            if (s.Length < word.Length) return false;
            if (s == word) return true;
            if (s.StartsWith(word))
            {
                foreach (var w in wordDict)
                {
                    if (WordBreak(s.Substring(word.Length), wordDict, w))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// [239] 滑动窗口最大值
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[] MaxSlidingWindow(int[] nums, int k)
        {
            int[] arr = new int[nums.Length - k + 1];
            //保证准备的是大顶堆
            PriorityQueue<int, int> pq = new();
            int i = 0;
            int j = k - 1;
            for (int n = i; n <= j; n++)
            {
                pq.Enqueue(n, -nums[n]);
            }
            int m = 0;
            arr[m++] = nums[pq.Peek()];
            while (j < nums.Length - 1)
            {
                pq.Enqueue(j + 1, -nums[j + 1]);
                //最大值的下标已经出去了
                while (pq.Peek() < i + 1)
                {
                    pq.Dequeue();
                }
                arr[m++] = nums[pq.Peek()];
                i++; j++;
            }
            return arr;
        }

        /// <summary>
        /// [611] 有效三角形的个数
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int TriangleNumber(int[] nums)
        {
            if (nums.Length < 3) return 0;
            List<List<int>> tri = new List<List<int>>();
            var res = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0) continue;
                res += tri.Where(p => p[0] <= nums[i] && p[1] >= nums[i]).Count();
                if (i == nums.Length - 1) break;
                for (int j = 0; j < i; j++)
                {
                    if (nums[j] == 0) continue;

                    tri.Add(TriangleNumber(nums[i], nums[j]));
                }
            }
            return res;
        }

        private List<int> TriangleNumber(int a, int b)
        {
            int max = a + b - 1;
            int min = Math.Abs(a - b) + 1;
            return new List<int> { min, max };
        }

        public int ZigZagArrays(int n, int l, int r)
        {//    int[][] up = new int[n + 1][];
         //    int[][] dw = new int[n + 1][];
         //    int d = r - l + 1;
         //    for (int i = 0; i < n + 1; i++)
         //    {
         //        up[i] = new int[d + 1];
         //        dw[i] = new int[d + 1];
         //        for (int j = 1; j < d + 1; j++)
         //        {
         //            if (i == 0)
         //            {
         //                up[i][j] = 0;
         //                dw[i][j] = 0;
         //            }
         //            else if (i == 1)
         //            {
         //                up[i][j] = 1;
         //                dw[i][j] = 1;
         //            }
         //            else if (i == 2)
         //            {
         //                up[i][j] = j - 1;
         //                dw[i][j] = d - j;
         //            }
         //            else
         //            {
         //                for (int k = 1; k < j; k++)
         //                {
         //                    up[i][j] = (up[i][j] + dw[i - 1][k]) % MOD;
         //                }
         //                for (int k = j + 1; k < d + 1; k++)
         //                {
         //                    dw[i][j] = (dw[i][j] + up[i - 1][k]) % MOD;
         //                }
         //            }
         //        }
         //    }
         //    int res = 0;
         //    for (int i = 1; i < d + 1; i++)
         //    {
         //        res = (res + up[n][i] + dw[n][i]) % MOD;
         //    }
         //    return res;
            int res = 0;
            int d = r - l + 1;
            for (int i = 1; i < d + 1; i++)
            {
                res = (res + ZigZagArraysGetLess(n, d, i)) % MOD;
                res = (res + ZigZagArraysGetLarge(n, d, i)) % MOD;
            }
            return res;
        }

        private int ZigZagArraysGetLess(int n, int d, int c)
        {
            if (n == 1) return 1;
            int res = 0;
            for (int i = 1; i < c; i++)
            {
                res = (res + ZigZagArraysGetLarge(n - 1, d, i)) % MOD;
            }
            return res;
        }

        private int ZigZagArraysGetLarge(int n, int d, int c)
        {
            if (n == 1) return 1;
            int res = 0;
            for (int i = c + 1; i < d + 1; i++)
            {
                res = (res + ZigZagArraysGetLess(n - 1, d, i)) % MOD;
            }
            return res;
        }

        public int LargestPerimeter(int[] nums)
        {
            nums = nums.OrderByDescending(x => x).ToArray();
            Dictionary<int, int> range = new Dictionary<int, int>();
            var res = 0;
            int n = nums.Length;
            for (int i = 0; i < n; i++)
            {
                if (range.ContainsKey(nums[i]))
                {
                    res = Math.Max(res, nums[i] + range[nums[i]]);
                    return res;
                }
                if (i == n - 1) break;
                for (int j = 0; j < i; j++)
                {
                    int min = Math.Abs(nums[i] - nums[j]) + 1;
                    int max = nums[i] + nums[j];
                    for (int k = min; k < max; k++)
                    {
                        if (!range.ContainsKey(k))
                        {
                            range.Add(k, max);
                        }
                    }
                }
            }
            return res;
        }

        public int LongestConsecutive(int[] nums)
        {
            if (nums.Length == 0) return 0;
            if (nums.Length == 1) return 1;
            Array.Sort(nums);
            int ans = 0;
            int index = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] == nums[i - 1] + 1)
                {
                    index++;
                }
                else if (nums[i] == nums[i - 1])
                {
                    continue;
                }
                else
                {
                    ans = Math.Max(ans, index);
                    index = 1;
                }
            }
            ans = Math.Max(ans, index);
            return ans;
        }

        /// <summary>
        /// [763] 划分字母区间
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public IList<int> PartitionLabels(string s)
        {
            if (s.Length == 1) return new List<int> { 1 };
            Dictionary<char, int[]> dic = new Dictionary<char, int[]>();
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (dic.ContainsKey(c))
                {
                    dic[c][1] = i;
                }
                else
                {
                    dic.Add(c, new int[] { i, i });
                }
            }
            List<int[]> ranges = new List<int[]>();
            foreach (var c in dic.Values)
            {
                var left = c[0];
                var right = c[1];
                var range = ranges
                    .Where(r => r[0] <= left && r[1] >= left
                    || r[0] <= right && r[1] >= right
                    || r[0] <= left && r[1] >= right
                    || r[0] >= left && r[1] <= right);
                if (range.Any())
                {
                    left = Math.Min(left, range.Min(r => r[0]));
                    right = Math.Max(right, range.Max(r => r[1]));
                    ranges.RemoveAll(r => r[0] >= left && r[1] <= right);
                    ranges.Add(new int[] { left, right });
                }
                else
                {
                    ranges.Add(new int[] { left, right });
                }
            }
            var res = ranges.Select(r => r[1] - r[0] + 1).ToList();
            return res;
        }

        /// <summary>
        /// [347] 前 K 个高频元素
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[] TopKFrequent(int[] nums, int k)
        {
            if (nums.Length == k) return nums;
            Dictionary<int, int> count = new Dictionary<int, int>();
            SortedDictionary<int, List<int>> dic = new SortedDictionary<int, List<int>>
            {
                { 1, new List<int>() }
            };
            foreach (int i in nums)
            {
                if (count.ContainsKey(i))
                {
                    dic[count[i]].Remove(i);
                    count[i]++;
                    if (dic.ContainsKey(count[i]))
                    {
                        dic[count[i]].Add(i);
                    }
                    else
                    {
                        dic.Add(count[i], new List<int>() { i });
                    }
                }
                else
                {
                    count.Add(i, 1);
                    dic[1].Add(i);
                }
            }
            var res = new List<int>();
            foreach (var item in dic.OrderByDescending(d => d.Key))
            {
                res.AddRange(item.Value);
                if (res.Count >= k) break;
            }
            return res.Skip(res.Count - k).Take(k).ToArray();
        }

        /// <summary>
        /// [51] N 皇后
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public IList<IList<string>> SolveNQueens(int n)
        {
            List<char[]> board = new List<char[]>();
            for (int i = 0; i < n; i++)
            {
                board.Add((new string(' ', n)).ToCharArray());
            }
            List<IList<string>> res = SolveNQueens(n, board, 0);
            return res;
        }

        private List<IList<string>> SolveNQueens(int n, List<char[]> board, int num)
        {
            var res = new List<IList<string>>();
            if (num == n)
            {
                res.Add(board.Select(b => new string(b)).ToList());
                return res;
            }
            //Put new queen in the num-th line.
            for (int i = 0; i < n; i++)
            {
                if (board[num][i] == '.') continue;
                var pos = SolveNQueens(num, i, n);
                var valid = true;
                foreach (var item in pos)
                {
                    if (board[item[0]][item[1]] == 'Q')
                    {
                        valid = false;
                        break;
                    }
                }
                if (valid)
                {
                    var newBoard = board.Select(b => new string(b).ToCharArray()).ToList();
                    pos.ForEach(p => newBoard[p[0]][p[1]] = '.');
                    newBoard[num][i] = 'Q';
                    res.AddRange(SolveNQueens(n, newBoard, num + 1));
                }
            }
            return res;
        }

        private List<int[]> SolveNQueens(int x, int y, int n)
        {
            int[,] Moves = new[,] { { 1, 1 }, { 1, -1 }, { -1, 1 }, { -1, -1 }, { 1, 0 }, { -1, 0 }, { 0, 1 }, { 0, -1 } };
            var positions = new List<int[]>();
            for (var i = 0; i <= Moves.GetUpperBound(0); i++)
            {
                var index = 1;
                var newX = x + Moves[i, 0] * index;
                var newY = y + Moves[i, 1] * index;
                while (newX < n && newX >= 0 && newY < n && newY >= 0)
                {
                    positions.Add(new int[] { newX, newY });
                    index++;
                    newX = x + Moves[i, 0] * index;
                    newY = y + Moves[i, 1] * index;
                }
            }
            return positions;
        }

        /// <summary>
        /// [2221] 数组的三角和
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int TriangularSum(int[] nums)
        {
            for (int i = nums.Length - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    nums[j] = (nums[j] + nums[j + 1]) % 10;
                }
            }
            return nums[0];
        }

        /// <summary>
        /// [41] 缺失的第一个正数
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FirstMissingPositive(int[] nums)
        {
            int n = nums.Length;
            int min = n;
            for (int i = 0; i < n; i++)
            {
                if (nums[i] > n || nums[i] <= 0)
                {
                    nums[i] = n + 1;
                    continue;
                }
                min = Math.Min(min, nums[i]);
            }
            if (min > 1)
            {
                return 1;
            }
            for (int i = 0; i < n; i++)
            {
                int t = Math.Abs(nums[i]);
                if (t > n)
                {
                    continue;
                }
                if (nums[t - 1] > 0)
                {
                    nums[t - 1] = -nums[t - 1];
                }
            }
            for (int i = 0; i < n; i++)
            {
                if (nums[i] > 0)
                {
                    return i + 1;
                }
            }
            return n + 1;
        }

        /// <summary>
        /// [153] 寻找旋转排序数组中的最小值
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindMin(int[] nums)
        {
            if (nums.Length == 1) return nums[0];
            if (nums.Length == 2) return Math.Min(nums[0], nums[1]);
            int left = 0, right = nums.Length - 1;
            int mid = (left + right) / 2;
            if (nums[left] < nums[right]) return nums[left];
            while (left < right)
            {
                if (nums[mid] < nums[mid - 1])
                {
                    break;
                }
                else if (nums[mid] > nums[left])
                {
                    left = mid;
                }
                else if (nums[mid] < nums[right])
                {
                    right = mid;
                }
                else if (nums[left] < nums[left + 1])
                {
                    left++;
                }
                else if (nums[right] > nums[right - 1])
                {
                    right--;
                }
                else if (right == left + 1)
                {
                    mid = nums[left] < nums[right] ? left : right;
                    break;
                }
                else if (right == left)
                {
                    mid = left;
                    break;
                }
                mid = (left + right) / 2;
            }
            return nums[mid];
        }

        /// <summary>
        /// [240] 搜索二维矩阵 II
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool SearchMatrix(int[][] matrix, int target)
        {
            int m = matrix.Length;
            int n = matrix[0].Length;
            if (target < matrix[0][0] || target > matrix[m - 1][n - 1]) return false;
            for (int i = 0; i < m; i++)
            {
                if (target < matrix[i][0] || target > matrix[i][n - 1]) continue;
                int l = 0;
                int r = n - 1;
                while (l <= r)
                {
                    int mid = (l + r) / 2;
                    if (matrix[i][mid] == target) return true;
                    if (matrix[i][mid] < target) l = mid + 1; //说明target不在左边
                    else r = mid - 1; //说明target不在右边边
                }
            }
            return false;
        }

        /// <summary>
        /// [3100] 换水问题 II
        /// </summary>
        /// <param name="numBottles"></param>
        /// <param name="numExchange"></param>
        /// <returns></returns>
        public int MaxBottlesDrunk(int numBottles, int numExchange)
        {
            int res = numBottles;
            while (numBottles >= numExchange)
            {
                numBottles = numBottles - numExchange + 1;
                numExchange++;
                res++;
            }
            return res;
        }

        /// <summary>
        /// [407] 接雨水 II
        /// </summary>
        /// <param name="heightMap"></param>
        /// <returns></returns>
        public int TrapRainWater(int[][] heightMap)
        {
            int m = heightMap.Length;
            int n = heightMap[0].Length;
            int[] dirs = { -1, 0, 1, 0, -1 };
            int maxHeight = 0;

            for (int i = 0; i < m; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    maxHeight = Math.Max(maxHeight, heightMap[i][j]);
                }
            }
            int[,] water = new int[m, n];
            for (int i = 0; i < m; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    water[i, j] = maxHeight;
                }
            }

            Queue<int[]> qu = new Queue<int[]>();
            for (int i = 0; i < m; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    if (i == 0 || i == m - 1 || j == 0 || j == n - 1)
                    {
                        if (water[i, j] > heightMap[i][j])
                        {
                            water[i, j] = heightMap[i][j];
                            qu.Enqueue(new int[] { i, j });
                        }
                    }
                }
            }

            while (qu.Count > 0)
            {
                int[] curr = qu.Dequeue();
                int x = curr[0];
                int y = curr[1];
                for (int i = 0; i < 4; ++i)
                {
                    int nx = x + dirs[i], ny = y + dirs[i + 1];
                    if (nx < 0 || nx >= m || ny < 0 || ny >= n)
                    {
                        continue;
                    }
                    if (water[x, y] < water[nx, ny] && water[nx, ny] > heightMap[nx][ny])
                    {
                        water[nx, ny] = Math.Max(water[x, y], heightMap[nx][ny]);
                        qu.Enqueue(new int[] { nx, ny });
                    }
                }
            }

            int res = 0;
            for (int i = 0; i < m; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    res += water[i, j] - heightMap[i][j];
                }
            }
            return res;
        }

        /// <summary>
        /// [3346] 执行操作后元素的最高频率 I
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <param name="numOperations"></param>
        /// <returns></returns>
        public int MaxFrequency(int[] nums, int k, int numOperations)
        {
            Array.Sort(nums);
            int inNum = MaxFrequencyInNums(nums, k, numOperations);
            if (inNum >= numOperations)
            {
                return inNum;
            }
            int notInNum = MaxFrequencyNotInNums(nums, k, numOperations);
            return Math.Max(inNum, notInNum);
        }

        public int MaxFrequencyInNums(int[] nums, int k, int numOperations)
        {
            int maximumFrequency = 0;
            int n = nums.Length;
            int start = 0, end = 0;
            int targetIndex = 0;
            int targetFrequency = 0;
            while (targetIndex < n)
            {
                int target = nums[targetIndex];
                targetFrequency = 1;
                while (targetIndex + 1 < n && nums[targetIndex + 1] == target)
                {
                    targetIndex++;
                    targetFrequency++;
                }
                while (nums[start] < target - k)
                {
                    start++;
                }
                while (end + 1 < n && nums[end + 1] <= target + k)
                {
                    end++;
                }
                maximumFrequency = Math.Max(maximumFrequency, Math.Min(end - start + 1, targetFrequency + numOperations));
                targetIndex++;
            }
            return maximumFrequency;
        }

        public int MaxFrequencyNotInNums(int[] nums, int k, int numOperations)
        {
            int maximumFrequency = 0;
            int n = nums.Length;
            int start = 0, end = 0;
            while (end < n)
            {
                while (nums[end] - nums[start] > 2 * k)
                {
                    start++;
                }
                maximumFrequency = Math.Max(maximumFrequency, Math.Min(end - start + 1, numOperations));
                end++;
            }
            return maximumFrequency;
        }

        /// <summary>
        /// [3461] 判断操作后字符串中的数字是否相等 I
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool HasSameDigits(string s)
        {
            int index = s.Length;
            var chars = s.Select(c => c - '0').ToArray();
            while (index > 2)
            {
                int i = 0;
                while (i < index - 1)
                {
                    chars[i] = (chars[i] + chars[i + 1]) % 10;
                    i++;
                }
                index--;
            }
            return chars[0] == chars[1];
        }

        /// <summary>
        /// [2048] 下一个更大的数值平衡数
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        private static int[] balance = new int[]
        {
            1, 22, 122, 212, 221, 333, 1333, 3133, 3313, 3331, 4444,
            14444, 22333, 23233, 23323, 23332, 32233, 32323, 32332,
            33223, 33232, 33322, 41444, 44144, 44414, 44441, 55555,
            122333, 123233, 123323, 123332, 132233, 132323, 132332,
            133223, 133232, 133322, 155555, 212333, 213233, 213323,
            213332, 221333, 223133, 223313, 223331, 224444, 231233,
            231323, 231332, 232133, 232313, 232331, 233123, 233132,
            233213, 233231, 233312, 233321, 242444, 244244, 244424,
            244442, 312233, 312323, 312332, 313223, 313232, 313322,
            321233, 321323, 321332, 322133, 322313, 322331, 323123,
            323132, 323213, 323231, 323312, 323321, 331223, 331232,
            331322, 332123, 332132, 332213, 332231, 332312, 332321,
            333122, 333212, 333221, 422444, 424244, 424424, 424442,
            442244, 442424, 442442, 444224, 444242, 444422, 515555,
            551555, 555155, 555515, 555551, 666666, 1224444
        };

        public int NextBeautifulNumber(int n)
        {
            int i = Array.BinarySearch(balance, n + 1);
            if (i < 0)
            {
                i = -i - 1;
            }
            return balance[i];
        }

        /// <summary>
        /// [3217] 从链表中移除在数组中存在的节点
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode ModifiedList(int[] nums, ListNode head)
        {
            while (head != null && nums.Contains(head.val))
            {
                head = head.next;
            }
            if (head == null) return head;
            var node = head;
            while (node.next != null)
            {
                if (nums.Contains(node.next.val))
                {
                    node.next = node.next.next;
                }
                else
                {
                    node = node.next;
                }
            }

            return head;
        }

        /// <summary>
        /// [2257] 统计网格图中没有被保卫的格子数
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <param name="guards"></param>
        /// <param name="walls"></param>
        /// <returns></returns>
        public int CountUnguarded(int m, int n, int[][] guards, int[][] walls)
        {
            var guarded = new HashSet<int>();
            var wallSet = new HashSet<int>();
            foreach (var wall in walls)
            {
                guarded.Add(wall[0] * n + wall[1]);
                wallSet.Add(wall[0] * n + wall[1]);
            }
            foreach (var guard in guards)
            {
                guarded.Add(guard[0] * n + guard[1]);
                wallSet.Add(guard[0] * n + guard[1]);
            }
            foreach (var guard in guards)
            {
                int x = guard[0];
                int y = guard[1];
                //up
                for (int i = x - 1; i >= 0; i--)
                {
                    if (wallSet.Contains(i * n + y))
                    {
                        break;
                    }
                    else
                    {
                        guarded.Add(i * n + y);
                    }
                }
                //down
                for (int i = x + 1; i < m; i++)
                {
                    if (wallSet.Contains(i * n + y))
                    {
                        break;
                    }
                    else
                    {
                        guarded.Add(i * n + y);
                    }
                }
                //left
                for (int i = y - 1; i >= 0; i--)
                {
                    if (wallSet.Contains(x * n + i))
                    {
                        break;
                    }
                    else
                    {
                        guarded.Add(x * n + i);
                    }
                }
                //right
                for (int i = y + 1; i < n; i++)
                {
                    if (wallSet.Contains(x * n + i))
                    {
                        break;
                    }
                    else
                    {
                        guarded.Add(x * n + i);
                    }
                }
            }
            return m * n - guarded.Count;
        }

        /// <summary>
        /// [1578] 使绳子变成彩色的最短时间
        /// </summary>
        /// <param name="colors"></param>
        /// <param name="neededTime"></param>
        /// <returns></returns>
        public int MinCost(string colors, int[] neededTime)
        {
            if (neededTime.Length == 1) return 0;
            var index = 0;
            int res = 0;
            for (int i = 1; i < neededTime.Length; i++)
            {
                if (colors[index] == colors[i])
                {
                    //Move Min
                    if (neededTime[index] <= neededTime[i])
                    {
                        res += neededTime[index];
                        index = i;
                    }
                    else
                    {
                        res += neededTime[i];
                    }
                }
                else
                {
                    index = i;
                }
            }
            return res;
        }

        /// <summary>
        /// [3318] 计算子数组的 x-sum I
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public int[] FindXSum(int[] nums, int k, int x)
        {
            if (nums.Length == 1) return nums;
            var sd = new Dictionary<int, int>();
            var res = new int[nums.Length - k + 1];
            for (int i = 0; i < k; i++)
            {
                if (sd.ContainsKey(nums[i]))
                {
                    sd[nums[i]]++;
                }
                else
                {
                    sd.Add(nums[i], 1);
                }
            }
            res[0] = FindXSum(x, sd);
            for (int i = k; i < nums.Length; i++)
            {
                sd[nums[i - k]]--;
                if (sd.ContainsKey(nums[i]))
                {
                    sd[nums[i]]++;
                }
                else
                {
                    sd.Add(nums[i], 1);
                }
                res[i - k + 1] = FindXSum(x, sd);
            }
            return res;
        }

        public int FindXSum(int x, Dictionary<int, int> dic)
        {
            return dic.OrderByDescending(d => d.Value).ThenByDescending(d => d.Key).Take(x).Sum(d => d.Key * d.Value);
        }

        /// <summary>
        /// [3607] 电网维护
        /// </summary>
        /// <param name="c"></param>
        /// <param name="connections"></param>
        /// <param name="queries"></param>
        /// <returns></returns>
        public int[] ProcessQueries(int c, int[][] connections, int[][] queries)
        {
            var dic = new Dictionary<int, SortedSet<int>>();
            var off = new HashSet<int>();

            foreach (var conn in connections)
            {
                if (dic.ContainsKey(conn[0]))
                {
                    var set = dic[conn[0]];
                    if (!set.Contains(conn[1]))
                    {
                        set.Add(conn[1]);
                    }
                    if (!dic.ContainsKey(conn[1]))
                    {
                        dic.Add(conn[1], set);
                    }
                    else if (dic[conn[1]] != set)
                    {
                        foreach (var d in dic[conn[1]])
                        {
                            if (!set.Contains(d))
                            {
                                set.Add(d);
                            }
                            if (d != conn[1] && dic[d] != set)
                            {
                                dic[d] = set;
                            }
                        }
                        dic[conn[1]] = set;
                    }
                }
                else if (dic.ContainsKey(conn[1]))
                {
                    var set = dic[conn[1]];
                    if (!set.Contains(conn[0]))
                    {
                        set.Add(conn[0]);
                    }
                    if (!dic.ContainsKey(conn[0]))
                    {
                        dic.Add(conn[0], set);
                    }
                    else if (dic[conn[0]] != set)
                    {
                        foreach (var d in dic[conn[0]])
                        {
                            if (!set.Contains(d))
                            {
                                set.Add(d);
                            }
                            if (d != conn[0] && dic[d] != set)
                            {
                                dic[d] = set;
                            }
                        }
                        dic[conn[0]] = set;
                    }
                }
                else
                {
                    var set = new SortedSet<int>
                    {
                        conn[0],
                        conn[1]
                    };
                    dic.Add(conn[0], set);
                    dic.Add(conn[1], set);
                }
            }

            for (int i = 1; i <= c; i++)
            {
                if (!dic.ContainsKey(i))
                {
                    dic.Add(i, new SortedSet<int>() { i });
                }
            }

            var res = new List<int>();
            foreach (var query in queries)
            {
                switch (query[0])
                {
                    case 1:
                        if (off.Contains(query[1]))
                        {
                            var online = dic[query[1]].FirstOrDefault(d => !off.Contains(d));
                            res.Add(online == 0 ? -1 : online);
                        }
                        else
                        {
                            res.Add(query[1]);
                        }
                        break;
                    case 2:
                        off.Add(query[1]);
                        break;
                    default:
                        break;
                }
            }

            return res.ToArray();
        }

        /// <summary>
        /// [2528] 最大化城市的最小电量
        /// </summary>
        /// <param name="stations"></param>
        /// <param name="r"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public long MaxPower(int[] stations, int r, int k)
        {
            int n = stations.Length;
            if (n == 1) return stations[0] + k;
            var powers = new List<long>();
            long key = 0;
            for (int i = 0; i <= r; i++)
            {
                key += stations[i];
            }
            powers.Add(key);
            for (int i = 1; i <= r; i++)
            {
                key += stations[i + r];
                powers.Add(key);
            }
            for (int i = r + 1; i < n; i++)
            {
                key -= stations[i - r - 1];
                if (i + r < n)
                {
                    key += stations[i + r];
                }
                powers.Add(key);
            }

            for (int i = 0; i < k; i++)
            {
                var min = powers.Min();
                powers.Remove(min);
                powers.Add(min + 1);
            }

            return powers.Min();
        }

        /// <summary>
        /// [2654] 使数组所有元素变成 1 的最少操作次数
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MinOperations(int[] nums)
        {
            if (nums.Contains(1))
            {
                return nums.Count(n => n > 1);
            }
            int min = nums.Length;
            for (int i = 0; i < nums.Length - 1; i++)
            {
                var gcd = 0;
                for (int j = i; j < nums.Length; j++)
                {
                    gcd = Common.GCD(gcd, nums[j]);
                    if (gcd == 1)
                    {
                        min = Math.Min(min, j - i);
                        break;
                    }
                }
                if (min == 1) break;
            }
            if (min == nums.Length) return -1;
            else return nums.Length + min - 1;
        }

        /// <summary>
        /// [3228] 将 1 移动到末尾的最大操作次数
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int MaxOperations(string s)
        {
            if (s.Length == 1) return 0;
            int count = 0;
            int moves = 0;
            int index = 0;
            while (index < s.Length)
            {
                int cnt = 0;
                while (index < s.Length && s[index] == '1')
                {
                    cnt++;
                    index++;
                }
                if (cnt > 0 && index != s.Length)
                {
                    count += cnt;
                    moves += count;
                }
                index++;
            }
            return moves;
        }

        /// <summary>
        /// [2536] 子矩阵元素加 1
        /// </summary>
        /// <param name="n"></param>
        /// <param name="queries"></param>
        /// <returns></returns>
        public int[][] RangeAddQueries(int n, int[][] queries)
        {
            int[][] res = new int[n][];
            for (int i = 0; i < n; i++)
            {
                res[i] = new int[n];
            }

            foreach (var query in queries)
            {
                for (int i = query[0]; i <= query[2]; i++)
                {
                    if (query[1] > 0)
                    {
                        res[i][query[1] - 1]--;
                    }
                    res[i][query[3]]++;
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = n - 2; j >= 0; j--)
                {
                    res[i][j] += res[i][j + 1];
                }
            }

            return res;
        }

        /// <summary>
        /// [1513] 仅含 1 的子串数
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int NumSub(string s)
        {
            long res = 0;
            long cnt = 0;
            foreach (char c in s)
            {
                if (c == '1')
                {
                    cnt++;
                }
                else if (cnt > 0)
                {
                    res = (res + (1 + cnt) * cnt / 2) % MOD;
                    cnt = 0;
                }
            }
            if (cnt > 0)
            {
                res = (res + (1 + cnt) * cnt / 2) % MOD;
                cnt = 0;
            }
            return (int)res;
        }

        /// <summary>
        /// [1437] 是否所有 1 都至少相隔 k 个元素
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public bool KLengthApart(int[] nums, int k)
        {
            int index = -1;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 1 && index == -1)
                {
                    index = 0;
                }
                else if (nums[i] == 1 && index < k)
                {
                    return false;
                }
                else if (nums[i] == 1)
                {
                    index = 0;
                }
                else if (index != -1)
                {
                    index++;
                }
            }
            return true;
        }

        /// <summary>
        /// [717] 1 比特与 2 比特字符
        /// </summary>
        /// <param name="bits"></param>
        /// <returns></returns>
        public bool IsOneBitCharacter(int[] bits)
        {
            if (bits.Length == 1) return true;
            var n = bits.Length;
            var index = 0;
            while (index < n)
            {
                if (bits[index] == 1)
                {
                    index += 2;
                    if (index >= n) return false;
                }
                else
                {
                    index += 1;
                    if (index == n) return true;
                }
            }
            return true;
        }

        /// <summary>
        /// [2154] 将找到的值乘以 2
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="original"></param>
        /// <returns></returns>
        public int FindFinalValue(int[] nums, int original)
        {
            var map = new HashSet<int>(nums);
            while (map.Contains(original))
            {
                original *= 2;
            }
            return original;
        }

        /// <summary>
        /// [757] 设置交集大小至少为2
        /// </summary>
        /// <param name="intervals"></param>
        /// <returns></returns>
        public int IntersectionSizeTwo(int[][] intervals)
        {
            int n = intervals.Length;
            int res = 0;
            int m = 2;
            Array.Sort(intervals, (a, b) =>
            {
                if (a[0] == b[0])
                {
                    return b[1] - a[1];
                }
                return a[0] - b[0];
            });
            IList<int>[] temp = new IList<int>[n];
            for (int i = 0; i < n; i++)
            {
                temp[i] = new List<int>();
            }
            for (int i = n - 1; i >= 0; i--)
            {
                for (int j = intervals[i][0], k = temp[i].Count; k < m; j++, k++)
                {
                    res++;
                    IntersectionSizeTwo(intervals, temp, i - 1, j);
                }
            }
            return res;
        }

        public void IntersectionSizeTwo(int[][] intervals, IList<int>[] temp, int pos, int num)
        {
            for (int i = pos; i >= 0; i--)
            {
                if (intervals[i][1] < num)
                {
                    break;
                }
                temp[i].Add(num);
            }
        }

        /// <summary>
        /// [1930] 长度为 3 的不同回文子序列
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int CountPalindromicSubsequence(string s)
        {
            var dic = new Dictionary<char, List<int>>();
            var res = new HashSet<string>();
            for (int i = 0; i < s.Length; i++)
            {
                if (dic.ContainsKey(s[i]))
                {
                    dic[s[i]].Add(i);
                }
                else
                {
                    dic.Add(s[i], new List<int>() { i });
                }
            }
            foreach (var v in dic.Values)
            {
                if (v.Count >= 2)
                {
                    var l = v[0];
                    var r = v[v.Count - 1];

                    for (int j = l + 1; j < r; j++)
                    {
                        res.Add(string.Concat(s[l], s[j], s[r]));
                    }
                }
            }
            return res.Count;
        }

        /// <summary>
        /// [3190] 使所有元素都可以被 3 整除的最少操作数
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MinimumOperations(int[] nums)
        {
            int res = 0;
            foreach (var n in nums)
            {
                if (n % 3 == 0) continue;
                else
                {
                    res++;
                }
            }
            return res;
        }

        /// <summary>
        /// [1262] 可被三整除的最大和
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaxSumDivThree(int[] nums)
        {
            int res = 0;
            int min1 = 0, min12 = 0, min2 = 0, min22 = 0;
            foreach (var num in nums)
            {
                res += num;
                if (num % 3 == 1)
                {
                    if (min1 == 0 || num <= min1)
                    {
                        min12 = min1;
                        min1 = num;
                    }
                    else if (min12 == 0 || num <= min12)
                    {
                        min12 = num;
                    }
                }
                else if (num % 3 == 2)
                {
                    if (min2 == 0 || num <= min2)
                    {
                        min22 = min2;
                        min2 = num;
                    }
                    else if (min22 == 0 || num <= min22)
                    {
                        min22 = num;
                    }
                }
            }
            if (res % 3 == 1)
            {
                if (min1 == 0)
                {
                    res = res - min2 - min22;
                }
                else if (min22 == 0)
                {
                    res = res - min1;
                }
                else
                {
                    res = Math.Max(res - min1, res - min2 - min22);
                }
            }
            else if (res % 3 == 2)
            {
                if (min2 == 0)
                {
                    res = res - min1 - min12;
                }
                else if (min12 == 0)
                {
                    res = res - min2;
                }
                else
                {
                    res = Math.Max(res - min2, res - min1 - min12);
                }
            }
            return res;
        }

        public IList<bool> PrefixesDivBy5(int[] nums)
        {
            int num = 0;
            var res = new List<bool>();
            foreach (int i in nums)
            {
                num = num * 2 + i;
                if (num % 5 == 0)
                {
                    res.Add(true);
                }
                else
                {
                    res.Add(false);
                }
                num = num % 10;
            }
            return res;
        }

        /// <summary>
        /// [1015] 可被 K 整除的最小整数
        /// </summary>
        /// <param name="k"></param>
        /// <returns></returns>
        public int SmallestRepunitDivByK(int k)
        {
            var set = new HashSet<int>();
            var n = 0;
            for (int i = 1; i <= k; i++)
            {
                n = (n * 10 + 1) % k;
                if (n == 0)
                {
                    return i;
                }
                else if (set.Contains(n))
                {
                    return -1;
                }
                else
                {
                    set.Add(n);
                }
            }
            return -1;
        }

        /// <summary>
        /// [3381] 长度可被 K 整除的子数组的最大元素和
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public long MaxSubarraySum(int[] nums, int k)
        {
            var n = nums.Length;
            var set = new long[k];
            long sum = 0;
            var res = long.MinValue;
            //initialize prefix sum array
            set[0] = 0;
            for (int i = 1; i < k; i++)
            {
                set[i] = 200000000000000;
            }
            for (int i = 0; i < n; i++)
            {
                sum += nums[i];
                res = Math.Max(res, sum - set[(i + 1) % k]);
                set[(i + 1) % k] = Math.Min(set[(i + 1) % k], sum);
            }
            return res;
        }

        /// <summary>
        /// [2872] 可以被 K 整除连通块的最大数目
        /// </summary>
        /// <param name="n"></param>
        /// <param name="edges"></param>
        /// <param name="values"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MaxKDivisibleComponents(int n, int[][] edges, int[] values, int k)
        {
            var nodes = new List<int>[n];
            for (int i = 0; i < n; ++i)
            {
                nodes[i] = new List<int>();
            }
            foreach (var edge in edges)
            {
                var l = edge[0];
                var r = edge[1];
                nodes[l].Add(r);
                nodes[r].Add(l);
            }
            var res = 0;
            MaxKDivisibleComponents(-1, 0, nodes, values, k, ref res);
            return res;
        }

        private long MaxKDivisibleComponents(int parent, int child, List<int>[] nodes, int[] values, int k, ref int res)
        {
            long sum = values[child];
            foreach (int neighbor in nodes[child])
            {
                if (neighbor != parent)
                {
                    sum += MaxKDivisibleComponents(child, neighbor, nodes, values, k, ref res);
                }
            }
            if (sum % k == 0)
            {
                res++;
                return 0;
            }
            return sum;
        }

        /// <summary>
        /// [3512] 使数组和能被 K 整除的最少操作次数
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MinOperations(int[] nums, int k)
        {
            var res = 0;
            foreach (var n in nums)
            {
                res = (res + n) % k;
            }
            return res;
        }

        /// <summary>
        /// [1590] 使数组和能被 P 整除
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public int MinSubarray(int[] nums, int p)
        {
            int x = 0;
            foreach (int num in nums)
            {
                x = (x + num) % p;
            }
            if (x == 0)
            {
                return 0;
            }
            IDictionary<int, int> index = new Dictionary<int, int>();
            int y = 0, res = nums.Length;
            for (int i = 0; i < nums.Length; i++)
            {
                if (!index.ContainsKey(y))
                {
                    index.Add(y, i);
                }
                else
                {
                    index[y] = i;
                }
                y = (y + nums[i]) % p;
                if (index.ContainsKey((y - x + p) % p))
                {
                    res = Math.Min(res, i - index[(y - x + p) % p] + 1);
                }
            }
            return res == nums.Length ? -1 : res;
        }

        /// <summary>
        /// [2141] 同时运行 N 台电脑的最长时间
        /// </summary>
        /// <param name="n"></param>
        /// <param name="batteries"></param>
        /// <returns></returns>
        public long MaxRunTime(int n, int[] batteries)
        {
            if (batteries.Length == n)
            {
                return batteries.Min();
            }
            //可运行时间不超过平均时间
            long total = 0;
            foreach (int num in batteries)
            {
                total += num;
            }
            long l = 0;
            long r = total / n + 1;
            while (l + 1 < r)
            {
                //二分，假设能运行t分钟，b >= t的电池只能给一台电脑使用，b < t的电池可以组合使用
                long t = l + (r - l) / 2;
                long sum = 0;
                foreach (var b in batteries)
                {
                    sum += Math.Min(b, t);
                }
                if (n * t <= sum)
                {
                    //可以运行t分钟，下一轮查找范围[t,r)
                    l = t;
                }
                else
                {
                    //无法运行t分钟，下一轮查找范围[l,t)
                    r = t;
                }
            }
            return l;
        }

        /// <summary>
        /// [3623] 统计梯形的数目 I
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public int CountTrapezoids(int[][] points)
        {
            //key：纵坐标；value：线段数量
            var dic = new Dictionary<int, long>();
            foreach (var point in points)
            {
                int y = point[1];
                if (dic.ContainsKey(y))
                {
                    dic[y]++;
                }
                else
                {
                    dic.Add(y, 1);
                }
            }
            long res = 0;
            long side = 0;
            foreach (var point in dic.Values)
            {
                long edge = point * (point - 1) / 2;
                res = (res + edge * side) % MOD;
                side = (side + edge) % MOD;
            }
            return (int)res;
        }

        /// <summary>
        /// [2211] 统计道路上的碰撞次数
        /// </summary>
        /// <param name="directions"></param>
        /// <returns></returns>
        public int CountCollisions(string directions)
        {
            ////L：Peek栈顶，如果有值，记录碰撞，L->S；如果没有值，忽略
            ////S：Peek栈顶，如果是S，忽略；如果是R，出栈R，记录碰撞，循环直到S或者没有值
            ////R：入栈
            //var stack = new Stack<char>();
            //var res = 0;
            //foreach(char c in directions)
            //{
            //    switch (c)
            //    {
            //        case 'L':
            //            res += CountCollisionsL(stack);
            //            break;
            //        case 'S':
            //            res += CountCollisionsS(stack);
            //            break;
            //        case 'R':
            //            CountCollisionsR(stack);
            //            break;
            //        default:
            //            continue;
            //    }
            //}
            //return res;
            //L：state < 0，忽略；state >= 0，更新res += state + 1，state = 0
            //S：state < 0，更新state = 0；state >= 0，更新res += state，state = 0
            //R：state <= 0，更新state = 1；state > 0，更新state += 1
            var state = -1;
            var res = 0;
            foreach (char c in directions)
            {
                switch (c)
                {
                    case 'L':
                        if (state >= 0)
                        {
                            res += state + 1;
                            state = 0;
                        }
                        break;
                    case 'S':
                        if (state < 0)
                        {
                            state = 0;
                        }
                        else
                        {
                            res += state;
                            state = 0;
                        }
                        break;
                    case 'R':
                        if (state <= 0)
                        {
                            state = 1;
                        }
                        else
                        {
                            state += 1;
                        }
                        break;
                    default:
                        continue;
                }
            }
            return res;
        }

        //private int CountCollisionsL(Stack<char> stack)
        //{
        //    //L：Peek栈顶，如果有值，记录碰撞，L->S；如果没有值，忽略
        //    if (stack.TryPeek(out var p))
        //    {
        //        if (p == 'S')
        //        {
        //            return 1;
        //        }
        //        else //R
        //        {
        //            stack.Pop();
        //            return 2 + CountCollisionsS(stack);
        //        }
        //    }
        //    else
        //    {
        //        return 0;
        //    }
        //}

        //private int CountCollisionsS(Stack<char> stack)
        //{
        //    //S：Peek栈顶，如果是S，忽略；如果是R，出栈R，记录碰撞，循环直到S或者没有值
        //    if (stack.TryPeek(out var p))
        //    {
        //        if (p == 'S')
        //        {
        //            return 0;
        //        }
        //        else //R
        //        {
        //            stack.Pop();
        //            return 1 + CountCollisionsS(stack);
        //        }
        //    }
        //    else
        //    {
        //        stack.Push('S');
        //        return 0;
        //    }
        //}

        //private void CountCollisionsR(Stack<char> stack)
        //{
        //    //R：入栈
        //    stack.Push('R');
        //}

        /// <summary>
        /// [179] 最大数
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public string LargestNumber(int[] nums)
        {
            Array.Sort(nums, new NumberConcatComparer());
            var res = string.Join("", nums).TrimStart('0');
            return string.IsNullOrEmpty(res) ? "0" : res;
        }

        /// <summary>
        /// [3432] 统计元素和差值为偶数的分区方案
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int CountPartitions(int[] nums)
        {
            var sum = 0;
            foreach (var i in nums)
            {
                sum += i;
            }
            if (sum % 2 != 0)
            {
                return 0;
            }
            var res = 0;
            var left = 0;
            for (int i = 0; i < nums.Length - 1; i++)
            {
                left += nums[i];
                sum -= nums[i];
                if ((left - sum) % 2 == 0)
                {
                    res++;
                }
            }
            return res;
        }

        /// <summary>
        /// [1523] 在区间范围内统计奇数数目
        /// </summary>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <returns></returns>
        public int CountOdds(int low, int high)
        {
            var interval = high - low + 1;
            if (interval % 2 == 0)
            {
                return interval / 2;
            }
            else if (low % 2 == 0)
            {
                return interval / 2;
            }
            else
            {
                return interval / 2 + 1;
            }
        }

        /// <summary>
        /// [1925] 统计平方和三元组的数目
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int CountTriples(int n)
        {
            //a^2 + b^2 = c^2
            //1 <= a, b, c <= n
            //a, b <= sqrt(n^2 / 2)
            var maxa = Math.Floor(Math.Sqrt(n * n / 2));
            var res = 0;
            for (int a = 3; a <= maxa; a++)
            {
                var maxb = Math.Floor(Math.Sqrt(n * n - a * a));
                for (int b = a + 1; b <= maxb; b++)
                {
                    var sum = Math.Sqrt(a * a + b * b);
                    if (sum.Equals(Math.Floor(sum)))
                    {
                        res += 2;
                    }
                }
            }
            return res;
        }

        /// <summary>
        /// [3583] 统计特殊三元组
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int SpecialTriplets(int[] nums)
        {
            //记录每个值的出现次数
            var dic = new Dictionary<int, int>();
            //记录i左边有多少符合条件nums[i]*2的值
            var count = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (dic.ContainsKey(nums[i]))
                {
                    dic[nums[i]]++;
                }
                else
                {
                    dic.Add(nums[i], 1);
                }
                if (nums[i] != 0 && dic.ContainsKey(nums[i] * 2))
                {
                    count.Add(i, dic[nums[i] * 2]);
                }
            }
            int res = 0;
            foreach (var item in count)
            {
                var i = item.Key;
                var value = item.Value;
                if (i != 0)
                {
                    var right = dic[nums[i] * 2] - value;
                    res = (value * right + res) % MOD;
                }
            }
            //处理0
            if (dic.ContainsKey(0) && dic[0] >= 3)
            {
                long zero = (long)dic[0] * (dic[0] - 1) * (dic[0] - 2) / 6 % MOD;
                res = (res + (int)zero) % MOD;
            }
            return res;
        }

        /// <summary>
        /// [3577] 统计计算机解锁顺序排列数
        /// </summary>
        /// <param name="complexity"></param>
        /// <returns></returns>
        public int CountPermutations(int[] complexity)
        {
            //complexity[0]必须是唯一最小值
            if (complexity.Count(c => c <= complexity[0]) > 1)
            {
                return 0;
            }
            long res = 1;
            for (int i = 1; i < complexity.Length; i++)
            {
                res = res * i % MOD;
            }
            return (int)res;
        }

        /// <summary>
        /// [3531] 统计被覆盖的建筑
        /// </summary>
        /// <param name="n"></param>
        /// <param name="buildings"></param>
        /// <returns></returns>
        public int CountCoveredBuildings(int n, int[][] buildings)
        {
            //Key：横坐标；Value：纵坐标范围
            var ver = new Dictionary<int, int[]>();
            //Key：纵坐标；Value：横坐标范围
            var hor = new Dictionary<int, int[]>();
            foreach (var building in buildings)
            {
                var x = building[0];
                var y = building[1];
                if (ver.ContainsKey(x))
                {
                    ver[x][0] = Math.Min(ver[x][0], y);
                    ver[x][1] = Math.Max(ver[x][1], y);
                }
                else
                {
                    ver.Add(x, [y, y]);
                }
                if (hor.ContainsKey(y))
                {
                    hor[y][0] = Math.Min(hor[y][0], x);
                    hor[y][1] = Math.Max(hor[y][1], x);
                }
                else
                {
                    hor.Add(y, [x, x]);
                }
            }
            int res = 0;
            foreach (var building in buildings)
            {
                var x = building[0];
                var y = building[1];
                if (ver[x][0] < y && ver[x][1] > y && hor[y][0] < x && hor[y][1] > x)
                {
                    res++;
                }
            }
            return res;
        }

        /// <summary>
        /// [3433] 统计用户被提及情况
        /// </summary>
        /// <param name="numberOfUsers"></param>
        /// <param name="events"></param>
        /// <returns></returns>
        public int[] CountMentions(int numberOfUsers, IList<IList<string>> events)
        {
            //Value: Event, Ids; Priority: timestamp
            var pq = new PriorityQueue<Tuple<int, string>, int>();
            var all = 0;
            foreach (var ev in events)
            {
                var e = ev[0] == "MESSAGE" ? 0 : 1;
                var t = int.Parse(ev[1]) * 3;
                var ids = ev[2].Replace("id", "");
                if (ids == "ALL")
                {
                    all++;
                    continue;
                }
                pq.Enqueue(new Tuple<int, string>(e, ids), t - e);
                if (e == 1)
                {
                    //Add online event
                    pq.Enqueue(new Tuple<int, string>(2, ids), t + 178);
                }
            }
            var status = new int[numberOfUsers];
            var res = new int[numberOfUsers];
            if (all > 0)
            {
                for (int i = 0; i < numberOfUsers; i++)
                {
                    res[i] = all;
                }
            }
            while (pq.TryDequeue(out var ev, out _))
            {
                var e = ev.Item1;
                if (e == 0)
                {
                    //MESSAGE
                    if (ev.Item2 == "HERE")
                    {
                        for (int i = 0; i < numberOfUsers; i++)
                        {
                            if (status[i] == 0)
                            {
                                res[i]++;
                            }
                        }
                    }
                    else
                    {
                        var ids = ev.Item2.Split(' ').Select(int.Parse);
                        foreach (var id in ids)
                        {
                            res[id]++;
                        }
                    }
                }
                else if (e == 1)
                {
                    //OFFLINE
                    var id = int.Parse(ev.Item2);
                    status[id] = -1;
                }
                else
                {
                    //ONLINE
                    var id = int.Parse(ev.Item2);
                    status[id] = 0;
                }
            }
            return res;
        }

        /// <summary>
        /// [3606] 优惠券校验器
        /// </summary>
        /// <param name="code"></param>
        /// <param name="businessLine"></param>
        /// <param name="isActive"></param>
        /// <returns></returns>
        public IList<string> ValidateCoupons(string[] code, string[] businessLine, bool[] isActive)
        {
            var res = new Dictionary<string, List<string>>
            {
                { "electronics", new List<string>() },
                { "grocery", new List<string>() },
                { "pharmacy", new List<string>() },
                { "restaurant", new List<string>() }
            };
            var n = code.Length;
            for (int i = 0; i < n; i++)
            {
                if (!isActive[i])
                {
                    continue;
                }
                if (!res.ContainsKey(businessLine[i]))
                {
                    continue;
                }
                if (!Regex.IsMatch(code[i], "^[a-zA-Z0-9_]+$"))
                {
                    continue;
                }
                res[businessLine[i]].Add(code[i]);
            }
            var ans = new List<string>();
            foreach (var r in res.Values)
            {
                r.Sort(StringComparer.Ordinal);
                ans.AddRange(r);
            }
            return ans;
        }

        /// <summary>
        /// [2147] 分隔长廊的方案数
        /// </summary>
        /// <param name="corridor"></param>
        /// <returns></returns>
        public int NumberOfWays(string corridor)
        {
            var list = new List<int>();
            for (int i = 0; i < corridor.Length; i++)
            {
                if (corridor[i] == 'S')
                {
                    list.Add(i);
                }
            }
            if (list.Count == 0 || list.Count % 2 == 1)
            {
                return 0;
            }
            int index = 0;
            long res = 1;
            for (int i = 1; i < list.Count - 1; i++)
            {
                if (index == 0)
                {
                    index = list[i];
                }
                else
                {
                    res = res * (list[i] - index) % MOD;
                    index = 0;
                }
            }
            return (int)res;
        }

        /// <summary>
        /// [2110] 股票平滑下跌阶段的数目
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public long GetDescentPeriods(int[] prices)
        {
            long res = 0;
            int last = 0;
            long current = 0;
            foreach (var price in prices)
            {
                if (current == 0)
                {
                    current++;
                    last = price;
                }
                else if (price == last - 1)
                {
                    current++;
                    last = price;
                }
                else
                {
                    res += current * (current + 1) / 2;
                    current = 1;
                    last = price;
                }
            }
            res += current * (current + 1) / 2;
            return res;
        }

        /// <summary>
        /// [3652] 按策略买卖股票的最佳时机
        /// </summary>
        /// <param name="prices"></param>
        /// <param name="strategy"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public long MaxProfit(int[] prices, int[] strategy, int k)
        {
            long res = 0;
            var n = prices.Length;
            for (int i = 0; i < n; i++)
            {
                res += prices[i] * strategy[i];
            }

            var t = k / 2;
            long max = res;
            for (int i = 0; i < t; i++)
            {
                res -= prices[i] * strategy[i];
            }
            for (int i = t; i < k; i++)
            {
                res += prices[i] * (1 - strategy[i]);
            }
            max = Math.Max(max, res);
            for (int i = 0; i < n - k; i++)
            {
                res += prices[i] * strategy[i];
                res -= prices[i + t];
                res += prices[i + k] * (1 - strategy[i + k]);
                max = Math.Max(max, res);
            }
            return max;
        }

        /// <summary>
        /// [2092] 找出知晓秘密的所有专家
        /// </summary>
        /// <param name="n"></param>
        /// <param name="meetings"></param>
        /// <param name="firstPerson"></param>
        /// <returns></returns>
        public IList<int> FindAllPeople(int n, int[][] meetings, int firstPerson)
        {
            int m = meetings.Length;
            Array.Sort(meetings, (x, y) => x[2].CompareTo(y[2]));
            bool[] secret = new bool[n];
            secret[0] = true;
            secret[firstPerson] = true;
            HashSet<int> vertices = new HashSet<int>();
            Dictionary<int, List<int>> edges = new Dictionary<int, List<int>>();

            for (int i = 0; i < m;)
            {
                // meetings[i .. j] 为同一时间
                int j = i;
                while (j + 1 < m && meetings[j + 1][2] == meetings[i][2])
                {
                    ++j;
                }

                vertices.Clear();
                edges.Clear();
                for (int k = i; k <= j; ++k)
                {
                    int x = meetings[k][0], y = meetings[k][1];
                    vertices.Add(x);
                    vertices.Add(y);
                    if (!edges.ContainsKey(x))
                    {
                        edges[x] = new List<int>();
                    }
                    if (!edges.ContainsKey(y))
                    {
                        edges[y] = new List<int>();
                    }
                    edges[x].Add(y);
                    edges[y].Add(x);
                }

                Queue<int> q = new Queue<int>();
                foreach (int u in vertices)
                {
                    if (secret[u])
                    {
                        q.Enqueue(u);
                    }
                }
                while (q.Count > 0)
                {
                    int u = q.Dequeue();
                    if (edges.ContainsKey(u))
                    {
                        foreach (int v in edges[u])
                        {
                            if (!secret[v])
                            {
                                secret[v] = true;
                                q.Enqueue(v);
                            }
                        }
                    }
                }

                i = j + 1;
            }

            List<int> ans = new List<int>();
            for (int i = 0; i < n; ++i)
            {
                if (secret[i])
                {
                    ans.Add(i);
                }
            }
            return ans;
        }

        /// <summary>
        /// [944] 删列造序
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public int MinDeletionSize(string[] strs)
        {
            var n = strs[0].Length;
            var res = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 1; j < strs.Length; j++)
                {
                    if (strs[j][i] < strs[j - 1][i])
                    {
                        res++;
                        break;
                    }
                }
            }
            return res;
        }

        /// <summary>
        /// [955] 删列造序 II
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public int MinDeletionSize2(string[] strs)
        {
            int n = strs.Length;
            int m = strs[0].Length;
            var cuts = new bool[n - 1];

            int ans = 0;
            for (int j = 0; j < m; j++)
            {
                var check = true;
                for (int i = 0; i < n - 1; i++)
                {
                    if (!cuts[i] && strs[i][j] > strs[i + 1][j])
                    {
                        ans++;
                        check = false;
                        break;
                    }
                }
                if (check)
                {
                    for (int i = 0; i < n - 1; i++)
                    {
                        if (strs[i][j] < strs[i + 1][j])
                        {
                            cuts[i] = true;
                        }
                    }
                }
            }

            return ans;
        }

        /// <summary>
        /// [2054] 两个最好的不重叠活动
        /// </summary>
        /// <param name="events"></param>
        /// <returns></returns>
        public int MaxTwoEvents(int[][] events)
        {
            List<Event> evs = new List<Event>();
            foreach (var eventArr in events)
            {
                evs.Add(new Event(eventArr[0], 0, eventArr[2]));
                evs.Add(new Event(eventArr[1], 1, eventArr[2]));
            }
            evs.Sort();

            int ans = 0, bestFirst = 0;
            foreach (var ev in evs)
            {
                if (ev.Op == 0)
                {
                    ans = Math.Max(ans, ev.Val + bestFirst);
                }
                else
                {
                    bestFirst = Math.Max(bestFirst, ev.Val);
                }
            }
            return ans;
        }

        /// <summary>
        /// [3074] 重新分装苹果
        /// </summary>
        /// <param name="apple"></param>
        /// <param name="capacity"></param>
        /// <returns></returns>
        public int MinimumBoxes(int[] apple, int[] capacity)
        {
            var apples = apple.Sum();
            Array.Sort(capacity, new DescendingComparer());
            var res = 0;
            foreach (var cap in capacity)
            {
                apples -= cap;
                res++;
                if (apples <= 0)
                {
                    break;
                }
            }
            return res;
        }

        /// <summary>
        /// [3075] 幸福值最大化的选择方案
        /// </summary>
        /// <param name="happiness"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public long MaximumHappinessSum(int[] happiness, int k)
        {
            Array.Sort(happiness, new DescendingComparer());
            long res = 0;
            for (int i = 0; i < k; i++)
            {
                res += Math.Max(0, happiness[i] - i);
            }
            return res;
        }

        /// <summary>
        /// [2483] 商店的最少代价
        /// </summary>
        /// <param name="customers"></param>
        /// <returns></returns>
        public int BestClosingTime(string customers)
        {
            var cost = 0;
            foreach(var customer in customers)
            {
                if(customer == 'Y')
                {
                    cost++;
                }
            }
            var min = cost;
            var res = 0;
            for (int i = 0; i < customers.Length; i++)
            {
                if (customers[i] == 'Y')
                {
                    cost--;
                }
                else
                {
                    cost++;
                }
                if(cost < min)
                {
                    min = cost;
                    res = i + 1;
                }
            }
            return res;
        }

        /// <summary>
        /// [2402] 会议室 III
        /// </summary>
        /// <param name="n"></param>
        /// <param name="meetings"></param>
        /// <returns></returns>
        public int MostBooked(int n, int[][] meetings)
        {
            var res = new int[n];
            var free = new SortedSet<int>();
            var busy = new PriorityQueue<(long endTime, int roomIndex), long>();
            for (var i = 0; i < n; i++)
            {
                free.Add(i);
            }
            Array.Sort(meetings, (a, b) => a[0].CompareTo(b[0]));
            long curTime = 0;
            long minEndTime = 0;
            foreach (var meeting in meetings)
            {
                var start = meeting[0];
                var end = meeting[1];
                curTime = Math.Max(curTime, start);
                if (free.Count == 0)
                {
                    //没有空闲会议室，推进到下一个会议室空闲时间
                    minEndTime = busy.Count == 0 ? 0 : busy.Peek().endTime;
                    curTime = Math.Max(curTime, minEndTime);
                }
                //释放已结束的会议室
                RemoveUntilNext(curTime);
                //分配会议室
                var roomIndex = free.Min;
                free.Remove(roomIndex);
                res[roomIndex]++;
                var duration = end - start;
                busy.Enqueue((curTime + duration, roomIndex), curTime + duration);
            }
            int ans = 0;
            for (int i = 1; i < n; i++)
            {
                if (res[i] > res[ans])
                {
                    ans = i;
                }
            }
            return ans;

            void RemoveUntilNext(long time)
            {
                while (busy.Count > 0 && busy.Peek().endTime <= time)
                {
                    free.Add(busy.Dequeue().roomIndex);
                }
            }
        }

        /// <summary>
        /// [1351] 统计有序矩阵中的负数
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int CountNegatives(int[][] grid)
        {
            var m = grid.Length;
            var n = grid[0].Length;
            var ans = 0;
            var j = 0;
            for (int i = m - 1; i >= 0; i--)
            {
                while (j < n)
                {
                    if (grid[i][j] < 0)
                    {
                        ans += n - j;
                        break;
                    }
                    j++;
                }
            }
            return ans;
        }

        /// <summary>
        /// [756] 金字塔转换矩阵
        /// </summary>
        /// <param name="bottom"></param>
        /// <param name="allowed"></param>
        /// <returns></returns>
        public bool PyramidTransition(string bottom, IList<string> allowed)
        {
            var dic = new Dictionary<string, List<char>>();
            foreach (var a in allowed)
            {
                var key = a.Substring(0, 2);
                var value = a[2];
                if (!dic.ContainsKey(key))
                {
                    dic.Add(key, new List<char>());
                }
                dic[key].Add(value);
            }
            return CanBuild(bottom);

            bool CanBuild(string layer)
            {
                if (layer.Length == 1)
                {
                    return true;
                }
                var nextLayers = new List<string>();
                BuildNextLayer(layer, 0, new StringBuilder(), nextLayers);
                foreach (var nextLayer in nextLayers)
                {
                    if (CanBuild(nextLayer))
                    {
                        return true;
                    }
                }
                return false;
            }

            void BuildNextLayer(string layer, int index, StringBuilder sb, List<string> nextLayers)
            {
                if (index == layer.Length - 1)
                {
                    nextLayers.Add(sb.ToString());
                    return;
                }
                var key = layer.Substring(index, 2);
                if (dic.ContainsKey(key))
                {
                    foreach (var c in dic[key])
                    {
                        sb.Append(c);
                        BuildNextLayer(layer, index + 1, sb, nextLayers);
                        sb.Length--;
                    }
                }
            }
        }

        /// <summary>
        /// [840] 矩阵中的幻方
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int NumMagicSquaresInside(int[][] grid)
        {
            var n = grid.Length;
            var m = grid[0].Length;
            var res = 0;
            var target = 15;
            for (int i = 0; i <= n - 3; i++)
            {
                for (int j = 0; j <= m - 3; j++)
                {
                    if (IsMagicSquare(i, j))
                    {
                        res++;
                    }
                }
            }
            return res;

            bool IsMagicSquare(int x, int y)
            {
                var seen = new HashSet<int>();
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        var val = grid[x + i][y + j];
                        if (val < 1 || val > 9 || seen.Contains(val))
                        {
                            return false;
                        }
                        seen.Add(val);
                    }
                }
                for (int i = 0; i < 3; i++)
                {
                    var rowSum = 0;
                    var colSum = 0;
                    for (int j = 0; j < 3; j++)
                    {
                        rowSum += grid[x + i][y + j];
                        colSum += grid[x + j][y + i];
                    }
                    if (rowSum != target || colSum != target)
                    {
                        return false;
                    }
                }
                var diag1 = grid[x][y] + grid[x + 1][y + 1] + grid[x + 2][y + 2];
                var diag2 = grid[x][y + 2] + grid[x + 1][y + 1] + grid[x + 2][y];
                if (diag1 != target || diag2 != target)
                {
                    return false;
                }
                return true;
            }
        }

        /// <summary>
        /// [66] 加一
        /// </summary>
        /// <param name="digits"></param>
        /// <returns></returns>
        public int[] PlusOne(int[] digits)
        {
            if (digits.Length == 1 && digits[0] == 0)
            {
                digits[0] = 1;
                return digits;
            }
            int t = 1;
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                digits[i] += t;
                t = 0;
                if (digits[i] == 10)
                {
                    digits[i] = 0;
                    t = 1;
                }
            }
            if (t == 1)
            {
                int[] a = new int[digits.Length + 1];
                a[0] = 1;
                for (int i = 0; i < digits.Length; i++)
                {
                    a[i + 1] = digits[i];
                }
                return a;
            }
            else
            {
                return digits;
            }
        }

        /// <summary>
        /// [961] 在长度 2N 的数组中找出重复 N 次的元素
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int RepeatedNTimes(int[] nums)
        {
            var res = 0;
            var set = new HashSet<int>();
            foreach (var n in nums)
            {
                if (set.Contains(n))
                {
                    res = n;
                    break;
                }
                set.Add(n);
            }
            return res;
        }

        /// <summary>
        /// [1390] 四因数
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int SumFourDivisors(int[] nums)
        {
            var res = 0;
            foreach (var n in nums)
            {
                var di = Common.AllDivisors(n);
                if(di.Length == 4)
                {
                    res += di.Sum();
                }
            }
            return res;
        }

        /// <summary>
        /// [1975] 最大方阵和
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public long MaxMatrixSum(int[][] matrix)
        {
            var n = matrix.Length;
            long sumPos = 0;
            long sumNeg = 0;
            int maxNeg = int.MinValue;
            int minPos = int.MaxValue;
            int countPos = 0;
            int countNeg = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    var k = matrix[i][j];
                    if (k >= 0)
                    {
                        countPos++;
                        sumPos += k;
                        minPos = Math.Min(minPos, k);
                    }
                    else
                    {
                        countNeg++;
                        sumNeg -= k;
                        maxNeg = Math.Max(maxNeg, k);
                    }
                }
            }
            if (countNeg % 2 == 0)
            {
                return sumPos + sumNeg;
            }
            else if(countPos == 0)
            {
                return sumPos + sumNeg + 2 * maxNeg;
            }
            else
            {
                return Math.Max(sumPos + sumNeg + 2 * maxNeg, sumPos + sumNeg - 2 * minPos);
            }
        }

        /// <summary>
        /// [1161] 最大层内元素和
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int MaxLevelSum(TreeNode root)
        {
            var max = 0;
            var sum = new List<int>();
            Dfs(root, 0);
            for(int i = 0; i < sum.Count; i++)
            {
                if (sum[i] > sum[max])
                {
                    max = i;
                }
            }
            return max + 1;

            void Dfs(TreeNode root, int level)
            {
                if(root != null)
                {
                    if(sum.Count > level)
                    {
                        sum[level] += root.val;
                    }
                    else
                    {
                        sum.Add(root.val);
                    }
                    Dfs(root.left, level + 1);
                    Dfs(root.right, level + 1);
                }
            }
        }

        /// <summary>
        /// [1339] 分裂二叉树的最大乘积
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int MaxProduct(TreeNode root)
        {
            var sums = new HashSet<int>();
            var total = Dfs(root);
            var mi = total;
            long res = 0;
            foreach (var item in sums)
            {
                if(Math.Abs(total - item - item) < mi)
                {
                    res = item;
                    mi = Math.Abs(total - item - item);
                }
            }
            return (int)(res * (total - res) % MOD);

            int Dfs(TreeNode node)
            {
                var left = 0;
                var right = 0;
                if (node.left != null)
                {
                    left = Dfs(node.left);
                    sums.Add(left);
                }
                if (node.right != null)
                {
                    right = Dfs(node.right);
                    sums.Add(right);
                }
                return node.val + left + right;
            }
        }

        /// <summary>
        /// [865] 具有所有最深节点的最小子树
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public TreeNode SubtreeWithAllDeepest(TreeNode root)
        {
            var node = Dfs(root, 0);
            return node.Item1;

            (TreeNode, int) Dfs(TreeNode node, int depth)
            {
                if(node == null)
                {
                    return (null, depth);
                }
                var left = Dfs(node.left, depth + 1);
                var right = Dfs(node.right, depth + 1);
                if(left.Item1 != null && right.Item1 != null)
                {
                    if(left.Item2 > right.Item2)
                    {
                        return left;
                    }
                    else if(left.Item2 < right.Item2)
                    {
                        return right;
                    }
                    else
                    {
                        return (node, left.Item2);
                    }
                }
                else if(left.Item1 != null)
                {
                    return left;
                }
                else if (right.Item1 != null)
                {
                    return right;
                }
                else
                {
                    return (node, depth);
                }
            }
        }

        /// <summary>
        /// [85] 最大矩形
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public int MaximalRectangle(char[][] matrix)
        {
            var rows = matrix.Length;
            var cols = matrix[0].Length;
            var maxRow = new int[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                maxRow[i, 0] = matrix[i][0] - '0';
                for (int j = 1; j < cols; j++)
                {
                    maxRow[i, j] = matrix[i][j] == '0' ? 0 : maxRow[i, j - 1] + 1;
                }
            }

            var res = 0;
            for (int j = 0; j < cols; j++)
            {
                int[] up = new int[rows];
                int[] down = new int[rows];
                Stack<int> stk = new Stack<int>();

                for (int i = 0; i < rows; i++)
                {
                    while (stk.Count > 0 && maxRow[stk.Peek(), j] >= maxRow[i, j])
                        stk.Pop();
                    up[i] = stk.Count == 0 ? -1 : stk.Peek();
                    stk.Push(i);
                }

                stk.Clear();
                for (int i = rows - 1; i >= 0; i--)
                {
                    while (stk.Count > 0 && maxRow[stk.Peek(), j] >= maxRow[i, j])
                        stk.Pop();
                    down[i] = stk.Count == 0 ? rows : stk.Peek();
                    stk.Push(i);
                }

                for (int i = 0; i < rows; i++)
                {
                    int height = down[i] - up[i] - 1;
                    res = Math.Max(res, height * maxRow[i, j]);
                }
            }
            return res;
        }

        /// <summary>
        /// [1266] 访问所有点的最小时间
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public int MinTimeToVisitAllPoints(int[][] points)
        {
            var n = points.Length;
            if (n == 1) return 0;
            var res = 0;
            var x1 = points[0][0];
            var y1 = points[0][1];
            for(int i = 1; i < n; i++)
            {
                var x = points[i][0];
                var y = points[i][1];
                res += Math.Max(Math.Abs(x - x1), Math.Abs(y - y1));
                x1 = x;
                y1 = y;
            }
            return res;
        }

        /// <summary>
        /// [3453] 分割正方形 I
        /// </summary>
        /// <param name="squares"></param>
        /// <returns></returns>
        public double SeparateSquares1(int[][] squares)
        {
            long totalArea = 0;
            List<int[]> events = new List<int[]>();

            foreach (var sq in squares)
            {
                int y = sq[1], l = sq[2];
                totalArea += (long)l * l;
                events.Add([y, l, 1]);
                events.Add([y + l, l, -1]);
            }

            // 按y坐标排序
            events.Sort((a, b) => a[0].CompareTo(b[0]));

            double coveredWidth = 0;  // 当前扫描线下所有底边之和
            double currArea = 0;      // 当前累计面积
            double prevHeight = 0;    // 前一个扫描线的高度

            foreach (var eventItem in events)
            {
                int y = eventItem[0];
                int l = eventItem[1];
                int delta = eventItem[2];

                int diff = y - (int)prevHeight;
                // 两条扫描线之间新增的面积
                double area = coveredWidth * diff;
                // 如果加上这部分面积超过总面积的一半
                if (2L * (currArea + area) >= totalArea)
                {
                    return prevHeight + (totalArea - 2.0 * currArea) / (2.0 * coveredWidth);
                }
                // 更新宽度：开始事件加宽度，结束事件减宽度
                coveredWidth += delta * l;
                currArea += area;
                prevHeight = y;
            }

            return 0.0;
        }

        /// <summary>
        /// [3454] 分割正方形 II
        /// </summary>
        /// <param name="squares"></param>
        /// <returns></returns>
        public double SeparateSquares(int[][] squares)
        {
            var set = new HashSet<int>();
            foreach (int[] square in squares)
            {
                set.Add(square[0]);
                set.Add(square[0] + square[2]);
            }
            var xValues = new List<int>(set);
            xValues.Sort((a, b) => a - b);
            var st = new SegmentTree(xValues);
            var yValues = new List<int[]>();
            int n = squares.Length;
            for (int i = 0; i < n; i++)
            {
                yValues.Add([squares[i][1], i, 1]);
                yValues.Add([squares[i][1] + squares[i][2], i, -1]);
            }
            yValues.Sort((a, b) =>
            {
                if (a[0] != b[0])
                {
                    return a[0] - b[0];
                }
                else if (a[1] != b[1])
                {
                    return a[1] - b[1];
                }
                else
                {
                    return a[2] - b[2];
                }
            });
            long totalArea = 0;
            var areas = new List<long>();
            var intervals = new List<int[]>();
            areas.Add(0);
            intervals.Add([-1, -1]);
            var yValuesCount = yValues.Count;
            var yValuesIndex = 0;
            while (yValuesIndex < yValuesCount)
            {
                var prev = yValuesIndex;
                while (yValuesIndex < yValuesCount - 1 && yValues[yValuesIndex][0] == yValues[yValuesIndex + 1][0])
                {
                    yValuesIndex++;
                }
                if (yValuesIndex < yValuesCount - 1)
                {
                    for (var i = prev; i <= yValuesIndex; i++)
                    {
                        var arr = yValues[i];
                        var index = arr[1];
                        var delta = arr[2];
                        var start = BinarySearchXValue(xValues, squares[index][0]) + 1;
                        var end = BinarySearchXValue(xValues, squares[index][0] + squares[index][2]);
                        st.Update(0, delta, start, end);
                    }
                    var interval = new int[] { yValues[yValuesIndex][0], yValues[yValuesIndex + 1][0] };
                    long currArea = (long)st.GetLength() * (interval[1] - interval[0]);
                    totalArea += currArea;
                    areas.Add(totalArea);
                    intervals.Add(interval);
                }
                yValuesIndex++;
            }
            double halfArea = totalArea / 2.0;
            var areaIndex = BinarySearchArea(areas, halfArea);
            double areaDiff = areas[areaIndex] - halfArea;
            double ratio = areaDiff / (areas[areaIndex] - areas[areaIndex - 1]);
            var targetInterval = intervals[areaIndex];
            return targetInterval[1] - (targetInterval[1] - targetInterval[0]) * ratio;

            int BinarySearchXValue(List<int> xValues, int target)
            {
                int low = 0, high = xValues.Count;
                while (low < high)
                {
                    int mid = low + (high - low) / 2;
                    if (xValues[mid] >= target)
                    {
                        high = mid;
                    }
                    else
                    {
                        low = mid + 1;
                    }
                }
                return low;
            }

            int BinarySearchArea(List<long> areas, double target)
            {
                int low = 0, high = areas.Count;
                while (low < high)
                {
                    int mid = low + (high - low) / 2;
                    if (areas[mid] >= target)
                    {
                        high = mid;
                    }
                    else
                    {
                        low = mid + 1;
                    }
                }
                return low;
            }
        }

        /// <summary>
        /// [2943] 最大化网格图中正方形空洞的面积
        /// </summary>
        /// <param name="n"></param>
        /// <param name="m"></param>
        /// <param name="hBars"></param>
        /// <param name="vBars"></param>
        /// <returns></returns>
        public int MaximizeSquareHoleArea(int n, int m, int[] hBars, int[] vBars)
        {
            Array.Sort(hBars);
            var hMax = 1;
            var left = 1;
            var right = 2;
            foreach (var bar in hBars)
            {
                if (bar == right)
                {
                    right = bar + 1;
                }
                else
                {
                    left = bar - 1;
                    right = bar + 1;
                }
                hMax = Math.Max(hMax, right - left);
            }

            Array.Sort(vBars);
            var vMax = 1;
            left = 1;
            right = 2;
            foreach (var bar in vBars)
            {
                if (bar == right)
                {
                    right = bar + 1;
                }
                else
                {
                    left = bar - 1;
                    right = bar + 1;
                }
                vMax = Math.Max(vMax, right - left);
            }
            var l = Math.Min(hMax, vMax);
            return l * l;
        }

        /// <summary>
        /// [2975] 移除栅栏得到的正方形田地的最大面积
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <param name="hFences"></param>
        /// <param name="vFences"></param>
        /// <returns></returns>
        public int MaximizeSquareArea(int m, int n, int[] hFences, int[] vFences)
        {
            Array.Sort(hFences);
            var hLength = new HashSet<int>() { m - 1 };
            for (int i = 0; i < hFences.Length; i++)
            {
                hLength.Add(hFences[i] - 1);
                hLength.Add(m - hFences[i]);
                for (int j = i + 1; j < hFences.Length; j++)
                {
                    hLength.Add(hFences[j] - hFences[i]);
                }
            }

            Array.Sort(vFences);
            var vLength = new HashSet<int>() { n - 1 };
            for (int i = 0; i < vFences.Length; i++)
            {
                vLength.Add(vFences[i] - 1);
                vLength.Add(n - vFences[i]);
                for (int j = i + 1; j < vFences.Length; j++)
                {
                    vLength.Add(vFences[j] - vFences[i]);
                }
            }

            long res = -1;
            foreach (var len in hLength)
            {
                if (vLength.Contains(len))
                {
                    res = Math.Max(res, len);
                }
            }
            if(res == 0)
            {
                return -1;
            }
            else
            {
                return (int)(res * res % MOD);
            }
        }

        /// <summary>
        /// [1292] 元素和小于等于阈值的正方形的最大边长
        /// </summary>
        /// <param name="mat"></param>
        /// <param name="threshold"></param>
        /// <returns></returns>
        public int MaxSideLength(int[][] mat, int threshold)
        {
            var m = mat.Length;
            var n = mat[0].Length;
            var pre = new int[m][];
            for (int i = 0; i < m; i++)
            {
                pre[i] = new int[n + 1];
                for (int j = 0; j < n; j++)
                {
                    pre[i][j + 1] = pre[i][j] + mat[i][j];
                }
            }
            int left = 0, right = Math.Min(m, n);
            while (left < right)
            {
                int mid = left + (right - left + 1) / 2;
                if (Check(mid))
                {
                    left = mid;
                }
                else
                {
                    right = mid - 1;
                }
            }
            return left;

            bool Check(int len)
            {
                for (int i = 0; i <= m - len; i++)
                {
                    for (int j = 0; j <= n - len; j++)
                    {
                        int sum = 0;
                        for (int k = 0; k < len; k++)
                        {
                            sum += pre[i + k][j + len] - pre[i + k][j];
                        }
                        if (sum <= threshold)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
        }

        /// <summary>
        /// [3314] 构造最小位运算数组 I
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] MinBitwiseArray1(IList<int> nums)
        {
            var n = nums.Count;
            var ans = new int[n];
            for (int i = 0; i < n; i++)
            {
                var min = nums[i] / 2;
                ans[i] = -1;
                for (int j = min; j < nums[i]; j++)
                {
                    if ((j | (j + 1)) == nums[i])
                    {
                        ans[i] = j;
                        break;
                    }
                }
            }
            return ans;
        }

        /// <summary>
        /// [3315] 构造最小位运算数组 II
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] MinBitwiseArray(IList<int> nums)
        {
            var n = nums.Count;
            var ans = new int[n];
            for (int i = 0; i < n; i++)
            {
                var value = nums[i];
                if(value == 2)
                {
                    ans[i] = -1;
                }
                else
                {
                    int t = ~value;
                    int lowbit = t & -t;
                    ans[i] = value ^ (lowbit >> 1);
                }
            }
            return ans;
        }

        /// <summary>
        /// [3507] 移除最小数对使数组有序 I
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MinimumPairRemoval(int[] nums)
        {
            var times = 0;
            while(!Check())
            {
                var index = GetMin();
                nums = Replace(index);
                times++;
            }
            return times;

            int GetMin()
            {
                var res = nums[0] + nums[1];
                var index = 0;
                for(int i = 1; i < nums.Length - 1; i++)
                {
                    if(nums[i] + nums[i+1] < res)
                    {
                        res = nums[i] + nums[i + 1];
                        index = i;
                    }
                }
                return index;
            }

            int[] Replace(int index)
            {
                var newNums = new int[nums.Length - 1];
                for(int i = 0; i < index; i++)
                {
                    newNums[i] = nums[i];
                }
                newNums[index] = nums[index] + nums[index + 1];
                for (int i = index + 2; i < nums.Length; i++)
                {
                    newNums[i - 1] = nums[i];
                }
                return newNums;
            }

            bool Check()
            {
                if(nums.Length <= 1)
                {
                    return true;
                }

                for(int i = 0; i < nums.Length - 1; i++)
                {
                    if(nums[i] > nums[i + 1])
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        /// <summary>
        /// [1877] 数组中最大数对和的最小值
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MinPairSum(int[] nums)
        {
            Array.Sort(nums);
            var ans = 0;
            for (int i = 0; i < nums.Length / 2; i++)
            {
                ans = Math.Max(ans, nums[i] + nums[nums.Length - i - 1]);
            }
            return ans;
        }

        /// <summary>
        /// [1984] 学生分数的最小差值
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MinimumDifference(int[] nums, int k)
        {
            if (k == 1) return 0;
            Array.Sort(nums);
            int ans = nums[k - 1] - nums[0];
            for (int i = 1; i <= nums.Length - k; i++)
            {
                ans = Math.Min(ans, nums[i + k - 1] - nums[i]); 
            }
            return ans;
        }

        /// <summary>
        /// [1200] 最小绝对差
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public IList<IList<int>> MinimumAbsDifference(int[] arr)
        {
            var ans = new List<IList<int>>();
            var minAbs = int.MaxValue;
            var n = arr.Length;
            Array.Sort(arr);
            for (int i = 0; i < n - 1; i++)
            {
                var abs = arr[i + 1] - arr[i];
                if (abs < minAbs)
                {
                    minAbs = abs;
                    ans.Clear();
                    ans.Add(new List<int>() { arr[i], arr[i + 1] });
                }
                else if (abs == minAbs)
                {
                    ans.Add(new List<int>() { arr[i], arr[i + 1] });
                }
            }
            return ans;
        }

        /// <summary>
        /// [3650] 边反转的最小路径总成本
        /// </summary>
        /// <param name="n"></param>
        /// <param name="edges"></param>
        /// <returns></returns>
        public int MinCost(int n, int[][] edges)
        {
            //邻接表
            var g = new List<int[]>[n];
            for(int i = 0;i < n; i++)
            {
                g[i] = new List<int[]>();
            }
            foreach (int[] e in edges)
            {
                int x = e[0];
                int y = e[1];
                int wt = e[2];
                g[x].Add([y, wt]);
                g[y].Add([x, wt * 2]);
            }

            var dis = new int[n];
            Array.Fill(dis, int.MaxValue);
            //堆中保存 (起点到节点 x 的最短路长度，节点 x)
            var pq = new PriorityQueue<int[], int>();
            //起点到自己的距离是 0
            dis[0] = 0;
            pq.Enqueue([0, 0], 0);

            while (pq.Count>0)
            {
                int[] p = pq.Dequeue();
                int disX = p[0];
                int x = p[1];
                if (disX > dis[x])
                {
                    //x 之前出堆过
                    continue;
                }
                if (x == n - 1)
                {
                    //到达终点
                    return disX;
                }
                foreach (int[] e in g[x])
                {
                    int y = e[0];
                    int wt = e[1];
                    int newDisY = disX + wt;
                    if (newDisY < dis[y])
                    {
                        //更新 x 的邻居的最短路
                        //懒更新堆：只插入数据，不更新堆中数据
                        //相同节点可能有多个不同的 newDisY，除了最小的 newDisY，其余值都会触发上面的 continue
                        dis[y] = newDisY;
                        pq.Enqueue([newDisY, y], newDisY);
                    }
                }
            }

            return -1;
        }

        /// <summary>
        /// [744] 寻找比目标字母大的最小字母
        /// </summary>
        /// <param name="letters"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public char NextGreatestLetter(char[] letters, char target)
        {
            var index = 0;
            for(int i = 0; i < letters.Length; i++)
            {
                if(letters[i] > target)
                {
                    index = i;
                    break;
                }
            }
            return letters[index];
        }

        /// <summary>
        /// [3010] 将数组分成最小总代价的子数组 I
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MinimumCost(int[] nums)
        {
            var n1 = nums[0];
            nums = nums.Skip(1).OrderBy(x => x).ToArray();
            return n1 + nums[0] + nums[1];
        }

        /// <summary>
        /// [3634] 使数组平衡的最少移除数目
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MinRemoval(int[] nums, int k)
        {
            Array.Sort(nums);
            int n = nums.Length;
            int length = n;
            int right = 0;

            for (int left = 0; left < n; left++)
            {
                while (right < n && nums[right] <= (long)nums[left] * k)
                {
                    right++;
                }
                length = Math.Min(length, n - (right - left));
            }
            return length;
        }

        /// <summary>
        /// [110] 平衡二叉树
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool IsBalanced(TreeNode root)
        {
            return GetDepth(root, out _);

            bool GetDepth(TreeNode node, out int depth)
            {
                if (node == null)
                {
                    depth = 0;
                    return true;
                }
                depth = 1;
                if (GetDepth(node.left, out var left) && GetDepth(node.right, out var right))
                {
                    depth = Math.Max(left, right) + 1;
                    return Math.Abs(left - right) <= 1;
                }
                return false;
            }
        }

        /// <summary>
        /// [3719] 最长平衡子数组 I
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int LongestBalanced(int[] nums)
        {
            var ans = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                var odd = new Dictionary<int, int>();
                var even = new Dictionary<int, int>();

                for (int j = i; j < nums.Length; j++)
                {
                    var dict = (nums[j] & 1) == 1 ? odd : even;
                    dict[nums[j]] = dict.GetValueOrDefault(nums[j]) + 1;

                    if (odd.Count == even.Count)
                    {
                        ans = Math.Max(ans, j - i + 1);
                    }
                }
            }

            return ans;
        }

        /// <summary>
        /// [67] 二进制求和
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public string AddBinary(string a, string b)
        {
            int CtoI(char c)
            {
                if (c == '1') return 1;
                return 0;
            }

            char ItoC(int i)
            {
                if (i == 1) return '1';
                return '0';
            }

            string s;
            if (b.Length > a.Length)
            {
                s = a;
                a = b;
                b = s;
            }
            var c = new char[a.Length];
            var len = a.Length - b.Length;
            var t = 0;
            for (int i = b.Length - 1; i >= 0; i--)
            {
                var aa = CtoI(a[i + len]) + CtoI(b[i]) + t;
                if (aa > 1)
                {
                    t = 1;
                    aa -= 2;
                }
                else
                {
                    t = 0;
                }
                c[i + len] = ItoC(aa);
            }
            for (int i = len - 1; i >= 0; i--)
            {
                var aa = CtoI(a[i]) + t;
                if (aa > 1)
                {
                    t = 1;
                    aa -= 2;
                }
                else
                {
                    t = 0;
                }
                c[i] = ItoC(aa);
            }
            s = new string(c);
            if (t == 1)
            {
                s = "1" + s;
            }
            return s;
        }

        /// <summary>
        /// [190] 颠倒二进制位
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int ReverseBits(int n)
        {
            //var a = new byte[32];
            //for (var i = 0; i < 32; i++)
            //{
            //    a[i] = (byte)(n & 1);
            //    n >>= 1;
            //}
            //var res = 0;
            //for (var i = 0; i < 32; i++)
            //{
            //    res <<= 1;
            //    res |= a[i];
            //}
            //return res;

            uint res = (uint)n;
            res = ((res >> 1) & 0x55555555) | ((res & 0x55555555) << 1); // 01010101010101010101010101010101
            res = ((res >> 2) & 0x33333333) | ((res & 0x33333333) << 2); // 00110011001100110011001100110011
            res = ((res >> 4) & 0x0f0f0f0f) | ((res & 0x0f0f0f0f) << 4); // 00001111000011110000111100001111
            res = ((res >> 8) & 0x00ff00ff) | ((res & 0x00ff00ff) << 8); // 00000000111111110000000011111111
            res = (res >> 16) | (res << 16);
            return (int)res;
        }

        /// <summary>
        /// [401] 二进制手表
        /// </summary>
        /// <param name="turnedOn"></param>
        /// <returns></returns>
        public IList<string> ReadBinaryWatch(int turnedOn)
        {
            List<int> ConbineNumber(int number, int digit, int last)
            {
                if(last == 0)
                {
                    return new List<int> { number };
                }
                else if(digit == last)
                {
                    return ConbineNumber((number << 1) + 1, digit - 1, last - 1);
                }
                else if(digit == 0)
                {
                    return ConbineNumber(number << 1, digit, last - 1);
                }
                else
                {
                    var nums = new List<int>();
                    nums.AddRange(ConbineNumber((number << 1) + 1, digit - 1, last - 1));
                    nums.AddRange(ConbineNumber(number << 1, digit, last - 1));
                    return nums;
                }
            }

            var nums = ConbineNumber(0, turnedOn, 10);
            var res = new List<string>();
            foreach (var num in nums)
            {
                var minute = num >> 4;
                var hour = num & 0x0000000f;
                if (hour >= 12 || minute >= 60) continue;
                res.Add(hour.ToString("D1") + ":" + minute.ToString("D2"));
            }
            return res;
        }

        /// <summary>
        /// [693] 交替位二进制数
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public bool HasAlternatingBits(int n)
        {
            uint un = (uint)n;
            var a = un ^ (un >> 1);
            var b = a + 1;
            return (a & b) == 0;
        }

        /// <summary>
        /// [696] 计数二进制子串
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int CountBinarySubstrings(string s)
        {
            var a = '0';
            var count = 0;
            var old = 0;
            var res = 0;
            foreach(var c in s)
            {
                if(c == a)
                {
                    count++;
                }
                else
                {
                    res += Math.Min(old, count);
                    old = count;
                    a = c;
                    count = 1;
                }
            }
            res += Math.Min(old, count);
            return res;
        }

        /// <summary>
        /// [761] 特殊的二进制序列
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string MakeLargestSpecial(string s)
        {
            if (s.Length <= 2)
            {
                return s;
            }
            int cnt = 0, left = 0;
            List<string> subs = new List<string>();
            for (int i = 0; i < s.Length; ++i)
            {
                if (s[i] == '1')
                {
                    ++cnt;
                }
                else
                {
                    --cnt;
                    if (cnt == 0)
                    {
                        subs.Add("1" + MakeLargestSpecial(s.Substring(left + 1, i - left - 1)) + "0");
                        left = i + 1;
                    }
                }
            }

            subs.Sort((a, b) => b.CompareTo(a));
            StringBuilder ans = new StringBuilder();
            foreach (string sub in subs)
            {
                ans.Append(sub);
            }
            return ans.ToString();
        }

        /// <summary>
        /// [762] 二进制表示中质数个计算置位
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public int CountPrimeSetBits(int left, int right)
        {
            int BitCount(int i)
            {
                i = i - ((i >> 1) & 0x55555555);
                i = (i & 0x33333333) + ((i >> 2) & 0x33333333);
                i = (i + (i >> 4)) & 0x0f0f0f0f;
                i = i + (i >> 8);
                i = i + (i >> 16);
                return i & 0x3f;
            }

            int ans = 0;
            for (int x = left; x <= right; ++x)
            {
                if (((1 << BitCount(x)) & 665772) != 0)
                {
                    ++ans;
                }
            }
            return ans;
        }
    }
}