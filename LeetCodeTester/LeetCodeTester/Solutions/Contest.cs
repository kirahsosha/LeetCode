using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTester.Solutions
{
    public partial class Solution
    {
        /// <summary>
        /// 468-Q1
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int EvenNumberBitwiseORs(int[] nums)
        {
            int res = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] % 2 == 0)
                {
                    if (res == 0)
                    {
                        res = nums[i];
                    }
                    else
                    {
                        res = res | nums[i];
                    }
                }
            }
            return res;
        }

        /// <summary>
        /// 468-Q2
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public long MaxTotalValue(int[] nums, int k)
        {
            var max = nums.Max();
            var min = nums.Min();
            return (long)(k * (long)(max - min));
        }

        /// <summary>
        /// 468-Q3
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        //public int MinSplitMerge(int[] nums1, int[] nums2)
        //{
        //    return MinSplitMerge(nums1, nums2, 0);
        //}

        //private int MinSplitMerge(int[] nums1, int[] nums2, int k)
        //{
        //    if(nums1 == nums2)
        //    {
        //        return k;
        //    }
        //    for(int i = 0;i < nums1.Length; i++)
        //    {
        //        for(int j = i;  j < nums1.Length; j++)
        //        {
        //            if(i > 0)
        //            {
        //                var nums = nums1[i..j]. nums1[0..(i - 1)];
        //            }
        //        }
        //    }
        //}

        /// <summary>
        /// 468-Q4
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public long MaxTotalValue2(int[] nums, int k)
        {
            if (nums.Length == 1) return 0;
            var pqMax = new PriorityQueue<int, int>();
            var pqMin = new PriorityQueue<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                pqMax.Enqueue(i, -nums[i]);
                pqMin.Enqueue(i, nums[i]);
            }
            long res = 0;
            int index = 0;
            var max = pqMax.Dequeue();
            var min = pqMin.Dequeue();
            while (index < k)
            {
                int newIndex = 0;
                if (min < max)
                {
                    newIndex = (min + 1) * (nums.Length - max);
                }
                else
                {
                    newIndex = (max + 1) * (nums.Length - min);
                }
                if (newIndex > k - index)
                {
                    newIndex = k - index;
                }
                res += newIndex * (nums[max] - nums[min]);
                index += newIndex;
                if (index >= k) break;
                var newMax = pqMax.Count > 0 ? pqMax.Peek() : min;
                var newMin = pqMin.Count > 0 ? pqMin.Peek() : max;
                if (nums[newMax] - nums[min] > nums[max] - nums[newMin])
                {
                    max = pqMax.Dequeue();
                }
                else
                {
                    min = pqMin.Dequeue();
                }
            }
            return res;
        }

        /// <summary>
        /// 478-Q1
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int CountElements(int[] nums, int k)
        {
            // 对数组进行排序（从小到大）
            Array.Sort(nums);

            int n = nums.Length;
            int count = 0;

            // 对于每个元素，使用二分查找找到第一个严格大于它的位置
            for (int i = 0; i < n; i++)
            {
                // 使用二分查找找到第一个严格大于nums[i]的位置
                int left = i + 1, right = n - 1;
                int firstGreaterIndex = n; // 初始化为n，表示没找到

                while (left <= right)
                {
                    int mid = left + (right - left) / 2;
                    if (nums[mid] > nums[i])
                    {
                        firstGreaterIndex = mid;
                        right = mid - 1; // 继续向左查找更早的位置
                    }
                    else
                    {
                        left = mid + 1;
                    }
                }

                // 严格大于nums[i]的元素数量 = n - firstGreaterIndex
                int strictGreater = n - firstGreaterIndex;

                // 如果严格大于当前元素的个数 >= k，则该元素是合格的
                if (strictGreater >= k)
                {
                    count++;
                }
            }

            return count;
        }

        /// <summary>
        /// 478-Q2
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int MaxDistinct(string s)
        {
            var res = new HashSet<char>();
            foreach (var c in s)
            {
                if (res.Contains(c)) continue;
                res.Add(c);
                if (res.Count == 26) break;
            }
            return res.Count;
        }

        /// <summary>
        /// 478-Q3
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MinMirrorPairDistance(int[] nums)
        {
            var res = -1;
            var dic = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (dic.ContainsKey(nums[i]))
                {
                    res = res == -1 ? i - dic[nums[i]] : Math.Min(res, i - dic[nums[i]]);
                    if (res == 1) break;
                }
                var rev = Reverse(nums[i]);
                if (dic.ContainsKey(rev))
                {
                    dic[rev] = i;
                }
                else
                {
                    dic.Add(rev, i);
                }
            }
            return res;
        }

        private int Reverse(int num)
        {
            int reversed = 0;
            while (num > 0)
            {
                reversed = reversed * 10 + num % 10;
                num /= 10;
            }
            return reversed;
        }

        /// <summary>
        /// 478-Q4
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <param name="queries"></param>
        /// <returns></returns>
        public long[] MinOperations(int[] nums, int k, int[][] queries)
        {
            var count = queries.Length;
            var ans = new long[count];
            var mods = Enumerable.Repeat(-1, nums.Length).ToArray();

            for (int i = 0; i < count; i++)
            {
                var l = queries[i][0];
                var r = queries[i][1];
                int len = r - l + 1;

                // 如果只有一个元素，操作次数为0
                if (len == 1)
                {
                    ans[i] = 0;
                    continue;
                }

                int GetMod(int index)
                {
                    if (mods[index] == -1)
                    {
                        mods[index] = nums[index] % k;
                    }
                    return mods[index];
                }

                // 检查所有元素模k是否相同
                var firstMod = GetMod(l);
                var canEqual = true;

                for (int j = l + 1; j <= r; j++)
                {
                    var mod = GetMod(j);
                    if (mod != firstMod)
                    {
                        canEqual = false;
                        break;
                    }
                }

                if (!canEqual)
                {
                    ans[i] = -1;
                    continue;
                }

                long[] sub = new long[len];
                for (int j = 0; j < len; j++)
                {
                    sub[j] = nums[l + j];
                }

                // 使用快速选择找到中位数
                int index = len / 2;
                long target = Common.QuickSelect(sub, 0, len - 1, index);

                // 计算操作次数
                long operations = 0;
                for (int j = 0; j < len; j++)
                {
                    long diff = Math.Abs(nums[l + j] - target);
                    operations += diff / k;
                }

                ans[i] = operations;
            }

            return ans;
        }

        /// <summary>
        /// B176-Q1. 带权单词映射
        /// </summary>
        /// <param name="words"></param>
        /// <param name="weights"></param>
        /// <returns></returns>
        public string MapWordWeights(string[] words, int[] weights)
        {
            var res = new StringBuilder();
            foreach (var word in words)
            {
                var weight = 0;
                foreach (var c in word)
                {
                    weight += weights[c - 'a'];
                }
                var mod = (char)('z' - weight % 26);
                res.Append(mod);
            }
            return res.ToString();
        }

        /// <summary>
        /// B176-Q2. 前缀连接组的数目
        /// </summary>
        /// <param name="words"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int PrefixConnected(string[] words, int k)
        {
            var dic = new Dictionary<string, int>();
            foreach (var word in words)
            {
                if(word.Length < k)
                {
                    continue;
                }
                var pre = word.Substring(0, k);
                if (dic.ContainsKey(pre))
                {
                    dic[pre]++;
                }
                else
                {
                    dic.Add(pre, 1);
                }
            }

            var res = dic.Count(d => d.Value > 1);

            return res;
        }

        /// <summary>
        /// B176-Q3. 打家劫舍 V
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="colors"></param>
        /// <returns></returns>
        public long Rob5(int[] nums, int[] colors)
        {
            var n = nums.Length;
            var dp = new long[n, 2];
            //0 - not rob; 1 - rob
            //dp[i, 0] = max(dp[i - 1, 0], dp[i - 1, 1])
            //dp[i,1] = colors[i-1]==colors[i]? dp[i - 1, 0] + nums[i] : max(dp[i - 1, 0], dp[i - 1, 1]) + nums[i]

            dp[0, 0] = 0;
            dp[0, 1] = nums[0];

            for (var i = 1; i < n; i++)
            {
                dp[i,0] = Math.Max(dp[i - 1, 0], dp[i - 1, 1]);
                if (colors[i-1] == colors[i])
                {
                    dp[i, 1] = dp[i - 1, 0] + nums[i];
                }
                else
                {
                    dp[i, 1] = Math.Max(dp[i - 1, 0], dp[i - 1, 1]) + nums[i];
                }
            }
            return Math.Max(dp[n - 1, 0], dp[n - 1, 1]);
        }

        /// <summary>
        /// B176-Q4. 查询树上回文路径©leetcode
        /// </summary>
        /// <param name="n"></param>
        /// <param name="edges"></param>
        /// <param name="s"></param>
        /// <param name="queries"></param>
        /// <returns></returns>
        public IList<bool> PalindromePath(int n, int[][] edges, string s, string[] queries)
        {
            int LCA(int u, int v, int[] depth, int[,] parentK, int maxLog, int n)
            {
                if (depth[u] < depth[v])
                {
                    (u, v) = (v, u);
                }
                var diff = depth[u] - depth[v];
                for (int k = maxLog; k >= 0; k--)
                {
                    if (diff >= (1 << k))
                    {
                        u = parentK[k, u];
                        diff -= (1 << k);
                    }
                }
                if (u == v) return u;

                for (int k = maxLog; k >= 0; k--)
                {
                    if (parentK[k, u] != parentK[k, v])
                    {
                        u = parentK[k, u];
                        v = parentK[k, v];
                    }
                }
                return parentK[0, u];
            }

            var graph = new List<int>[n];
            for (int i = 0; i < n; i++)
            {
                graph[i] = new List<int>();
            }
            foreach (var edge in edges)
            {
                var u = edge[0];
                var v = edge[1];
                graph[u].Add(v);
                graph[v].Add(u);
            }

            var depth = new int[n];
            var parent0 = new int[n];
            var inTime = new int[n];
            var outTime = new int[n];
            var prefixXor = new int[n];
            var charArr = s.ToCharArray();

            var stack = new Stack<(int u, int parent, int nextIndex)>();
            stack.Push((0, -1, 0));
            depth[0] = 0;
            parent0[0] = -1;
            prefixXor[0] = 1 << (s[0] - 'a');
            var timer = 0;

            while (stack.Count > 0)
            {
                (var u, var parent, var nextIndex) = stack.Pop();
                if (nextIndex == 0)
                {
                    inTime[u] = ++timer;
                }
                if (nextIndex < graph[u].Count)
                {
                    var v = graph[u][nextIndex];
                    stack.Push((u, parent, nextIndex + 1));
                    if (v == parent)
                    {
                        continue;
                    }
                    parent0[v] = u;
                    depth[v] = depth[u] + 1;
                    prefixXor[v] = prefixXor[u] ^ (1 << (s[v] - 'a'));
                    stack.Push((v, u, 0));
                }
                else
                {
                    outTime[u] = timer;
                }
            }

            var maxLog = (int)Math.Ceiling(Math.Log(n, 2));
            var parentK = new int[maxLog + 1, n];
            for (int i = 0; i < n; i++)
            {
                parentK[0, i] = parent0[i];
            }
            for (int k = 1; k <= maxLog; k++)
            {
                for (int i = 0; i < n; i++)
                {
                    if (parentK[k - 1, i] == -1)
                    {
                        parentK[k, i] = -1;
                    }
                    else
                    {
                        parentK[k, i] = parentK[k - 1, parentK[k - 1, i]];
                    }
                }
            }

            var ft = new FenwickTree(n + 2);
            var res = new List<bool>();
            foreach (var q in queries)
            {
                var query = q.Split();
                if (query[0] == "update")
                {
                    var ui = int.Parse(query[1]);
                    var c = query[2][0];
                    var oldChar = charArr[ui];
                    var delta = (1 << (oldChar - 'a')) ^ (1 << (c - 'a'));
                    ft.Update(inTime[ui], delta);
                    ft.Update(outTime[ui] + 1, delta);
                    charArr[ui] = c;
                }
                else
                {
                    // query
                    var ui = int.Parse(query[1]);
                    var vi = int.Parse(query[2]);
                    var lca = LCA(ui, vi, depth, parentK, maxLog, n);
                    var addU = ft.Query(inTime[ui]);
                    var addV = ft.Query(inTime[vi]);
                    var currentU = prefixXor[ui] ^ addU;
                    var currentV = prefixXor[vi] ^ addV;
                    var lcaCharBit = 1 << (charArr[lca] - 'a');
                    var pathMask = currentU ^ currentV ^ lcaCharBit;
                    var count = BitOperations.PopCount((uint)pathMask);
                    res.Add(count <= 1);
                }
            }
            return res;
        }
    }
}
