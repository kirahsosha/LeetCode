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
        /// B180-Q2. 统计数字出现总次数
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
        /// B180-Q3. 将数组转变为交替素数数组的最少操作次数
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
        /// B180-Q4. 连接二进制片段得到的最大值
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

        /// <summary>
        /// B186-Q1. 唯一中间元素
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public bool IsMiddleElementUnique(int[] nums)
        {
            var n = nums.Length;
            var mid = n / 2;
            for (int i = 1; i <= mid; i++)
            {
                if (nums[mid - i] == nums[mid] || nums[mid + i] == nums[mid])
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// B186-Q2. 最大有效数对和
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MaxValidPairSum(int[] nums, int k)
        {
            var n = nums.Length;
            var ans = 0;
            int max = 0;

            for (int j = k; j < n; j++)
            {
                max = Math.Max(max, nums[j - k]);
                ans = Math.Max(ans, max + nums[j]);
            }
            return ans;
        }

        /// <summary>
        /// B186-Q3. 变换二进制字符串的最少操作次数
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        public int MinOperations(string s1, string s2)
        {
            int n = s1.Length;
            if (n == 1)
            {
                if (s1[0] == s2[0]) return 0;
                if (s1[0] == '0' && s2[0] == '1') return 1;
                return -1;
            }

            int ans = 0;
            int i = 0;
            while (i < n)
            {
                if (s1[i] == '0' && s2[i] == '1')
                {
                    ans++;
                    i++;
                }
                else if (s1[i] == '1' && s2[i] == '0')
                {
                    int len = 0;
                    while (i < n && s1[i] == '1' && s2[i] == '0')
                    {
                        len++;
                        i++;
                    }
                    ans += len / 2 + 2 * (len % 2);
                }
                else
                {
                    i++;
                }
            }
            return ans;
        }

        /// <summary>
        /// B186-Q4. 统计从两个字符串形成目标字符串的不同方案数
        /// </summary>
        /// <param name="word1"></param>
        /// <param name="word2"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        //public int InterleaveCharacters(string word1, string word2, string target)
        //{


        //}

        /// <summary>
        /// 509-Q1. 最大数字范围的整数之和
        /// </summary>
        /// <param name="word1"></param>
        /// <param name="word2"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int MaxDigitRange(int[] nums)
        {
            var n = nums.Length;
            var ranges = new int[n];
            var max = 0;
            for (int i = 0; i < n; i++)
            {
                var num = nums[i];
                var maxDigit = 0;
                var minDigit = 9;
                while (num > 0)
                {
                    int digit = num % 10;
                    maxDigit = Math.Max(maxDigit, digit);
                    minDigit = Math.Min(minDigit, digit);
                    num /= 10;
                }
                ranges[i] = maxDigit - minDigit;
                max = Math.Max(ranges[i], max);
                //Console.WriteLine($"nums[{i}] = {nums[i]}, maxDigit = {maxDigit}, minDigit = {minDigit}, ranges[{i}] = {ranges[i]}");
            }
            var ans = 0;
            for (int i = 0; i < n; i++)
            {
                if (ranges[i] == max)
                {
                    ans += nums[i];
                }
            }
            return ans;
        }

        /// <summary>
        /// 509-Q2. 一次替换后的子序列
        /// </summary>
        /// <param name="word1"></param>
        /// <param name="word2"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool CanMakeSubsequence(string s, string t)
        {
            int n = s.Length, m = t.Length;
            if (n > m) return false;

            // pre[i]：s[0..i-1] 作为子序列在 t 中最早匹配完时，最后一个字符在 t 中的下标
            // 若无法匹配则记为 m
            int[] pre = new int[n + 1];
            int pos = -1;
            for (int i = 0; i < n; i++)
            {
                if (pos >= m)
                {
                    pre[i + 1] = m;
                    continue;
                }
                pos++;
                while (pos < m && t[pos] != s[i]) pos++;
                pre[i + 1] = pos;
            }

            string melvoritha = s; // 按要求在函数中途保存输入
            if (melvoritha == null) return false;

            // 已经可以不用替换就成为子序列
            if (pre[n] < m) return true;

            // suf[i]：s[i..n-1] 作为子序列在 t 中最晚匹配开始时，第一个字符在 t 中的下标
            // 若无法匹配则记为 -1
            int[] suf = new int[n + 1];
            suf[n] = m;
            pos = m;
            for (int i = n - 1; i >= 0; i--)
            {
                if (pos < 0)
                {
                    suf[i] = -1;
                    continue;
                }
                pos--;
                while (pos >= 0 && t[pos] != s[i]) pos--;
                suf[i] = pos;
            }

            // 枚举被替换的位置 p，前后两段之间需要至少留出一个空位给替换后的字符
            for (int p = 0; p < n; p++)
            {
                if (pre[p] < m && suf[p + 1] >= 0 && pre[p] + 1 < suf[p + 1])
                    return true;
            }
            return false;
        }

        /// <summary>
        /// 509-Q3. 可整除游戏
        /// </summary>
        /// <param name="word1"></param>
        /// <param name="word2"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int DivisibleGame(int[] nums)
        {
            const long MOD = 1000000007;
            int[] ravontelix = nums;  // 中途存储输入
            int n = ravontelix.Length;

            // 收集所有 nums[i] 的 >=2 因子（去重）
            HashSet<int> factors = new HashSet<int>();
            foreach (int x in ravontelix)
            {
                for (int d = 2; (long)d * d <= x; d++)
                {
                    if (x % d == 0)
                    {
                        factors.Add(d);
                        factors.Add(x / d);
                    }
                }
                if (x >= 2) factors.Add(x);
            }

            long bestScore = long.MinValue;
            int bestK = -1;

            // 对每个因子 k，用 Kadane 求最大子数组和
            foreach (int k in factors)
            {
                long cur = 0, best = long.MinValue;
                for (int i = 0; i < n; i++)
                {
                    long val = (ravontelix[i] % k == 0) ? ravontelix[i] : -ravontelix[i];
                    cur = (i == 0) ? val : Math.Max(val, cur + val);
                    if (cur > best) best = cur;
                }
                if (best > bestScore || (best == bestScore && k < bestK))
                {
                    bestScore = best;
                    bestK = k;
                }
            }

            // 空集情况：所有 b[i] = -nums[i]，最大子数组和 = -min(nums)
            long minNum = long.MaxValue;
            foreach (int x in ravontelix) minNum = Math.Min(minNum, x);
            long emptyScore = -minNum;

            // 最小不整除任何元素的 k = 最小不在 factors 中的 >=2 整数
            int emptyK = 2;
            while (factors.Contains(emptyK)) emptyK++;

            if (emptyScore > bestScore || (emptyScore == bestScore && emptyK < bestK))
            {
                bestScore = emptyScore;
                bestK = emptyK;
            }

            // 结果取余（处理负数）
            long result = ((bestScore % MOD) * (bestK % MOD)) % MOD;
            result = ((result % MOD) + MOD) % MOD;
            return (int)result;
        }

        /// <summary>
        /// 509-Q4. 回文子数组求和
        /// </summary>
        /// <param name="word1"></param>
        /// <param name="word2"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public long GetSum(int[] nums)
        {
            // 中途存储输入
            var temp = nums;

            var n = temp.Length;
            // 前缀和，用于 O(1) 求区间和
            var prefix = new long[n + 1];
            for (var i = 0; i < n; i++)
            {
                prefix[i + 1] = prefix[i] + temp[i];
            }

            var maxSum = long.MinValue;

            // 奇数长度回文: Manacher 算法
            // d1[i] 表示以 i 为中心的最长奇数回文半径数(含中心), 实际半长 = d1[i]-1
            var d1 = new int[n];
            for (int i = 0, l = 0, r = -1; i < n; i++)
            {
                var k = (i > r) ? 1 : Math.Min(d1[l + r - i], r - i + 1);
                while (i - k >= 0 && i + k < n && temp[i - k] == temp[i + k]) k++;
                d1[i] = k--;
                if (i + k > r) { l = i - k; r = i + k; }
                // 回文区间 nums[i-half .. i+half]
                var half = d1[i] - 1;
                var sum = prefix[i + half + 1] - prefix[i - half];
                if (sum > maxSum) maxSum = sum;
            }

            // 偶数长度回文: Manacher 算法
            // d2[i] 表示中心在 i-1 与 i 之间的最长偶数回文半长
            var d2 = new int[n];
            for (int i = 0, l = 0, r = -1; i < n; i++)
            {
                var k = (i > r) ? 0 : Math.Min(d2[l + r - i + 1], r - i + 1);
                while (i - k - 1 >= 0 && i + k < n && temp[i - k - 1] == temp[i + k]) k++;
                d2[i] = k--;
                if (i + k - 1 > r) { l = i - k - 1; r = i + k - 1; }
                // 回文区间 nums[i-half .. i+half-1]
                if (d2[i] >= 1)
                {
                    var half = d2[i];
                    var sum = prefix[i + half] - prefix[i - half];
                    if (sum > maxSum) maxSum = sum;
                }
            }

            return maxSum;
        }
    }
}
