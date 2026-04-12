using System;
using System.Collections;
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
                if (word.Length < k)
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
                dp[i, 0] = Math.Max(dp[i - 1, 0], dp[i - 1, 1]);
                if (colors[i - 1] == colors[i])
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

        /// <summary>
        /// 491-Q1. 移除尾部元音字母
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string TrimTrailingVowels(string s)
        {
            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (IsVowel(s[i]))
                {
                    s = s.Substring(0, i);
                }
                else
                {
                    break;
                }
            }
            return s;
        }

        /// <summary>
        /// 491-Q2. 拆分到 1 的最小总代价
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int MinCost(int n)
        {
            var res = 0;
            if (n == 1)
            {
                return res;
            }
            var left = n / 2;
            var right = n - left;
            res += left * right;
            return res + MinCost(left) + MinCost(right);
        }

        /// <summary>
        /// 491-Q3. 按位或的最小值
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int MinimumOR(int[][] grid)
        {
            int res = 0;
            for (int k = 20; k >= 0; k--)
            {
                int high_mask = (1 << (k + 1)) - 1; // 低位掩码 (0 to k)
                int current_high = res & ~high_mask; // 高位部分在 res 中的值
                bool requires_high_zero = (current_high == 0);

                bool canSetZero = true;
                for (int i = 0; i < grid.Length; i++)
                {
                    bool found = false;
                    for (int j = 0; j < grid[i].Length; j++)
                    {
                        int num = grid[i][j];
                        if (requires_high_zero)
                        {
                            // 要求高位（k+1 to 20）为0
                            if ((num & ~high_mask) == 0 && (num & (1 << k)) == 0)
                                found = true;
                        }
                        else
                        {
                            // 不要求高位，只需当前位为0
                            if ((num & (1 << k)) == 0)
                                found = true;
                        }
                        if (found) break;
                    }
                    if (!found)
                    {
                        canSetZero = false;
                        break;
                    }
                }
                if (!canSetZero)
                {
                    res |= (1 << k);
                }
            }
            return res;
        }

        /// <summary>
        /// 491-Q4. 统计包含 K 个不同整数的子数组
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        public long CountSubarrays(int[] nums, int k, int m)
        {
            int n = nums.Length;
            long result = 0;
            int[] freq = new int[100001];
            int distinctCount = 0;
            int underM = 0;
            int left = 0;

            for (int right = 0; right < n; right++)
            {
                int num = nums[right];
                if (freq[num] == 0)
                {
                    distinctCount++;
                }
                freq[num]++;
                if (freq[num] == m)
                {
                    underM--;
                }
                else if (freq[num] == 1)
                {
                    underM++;
                }

                while (distinctCount > k || (distinctCount == k && underM > 0))
                {
                    int leftNum = nums[left];
                    freq[leftNum]--;
                    if (freq[leftNum] == m - 1)
                    {
                        underM++;
                    }
                    else if (freq[leftNum] == 0)
                    {
                        distinctCount--;
                    }
                    left++;
                }

                if (distinctCount == k && underM == 0)
                {
                    result++;
                }
            }
            return result;
        }

        /// <summary>
        /// B180-Q1. 交通信号灯的颜色
        /// </summary>
        /// <param name="timer"></param>
        /// <returns></returns> <summary>
        public string TrafficSignal(int timer)
        {
            if (timer == 0)
            {
                return "Green";
            }
            else if (timer == 30)
            {
                return "Orange";
            }
            else if (30 < timer && timer <= 90)
            {
                return "Red";
            }
            else
            {
                return "Invalid";
            }
        }

        /// <summary>
        /// B180-Q2. 统计数字出现总次数©leetcode
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="digit"></param>
        /// <returns></returns> <summary>
        public int CountDigitOccurrences(int[] nums, int digit)
        {
            var ans = 0;
            foreach (var num in nums)
            {
                int n = num;
                while (n > 0)
                {
                    if (n % 10 == digit)
                    {
                        ans++;
                    }
                    n /= 10;
                }
            }
            return ans;
        }

        /// <summary>
        /// B180-Q3. 将数组转变为交替素数数组的最少操作次数©leetcode
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MinOperationsPrime(int[] nums)
        {
            var maxInNums = nums.Max();
            var sieveSize = Math.Min(maxInNums + 100, 100100);

            var isPrime = new BitArray(sieveSize + 1);
            isPrime.Set(0, false);
            isPrime.Set(1, false);
            for (int i = 2; i <= sieveSize; i++)
            {
                isPrime.Set(i, true);
            }

            for (int i = 2; i * i <= sieveSize; i++)
            {
                if (isPrime.Get(i))
                {
                    for (int j = i * i; j <= sieveSize; j += i)
                    {
                        isPrime.Set(j, false);
                    }
                }
            }

            var nextPrime = new int[sieveSize + 1];
            var lastPrime = -1;
            for (int i = sieveSize; i >= 0; i--)
            {
                if (isPrime.Get(i))
                {
                    lastPrime = i;
                }
                nextPrime[i] = lastPrime;
            }

            var ans = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (i % 2 == 0)
                {
                    ans += nextPrime[nums[i]] - nums[i];
                }
                else
                {
                    if (isPrime.Get(nums[i]))
                    {
                        if (nums[i] == 2)
                        {
                            ans += 2;
                        }
                        else
                        {
                            ans += 1;
                        }
                    }
                }
            }

            return ans;
        }

        /// <summary>
        /// Q4. 连接二进制片段得到的最大值©leetcode
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums0"></param>
        /// <returns></returns>
        public int MaxValue(int[] nums1, int[] nums0)
        {
            var n = nums1.Length;
            //const int MOD = 1000000007;

            var pieces = new (int ones, int zeros)[n];
            for (int i = 0; i < n; i++)
            {
                pieces[i] = (nums1[i], nums0[i]);
            }

            // 按 1 的数量降序，1 的数量相同时按 0 的数量升序排序
            Array.Sort(pieces, (a, b) =>
            {
                if (a.ones != b.ones) return b.ones.CompareTo(a.ones);
                return a.zeros.CompareTo(b.zeros);
            });

            // 计算总位数
            long totalBits = 0;
            foreach (var item in pieces)
            {
                totalBits += item.ones + item.zeros;
            }

            // 预处理 2 的幂次 (mod MOD)
            var maxBit = (int)totalBits;
            var pow2 = new long[maxBit + 2];
            pow2[0] = 1;
            for (int i = 1; i <= maxBit + 1; i++)
            {
                pow2[i] = pow2[i - 1] * 2 % MOD;
            }

            // 计算结果
            long result = 0;
            long processed = 0; // 已经处理的位数（在当前片段右侧）

            foreach (var item in pieces)
            {
                var ones = item.ones;
                var zeros = item.zeros;

                // 当前片段的 1 位于从 processed + zeros 到 processed + zeros + ones - 1 的位置（从右数，0-indexed）
                long left = processed + zeros; // 最低位的 1 的位置
                long right = processed + zeros + ones - 1; // 最高位的 1 的位置

                // 连续 1 段的值: 2^left + 2^(left+1) + ... + 2^right = 2^(right+1) - 2^left
                long contribution = (pow2[right + 1] - pow2[left] + MOD) % MOD;
                result = (result + contribution) % MOD;

                processed += ones + zeros;
            }

            return (int)result;
        }
    }
}
