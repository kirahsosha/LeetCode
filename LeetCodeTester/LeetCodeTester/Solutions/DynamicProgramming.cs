using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeTester.Solutions
{
    public partial class Solution
    {
        /// <summary>
        /// [5] 最长回文子串
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string LongestPalindrome(string s)
        {
            #region 中心扩展法
            //if (s.Length <= 1) return s;
            //int n = s.Length;
            //int p = 0, len = 1;
            //if (s[0] == s[1]) len = 2;
            ////以i为中心点找到最长回文子串
            //for (int i = 1; i < n - 1; i++)
            //{
            //    if (s[i] == s[i + 1])
            //    {
            //        if (len < 2)
            //        {
            //            len = 2;
            //            p = i;
            //        }
            //    }
            //    //允许的最大臂长
            //    int max1 = Math.Min(i, n - i - 1);
            //    int max2 = Math.Min(i, n - i - 2);
            //    int t = 0;
            //    if (len > max1 * 2 + 1) continue;
            //    //奇数回文串
            //    for (int j = 1; j <= max1; j++)
            //    {
            //        if (s[i - j] != s[i + j])
            //        {
            //            t = 2 * j - 1;
            //            if (t > len)
            //            {
            //                p = i - j + 1;
            //                len = t;
            //            }
            //            break;
            //        }
            //        if (j == max1)
            //        {
            //            t = 2 * j + 1;
            //            if (t > len)
            //            {
            //                p = i - j;
            //                len = t;
            //            }
            //        }
            //    }
            //    //偶数回文串
            //    if (s[i] != s[i + 1]) continue;
            //    for (int j = 1; j <= max2; j++)
            //    {
            //        if (s[i - j] != s[i + j + 1])
            //        {
            //            t = 2 * j;
            //            if (t > len)
            //            {
            //                p = i - j + 1;
            //                len = t;
            //            }
            //            break;
            //        }
            //        if (j == max2)
            //        {
            //            t = 2 * j + 2;
            //            if (t > len)
            //            {
            //                p = i - j;
            //                len = t;
            //            }
            //        }
            //    }
            //}
            //return s.Substring(p, len);
            #endregion
            int n = s.Length;
            if (n <= 1) return s;
            bool[,] dp = new bool[n, n];
            string res = "";
            for (int len = 1; len <= n; len++)
            {
                for (int i = 0; i + len - 1 < n; i++)
                {
                    int j = i + len - 1;
                    if (len == 1)
                    {
                        dp[i, j] = true;
                    }
                    else if (len == 2)
                    {
                        dp[i, j] = s[i] == s[j];
                    }
                    else
                    {
                        dp[i, j] = dp[i + 1, j - 1] && s[i] == s[j];
                    }
                    if (len > res.Length && dp[i, j])
                    {
                        res = s.Substring(i, len);
                    }
                }
            }
            return res;
        }

        /// <summary>
        /// [32] 最长有效括号
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int LongestValidParentheses(string s)
        {
            if (s.Length <= 1) return 0;
            var stack = new Stack<int>();
            var dp = new int[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                dp[i] = 0;
                if (s[i] == '(')
                {
                    stack.Push(i);
                }
                else if (stack.Count != 0)
                {
                    var start = stack.Pop();
                    dp[start] = i;
                }
            }
            int index = 0, cur = 0, max = 0;
            while (index < s.Length)
            {
                if (dp[index] == 0 && cur == 0)
                {
                    index++;
                }
                else if (dp[index] == 0)
                {
                    max = Math.Max(max, cur);
                    cur = 0;
                    index++;
                }
                else
                {
                    cur += dp[index] - index + 1;
                    index = dp[index] + 1;
                }
            }
            return Math.Max(max, cur);
        }

        /// <summary>
        /// [120] 三角形最小路径和
        /// </summary>
        /// <param name="triangle"></param>
        /// <returns></returns>
        public int MinimumTotal(IList<IList<int>> triangle)
        {
            if (triangle.Count == 1)
            {
                return triangle[0][0];
            }
            var n = triangle.Count;
            int[] dp = new int[n];
            dp[0] = triangle[0][0];
            for (int i = 1; i < n; i++)
            {
                for (int j = i; j >= 0; j--)
                {
                    if (j == 0)
                    {
                        dp[j] = dp[j] + triangle[i][j];
                    }
                    else if (j == i)
                    {
                        dp[j] = dp[j - 1] + triangle[i][j];
                    }
                    else
                    {
                        dp[j] = Math.Min(dp[j], dp[j - 1]) + triangle[i][j];
                    }
                }
            }
            return dp.Min();
        }

        /// <summary>
        /// [198] 打家劫舍
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int Rob(int[] nums)
        {
            //dp[i] = max(dp[i-1], dp[i-2] + num[i])
            //因为在计算dp[i]的时候只需要使用到dp[i - 1]和dp[i - 2], 所以将数组优化为两个int
            int n = nums.Length;
            if (n == 0) return 0;
            if (n == 1) return nums[0];
            if (n == 2) return Math.Max(nums[0], nums[1]);
            int dp1, dp2;
            dp1 = nums[0];
            dp2 = Math.Max(nums[0], nums[1]);
            for (int i = 2; i < n; i++)
            {
                int sum = Math.Max(dp1 + nums[i], dp2);
                dp1 = dp2;
                dp2 = sum;
            }
            return Math.Max(dp1, dp2);
        }

        /// <summary>
        /// [279] 完全平方数
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int NumSquares(int n)
        {
            int[] dp = new int[n + 1];
            dp[0] = 0;
            for (int i = 1; i <= n; i++)
            {
                dp[i] = n;
                for (int j = 1; j * j <= i; j++)
                {
                    dp[i] = Math.Min(dp[i], dp[i - j * j] + 1);
                }
            }
            return dp[n];
        }

        /// <summary>
        /// [300] 最长递增子序列
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int LengthOfLIS(int[] nums)
        {
            #region 双指针
            //var upNums = new List<int>
            //{
            //    nums[0]
            //};
            //for (int i = 1; i < nums.Length; i++)
            //{
            //    if (nums[i] > upNums[upNums.Count - 1])
            //    {
            //        upNums.Add(nums[i]);
            //    }
            //    else
            //    {
            //        var left = 0;
            //        var right = upNums.Count - 1;
            //        while (left < right)
            //        {
            //            var half = (left + right) / 2;
            //            if (upNums[half] < nums[i])
            //            {
            //                left = half + 1;
            //            }
            //            else
            //            {
            //                right = half;
            //            }
            //        }
            //        upNums[left] = nums[i];
            //    }
            //}
            //return upNums.Count();
            #endregion
            int n = nums.Length;
            if (n == 1) return 1;
            int[] dp = new int[n];
            for (int i = 0; i < n; i++)
            {
                dp[i] = 1;
            }
            int ans = 0;
            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    // 如果当前位置前面的数中存在比当前的数小的，就进行状态转移
                    if (nums[j] < nums[i])
                    {
                        dp[i] = Math.Max(dp[j] + 1, dp[i]);
                    }
                }
                ans = Math.Max(ans, dp[i]);
            }
            return ans;
        }

        /// <summary>
        /// [416] 分割等和子集
        /// dp[j]=dp[j] ∣ dp[j−nums[i]]
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public bool CanPartition(int[] nums)
        {
            int sum = nums.Sum(), maxNum = nums.Max();
            if (sum % 2 != 0 || maxNum * 2 > sum)
            {
                return false;
            }
            int n = nums.Length;
            int target = sum / 2;
            bool[] dp = new bool[target + 1];
            dp[0] = true;
            for (int i = 1; i <= n; i++)
            {
                for (int j = target; j >= nums[i - 1]; j--)
                {
                    dp[j] |= dp[j - nums[i - 1]];
                }
            }
            return dp[target];
        }

        /// <summary>
        /// [509] 斐波那契数
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int Fib(int n)
        {
            //dp[n] = dp[n - 1] + dp[n - 2]
            if (n == 0) return 0;
            if (n == 1) return 1;

            var dp = new int[n + 1];
            dp[0] = 0;
            dp[1] = 1;
            for (int i = 2; i <= n; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2];
            }
            return dp[n];
        }

        /// <summary>
        /// [712] 两个字符串的最小ASCII删除和
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        public int MinimumDeleteSum(string s1, string s2)
        {
            //i - s1 index
            //j - s2 index
            //dp[i][j] = min(dp[i−1][j]+s1[i−1],dp[i][j−1] + s2[j−1])
            var m = s1.Length;
            var n = s2.Length;
            var dp = new int[m + 1, n + 1];
            for (int i = 1; i <= m; i++)
            {
                dp[i, 0] = dp[i - 1, 0] + s1[i - 1];
            }
            for (int j = 1; j <= n; j++)
            {
                dp[0, j] = dp[0, j - 1] + s2[j - 1];
            }
            for (int i = 1; i <= m; i++)
            {
                int char1 = s1[i - 1];
                for (int j = 1; j <= n; j++)
                {
                    int char2 = s2[j - 1];
                    if (char1 == char2)
                    {
                        dp[i, j] = dp[i - 1, j - 1];
                    }
                    else
                    {
                        dp[i, j] = Math.Min(dp[i - 1, j] + char1, dp[i, j - 1] + char2);
                    }
                }
            }
            return dp[m, n];
        }

        /// <summary>
        /// [746] 使用最小花费爬楼梯
        /// </summary>
        /// <param name="cost"></param>
        /// <returns></returns>
        public int MinCostClimbingStairs(int[] cost)
        {
            //dp[0] = cost[0]
            //dp[1] = cost[1]
            //dp[i] = min(dp[i-1], dp[i-2]) + cost[i]
            var n = cost.Length;
            if (n == 2) return Math.Min(cost[0], cost[1]);
            var dp = new int[n];
            dp[0] = cost[0];
            dp[1] = cost[1];
            for (var i = 2; i < n; i++)
            {
                dp[i] = Math.Min(dp[i - 2], dp[i - 1]) + cost[i];
            }
            return Math.Min(dp[n - 2], dp[n - 1]);
        }

        /// <summary>
        /// [1039] 多边形三角剖分的最低得分
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public int MinScoreTriangulation(int[] values)
        {
            int INFINITY = int.MaxValue / 2;
            int n = values.Length;
            int[][] dp = new int[n][];
            for (int i = 0; i < n; i++)
            {
                dp[i] = new int[n];
            }
            for (int subLength = 3; subLength <= n; subLength++)
            {
                for (int i = 0, j = subLength - 1; j < n; i++, j++)
                {
                    int minScore = INFINITY;
                    for (int k = i + 1; k < j; k++)
                    {
                        int score = dp[i][k] + dp[k][j] + values[i] * values[k] * values[j];
                        minScore = Math.Min(minScore, score);
                    }
                    dp[i][j] = minScore;
                }
            }
            return dp[0][n - 1];
        }

        /// <summary>
        /// [1137] 第 N 个泰波那契数
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int Tribonacci(int n)
        {
            //dp[n] = dp[n-1] + dp[n-2] + dp[n-3]
            if (n == 0) return 0;
            if (n == 1) return 1;
            if (n == 2) return 1;
            var dp = new int[38];
            dp[0] = 0;
            dp[1] = 1;
            dp[2] = 1;
            for (int i = 3; i <= n; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2] + dp[i - 3];
            }
            return dp[n];
        }

        /// <summary>
        /// [1411] 给 N x 3 网格图涂色的方案数
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int NumOfWays(int n)
        {
            //i - row - 0 ~ n-1
            //j - type - 0 ~ 11
            //dp[0][k] = 1
            //0 - 010 - 4 5 6 8 9
            //1 - 012 - 4 6 7 9
            //2 - 020 - 4 5 8 9 10
            //3 - 021 - 5 8 10 11
            //4 - 101 - 0 1 2 10 11
            //5 - 102 - 0 2 3 11
            //6 - 121 - 0 1 8 10 11
            //7 - 120 - 1 8 9 10
            //8 - 202 - 0 2 3 6 7
            //9 - 201 - 0 1 2 7
            //10 - 212 - 2 3 4 6 7
            //11 - 210 - 3 4 5 6
            var res = new int[12] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
            var line = new int[12];
            for (int i = 1; i < n; i++)
            {
                line[0] = ((((res[4] + res[5]) % MOD + res[6]) % MOD + res[8]) % MOD + res[9]) % MOD;
                line[1] = (((res[4] + res[6]) % MOD + res[7]) % MOD + res[9]) % MOD;
                line[2] = ((((res[4] + res[5]) % MOD + res[8]) % MOD + res[9]) % MOD + res[10]) % MOD;
                line[3] = (((res[5] + res[8]) % MOD + res[10]) % MOD + res[11]) % MOD;
                line[4] = ((((res[0] + res[1]) % MOD + res[2]) % MOD + res[10]) % MOD + res[11]) % MOD;
                line[5] = (((res[0] + res[2]) % MOD + res[3]) % MOD + res[11]) % MOD;
                line[6] = ((((res[0] + res[1]) % MOD + res[8]) % MOD + res[10]) % MOD + res[11]) % MOD;
                line[7] = (((res[1] + res[8]) % MOD + res[9]) % MOD + res[10]) % MOD;
                line[8] = ((((res[0] + res[2]) % MOD + res[3]) % MOD + res[6]) % MOD + res[7]) % MOD;
                line[9] = (((res[0] + res[1]) % MOD + res[2]) % MOD + res[7]) % MOD;
                line[10] = ((((res[2] + res[3]) % MOD + res[4]) % MOD + res[6]) % MOD + res[7]) % MOD;
                line[11] = (((res[3] + res[4]) % MOD + res[5]) % MOD + res[6]) % MOD;
                res = line;
                line = new int[12];
            }
            var ans = 0;
            for (int i = 0; i < 12; i++)
            {
                ans = (ans + res[i]) % MOD;
            }
            return ans;
        }

        /// <summary>
        /// [1458] 两个子序列的最大点积
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public int MaxDotProduct(int[] nums1, int[] nums2)
        {
            //i - nums1 index
            //j - nums2 index
            //dp[i][j] = max(dp[i-1][j-1], dp[i-1][j-1] + nums1[i] * nums2[j])
            var n1 = nums1.Length;
            var n2 = nums2.Length;
            var dp = new int[n1, n2];
            var max = -1000000;
            for (int i = 0; i < n1; i++)
            {
                for (int j = 0; j < n2; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        dp[0, 0] = Math.Max(-1000000, nums1[i] * nums2[j]);
                        max = Math.Max(max, dp[i, j]);
                    }
                    else if (i == 0)
                    {
                        dp[0, j] = Math.Max(dp[0, j - 1], nums1[i] * nums2[j]);
                        max = Math.Max(max, dp[i, j]);
                    }
                    else if (j == 0)
                    {
                        dp[i, 0] = Math.Max(dp[i - 1, 0], nums1[i] * nums2[j]);
                        max = Math.Max(max, dp[i, j]);
                    }
                    else
                    {
                        dp[i, j] = Math.Max(Math.Max(dp[i, j - 1], dp[i - 1, j]), Math.Max(dp[i - 1, j - 1], Math.Max(dp[i - 1, j - 1] + nums1[i] * nums2[j], nums1[i] * nums2[j])));
                        max = Math.Max(max, dp[i, j]);
                    }
                }
            }
            return max;
        }

        /// <summary>
        /// [2435] 矩阵中和能被 K 整除的路径
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int NumberOfPaths(int[][] grid, int k)
        {
            //optimize：dpNew[j][x] = dpOld[j][x+grid[i][j]] + dpNew[j-1][x+grid[i][j]]
            var m = grid.Length;
            var n = grid[0].Length;
            var dpOld = new int[n][];
            var dpNew = new int[n][];

            for (int i = 0; i < m; i++)
            {
                if (i != 0)
                {
                    dpOld = dpNew;
                }
                dpNew = new int[n][];
                for (int j = 0; j < n; j++)
                {
                    dpNew[j] = new int[k];
                    if (i == 0 && j == 0)
                    {
                        var x = grid[0][0] % k;
                        dpNew[0][x] = 1;
                    }
                    if (j != 0)
                    {
                        for (int x = 0; x < k; x++)
                        {
                            if (dpNew[j - 1][x] == 0) continue;
                            int y = (x + grid[i][j]) % k;
                            dpNew[j][y] = (dpNew[j][y] + dpNew[j - 1][x]) % MOD;
                        }
                    }
                    if (i != 0)
                    {
                        for (int x = 0; x < k; x++)
                        {
                            if (dpOld[j][x] == 0) continue;
                            int y = (x + grid[i][j]) % k;
                            dpNew[j][y] = (dpNew[j][y] + dpOld[j][x]) % MOD;
                        }
                    }
                }
            }
            return dpNew[n - 1][0];

            //dp[i][j][x] = dp[i-1][j][x+grid[i][j]] + dp[i][j-1][x+grid[i][j]]
            //var m = grid.Length;
            //var n = grid[0].Length;
            //var dp = new int[m][][];
            //for(int i = 0; i < m; i++)
            //{
            //    dp[i] = new int[n][];
            //    for(int j = 0; j < n; j++)
            //    {
            //        dp[i][j] = new int[k];
            //        if(i == 0 && j == 0)
            //        {
            //            var x = grid[i][j] % k;
            //            dp[i][j][x] = 1;
            //        }
            //        if(i != 0)
            //        {
            //            for(int x = 0; x < k; x++)
            //            {
            //                if (dp[i - 1][j][x] == 0) continue;
            //                int y = (x + grid[i][j]) % k;
            //                dp[i][j][y] = (dp[i][j][y] + dp[i - 1][j][x]) % MOD;
            //            }
            //        }
            //        if (j != 0)
            //        {
            //            for (int x = 0; x < k; x++)
            //            {
            //                if (dp[i][j - 1][x] == 0) continue;
            //                int y = (x + grid[i][j]) % k;
            //                dp[i][j][y] = (dp[i][j][y] + dp[i][j - 1][x]) % MOD;
            //            }
            //        }
            //    }
            //}
            //return dp[m - 1][n - 1][0];
        }

        /// <summary>
        /// [3562] 折扣价交易股票的最大利润
        /// </summary>
        /// <param name="n"></param>
        /// <param name="present"></param>
        /// <param name="future"></param>
        /// <param name="hierarchy"></param>
        /// <param name="budget"></param>
        /// <returns></returns>
        public int MaxProfit(int n, int[] present, int[] future, int[][] hierarchy, int budget)
        {
            List<int>[] g = new List<int>[n];
            for (int i = 0; i < n; i++)
            {
                g[i] = new List<int>();
            }
            foreach (var e in hierarchy)
            {
                g[e[0] - 1].Add(e[1] - 1);
            }

            (int[] dp0, int[] dp1, int size) Dfs(int u)
            {
                int cost = present[u];
                int dCost = present[u] / 2; // discounted cost

                // dp[u][state][budget]
                // state = 0: 不购买父节点, state = 1: 必须购买父节点
                int[] dp0 = new int[budget + 1];
                int[] dp1 = new int[budget + 1];
                // subProfit[state][budget]
                // state = 0: 优惠不可用, state = 1: 优惠可用
                int[] subProfit0 = new int[budget + 1];
                int[] subProfit1 = new int[budget + 1];
                int uSize = cost;

                foreach (int v in g[u])
                {
                    var (childDp0, childDp1, vSize) = Dfs(v);
                    uSize += vSize;
                    for (int i = budget; i >= 0; i--)
                    {
                        for (int sub = 0; sub <= Math.Min(vSize, i); sub++)
                        {
                            if (i - sub >= 0)
                            {
                                subProfit0[i] = Math.Max(subProfit0[i], subProfit0[i - sub] + childDp0[sub]);
                                subProfit1[i] = Math.Max(subProfit1[i], subProfit1[i - sub] + childDp1[sub]);
                            }
                        }
                    }
                }

                for (int i = 0; i <= budget; i++)
                {
                    dp0[i] = subProfit0[i];
                    dp1[i] = subProfit0[i];
                    if (i >= dCost)
                    {
                        dp1[i] = Math.Max(subProfit0[i], subProfit1[i - dCost] + future[u] - dCost);
                    }
                    if (i >= cost)
                    {
                        dp0[i] = Math.Max(subProfit0[i], subProfit1[i - cost] + future[u] - cost);
                    }
                }

                return (dp0, dp1, uSize);
            }

            return Dfs(0).dp0[budget];
        }

        /// <summary>
        /// [3573] 买卖股票的最佳时机 V
        /// </summary>
        /// <param name="prices"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public long MaximumProfit(int[] prices, int k)
        {
            //dp[prices.Length][k+1][3]
            //i - 天数
            //j - 完成进行交易数
            //0 - 当前不持有股票，如果有交易，完成交易
            //1 - 当前持有普通交易的股票
            //2 - 当前持有做空交易的股票
            //状态转移：
            //dp[i][j][0] - 前一天没交易或卖出前一天的普通交易或买进前一天的做空交易: max(dp[i-1][j][0], dp[i-1][j][1]+prices[i], dp[i-1][j][2]-prices[i])
            //dp[i][j][1] - 保持前一天的普通交易或买进新的普通交易: max(dp[i-1][j][1], dp[i-1][j-1][0]-prices[i])
            //dp[i][j][2] - 保持前一天的做空交易或卖出新的做空交易: max(dp[i-1][j][2], dp[i-1][j-1][0]+prices[i])
            //优化：只需要i-1天的交易情况
            //dp[k+1][3]
            //dp[j][0] = max(dp[j][0], dp[j][1]+prices[i], dp[j][2]-prices[i])
            //dp[j][1] = max(dp[j][1], dp[j-1][0]-prices[i])
            //dp[j][2] = max(dp[j][2], dp[j-1][0]+prices[i])
            //初始i == 0：
            //dp[j][0] = 0
            //dp[j][1] = -prices[0]
            //dp[j][2] = prices[0]

            var n = prices.Length;
            var dp = new long[k + 1][];
            for (int j = 0; j <= k; j++)
            {
                dp[j] = [0, -prices[0], prices[0]];
            }

            for (int i = 1; i < n; i++)
            {
                //由于j的状态取决于[前一天]的j-1的状态，所以倒序遍历j，保证在计算j的时候j-1还是前一天的结果
                for (int j = k; j > 0; j--)
                {
                    dp[j][0] = Math.Max(dp[j][0], Math.Max(dp[j][1] + prices[i], dp[j][2] - prices[i]));
                    dp[j][1] = Math.Max(dp[j][1], dp[j - 1][0] - prices[i]);
                    dp[j][2] = Math.Max(dp[j][2], dp[j - 1][0] + prices[i]);
                }
            }
            return dp[k][0];
        }

        /// <summary>
        /// [3578] 统计极差最大为 K 的分割方式数
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int CountPartitions(int[] nums, int k)
        {
            int n = nums.Length;
            long mod = 1000000007L;
            long[] dp = new long[n + 1];
            long[] prefix = new long[n + 1];
            LinkedList<int> minQ = new LinkedList<int>();
            LinkedList<int> maxQ = new LinkedList<int>();

            dp[0] = 1;
            prefix[0] = 1;
            for (int i = 0, j = 0; i < n; i++)
            {
                // 维护最大值队列
                while (maxQ.Count > 0 && nums[maxQ.Last.Value] <= nums[i])
                {
                    maxQ.RemoveLast();
                }
                maxQ.AddLast(i);
                // 维护最小值队列
                while (minQ.Count > 0 && nums[minQ.Last.Value] >= nums[i])
                {
                    minQ.RemoveLast();
                }
                minQ.AddLast(i);
                // 调整窗口
                while (maxQ.Count > 0 && minQ.Count > 0 &&
                       nums[maxQ.First.Value] - nums[minQ.First.Value] > k)
                {
                    if (maxQ.First.Value == j)
                    {
                        maxQ.RemoveFirst();
                    }
                    if (minQ.First.Value == j)
                    {
                        minQ.RemoveFirst();
                    }
                    j++;
                }

                dp[i + 1] = (prefix[i] - (j > 0 ? prefix[j - 1] : 0) + mod) % mod;
                prefix[i + 1] = (prefix[i] + dp[i + 1]) % mod;
            }

            return (int)dp[n];
        }

        /// <summary>
        /// [799] 香槟塔
        /// </summary>
        /// <param name="poured"></param>
        /// <param name="query_row"></param>
        /// <param name="query_glass"></param>
        /// <returns></returns>
        public double ChampagneTower(int poured, int query_row, int query_glass)
        {
            //dp[i][j] = (dp[i - 1][j - 1] - 1) / 2 + (dp[i - 1][j] - 1) / 2
            var dp = new double[query_row + 1][];
            for (int i = 0; i <= query_row; i++)
            {
                dp[i] = new double[i + 1];
                if (i == 0)
                {
                    dp[i][0] = poured;
                }
                else
                {
                    dp[i][0] = GetHalf(dp[i - 1][0]);
                    for (int j = 1; j < i; j++)
                    {
                        dp[i][j] = GetHalf(dp[i - 1][j - 1]) + GetHalf(dp[i - 1][j]);
                    }
                    dp[i][i] = GetHalf(dp[i - 1][i - 1]);
                }
            }
            return dp[query_row][query_glass] >= 1 ? 1 : dp[query_row][query_glass];

            double GetHalf(double num)
            {
                if (num <= 1)
                {
                    return 0;
                }
                return (num - 1) / 2;
            }
        }

        /// <summary>
        /// [3129] 找出所有稳定的二进制数组 I
        /// </summary>
        /// <param name="zero"></param>
        /// <param name="one"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public int NumberOfStableArrays(int zero, int one, int limit)
        {
            int dfs(int i, int j, int k, int limit, int[][][] memo)
            {
                if (i == 0)
                {
                    // 递归边界
                    return k == 1 && j <= limit ? 1 : 0;
                }
                if (j == 0)
                {
                    // 递归边界
                    return k == 0 && i <= limit ? 1 : 0;
                }
                if (memo[i][j][k] != -1)
                {
                    // 之前计算过
                    return memo[i][j][k];
                }
                if (k == 0)
                {
                    // + MOD 保证答案非负
                    memo[i][j][k] = (int)(((long)dfs(i - 1, j, 0, limit, memo) + dfs(i - 1, j, 1, limit, memo) +
                            (i > limit ? MOD - dfs(i - limit - 1, j, 1, limit, memo) : 0)) % MOD);
                }
                else
                {
                    memo[i][j][k] = (int)(((long)dfs(i, j - 1, 0, limit, memo) + dfs(i, j - 1, 1, limit, memo) +
                            (j > limit ? MOD - dfs(i, j - limit - 1, 0, limit, memo) : 0)) % MOD);
                }
                return memo[i][j][k];
            }

            var memo = new int[zero + 1][][];
            for (var i = 0; i <= zero; i++)
            {
                memo[i] = new int[one + 1][];
                for (var j = 0; j <= one; j++)
                {
                    memo[i][j] = [-1, -1]; // -1 表示没有计算过
                }
            }
            return (dfs(zero, one, 0, limit, memo) + dfs(zero, one, 1, limit, memo)) % MOD;
        }
    }
}
