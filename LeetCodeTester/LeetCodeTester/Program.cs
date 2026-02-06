using LeetCodeTester.Solutions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeTester
{
    class Program
    {
        private static Solution solution = new Solution();
        static void Main(string[] args)
        {
            try
            {
                Test_3634();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void Test_OnlineTest()
        {
            var ans = solution.ParseCron("15 14 1 * *");
        }

        static void Test_443()
        {
            string[] strings = new string[] { "1", "aabbccc", "abbccc", "abbbbbbbbbbbbbbbbsssssssssaaaaaaaa",".d,m012,-0f90f2,........" };
            foreach(var s in strings)
            {
                var chars = s.ToArray();
                var ans = solution.Compress(chars);
                System.Console.WriteLine(ans.ToString());
                System.Console.WriteLine(chars);
            }
            
        }

        static void Test_457()
        {
            int[] nums = new int[] { 1, 2, 2, -1 };
            var ans = solution.CircularArrayLoop(nums);
            System.Console.WriteLine(ans.ToString());
        }

        static void Test_551()
        {
            string[] s = new string[]
            {
                "PPALLP",
                "PPALLL",
                "ALLPPPLLA",
                "ALLPPPA"
            };
            for (int i = 0; i < s.Length; i++)
            {
                var ans = solution.CheckRecord(s[i]);
                System.Console.WriteLine(ans.ToString());
            }

        }

        static void Test_552()
        {
            int[] nums = new int[]
            {
                2,
                1,
                10,
                100,
                10101
            };
            for (int i = 0; i < nums.Length; i++)
            {
                var ans = solution.CheckRecord(nums[i]);
                System.Console.WriteLine(ans.ToString());
            }

        }

        static void Test_576()
        {
            int[][] nums = new int[][]
            {
                new int[]{ 2, 2, 2, 0, 0 },
                new int[]{ 1, 3, 3, 0, 1 }
            };
            for(int i = 0; i < nums.Length; i++)
            {
                var ans = solution.FindPaths(nums[i][0], nums[i][1], nums[i][2], nums[i][3], nums[i][4]);
                System.Console.WriteLine(ans.ToString());
            }
            
        }

        static void Test_787()
        {
            int[][] nums = new int[][]
            {
                new int[]{ 4, 1, 1 },
                new int[]{ 1, 2, 3 },
                new int[]{ 0, 3, 2 },
                new int[]{ 0, 4, 10 },
                new int[]{ 3, 1, 1 },
                new int[]{ 1, 4, 3 }
            };
            var ans = solution.FindCheapestPrice(5, nums, 2, 1, 1);
            System.Console.WriteLine(ans.ToString());
        }

        static void Test_1337()
        {
            int[][] mat = new int[][]
            {
                new int[] { 1, 1, 0, 0, 0 },
                new int[] { 1, 1, 1, 1, 0 },
                new int[] { 1, 0, 0, 0, 0 },
                new int[] { 1, 1, 0, 0, 0 },
                new int[] { 1, 1, 1, 1, 1 }
            };
            int k = 3;
            var ans = solution.KWeakestRows(mat, k);
            System.Console.WriteLine("[" + string.Join(",", ans) + "]");
        }

        static void Test_49()
        {
            List<string[]> res = new List<string[]>
            {
                new string[]{ },
                new string[]{ ""},
                new string[]{ "a"}
            };
            foreach (var str in res)
            {
                var ans = solution.GroupAnagrams(str);
                System.Console.WriteLine("[" + string.Join(",", ans) + "]");
            }
        }

        static void Test_438()
        {
            var s = "cbaebabacd";
            var p = "abc";
            var ans = solution.FindAnagrams(s, p);
            System.Console.WriteLine("[" + string.Join(",", ans) + "]");
        }

        static void Test_2327()
        {
            var n = 6;
            var delay = 2;
            var forget = 4;
            var ans = solution.PeopleAwareOfSecret(n, delay, forget);
            System.Console.WriteLine("[" + string.Join(",", ans) + "]");
        }

        static void Test_31()
        {
            var nums = new int[] { 1, 3, 2 };
            solution.NextPermutation(nums);
            //System.Console.WriteLine("[" + string.Join(",", ans) + "]");
        }

        static void Test_108()
        {
            var nums = new int[] { 1, 2, 3, 4, 5 };
            var ans = solution.SortedArrayToBST(nums);
            System.Console.WriteLine("[" + string.Join(",", ans) + "]");
        }

        static void Test_73()
        {
            int[][] mat = new int[][]
            {
                new int[] { 0,1,2,0},
                new int[] { 3,4,5,2 },
                new int[] { 1, 3, 1, 5 }
            };
            solution.SetZeroes(mat);
        }

        static void Test_437()
        {
            var root = new TreeNode
            {
                val = 1000000000,
                left = new TreeNode
                {
                    val = 1000000000,
                    left = new TreeNode
                    {
                        val = 294967296,
                        left = new TreeNode
                        {
                            val = 1000000000,
                            left = new TreeNode
                            {
                                val = 1000000000,
                                left = new TreeNode
                                {
                                    val = 1000000000,
                                    left = null,
                                    right = null
                                },
                                right = null
                            },
                            right = null
                        },
                        right = null
                    },
                    right = null
                },
                right = null
            };
            var res = solution.PathSum(root, 0);
        }


        static void Test_994()
        {
            int[][] mat = new int[][]
            {
                new int[] { 2,1,1 },
                new int[] { 1,1,0 },
                new int[] { 0,1,1 }
            };
            int[][] mat2 = new int[][]
            {
                new int[] { 2,1,1 },
                new int[] { 0,1,1 },
                new int[] { 1,0,1 }
            };
            int[][] mat3 = new int[][]
            {
                new int[] { 0,2 }
            };
            var ans = solution.OrangesRotting(mat);
            ans = solution.OrangesRotting(mat2);
            ans = solution.OrangesRotting(mat3);
        }

        static void Test_3541()
        {
            var ans = solution.MaxFreqSum("aeiaeia");
        }

        static void Test_78()
        {
            var nums = new int[] { 1, 2, 3, 4, 5, 6 };
            var ans = solution.Subsets(nums);
        }


        static void Test_Q2()
        {
            var nums = new int[] {1,2,3,4,5};
            var ans = solution.SubsequenceSumAfterCapping(nums, 3);
        }

        static void Test_207()
        {
            int[][] prerequisites = new int[][]
            {
                new int[]{ 1, 0 },
                new int[]{ 0, 1 }
            };
            var ans = solution.CanFinish(2, prerequisites);
        }

        static void Test_17()
        {
            var ans = solution.LetterCombinations("");
            ans = solution.LetterCombinations("2");
            ans = solution.LetterCombinations("23");
            ans = solution.LetterCombinations("234");
            ans = solution.LetterCombinations("2345");
            ans = solution.LetterCombinations("2379");
        }

        static void Test_34()
        {
            int[] nums = new int[] { 1, 4 };
            var ans = solution.SearchRange(nums, 4);
        }

        static void Test_2197()
        {
            int[] nums = new int[] { 3, 4, 20, 8, 3, 7, 6, 14, 20, 16, 8, 5, 10, 14, 17, 20, 4, 4, 3, 5, 14, 15, 9, 2, 10, 20, 14, 14 };
            var ans = solution.ReplaceNonCoprimes(nums);
        }

        static void Test_279()
        {
            var ans = solution.NumSquares(48);
        }

        static void Test_39()
        {
            int[] nums = new int[] { 2, 3, 6, 7 };
            var ans = solution.CombinationSum(nums, 7);
        }

        static void Test_2349()
        {
            NumberContainers nc = new NumberContainers();
            var t1 = nc.Find(10); // 没有数字 10 ，所以返回 -1 。
            nc.Change(2, 10); // 容器中下标为 2 处填入数字 10 。
            nc.Change(1, 10); // 容器中下标为 1 处填入数字 10 。
            nc.Change(3, 10); // 容器中下标为 3 处填入数字 10 。
            nc.Change(5, 10); // 容器中下标为 5 处填入数字 10 。
            var t2 = nc.Find(10); // 数字 10 所在的下标为 1 ，2 ，3 和 5 。因为最小下标为 1 ，所以返回 1 。
            nc.Change(1, 20); // 容器中下标为 1 处填入数字 20 。注意，下标 1 处之前为 10 ，现在被替换为 20 。
            var t3 = nc.Find(10); // 数字 10 所在下标为 2 ，3 和 5 。最小下标为 2 ，所以返回 2 。
        }

        static void Test_3408()
        {
            var num = new List<IList<int>>
            {
                new List<int>
                {
                    1, 101, 10
                },
                new List<int>
                {
                    2, 102, 20
                },
                new List<int>
                {
                    3, 103, 15
                },
                new List<int>
                {
                    3, 110, 1
                },
            };
            TaskManager taskManager = new TaskManager(num); // 分别给用户 1 ，2 和 3 初始化一个任务。
            taskManager.Add(4, 104, 5); // 给用户 4 添加优先级为 5 的任务 104 。
            taskManager.Edit(102, 8); // 更新任务 102 的优先级为 8 。
            taskManager.ExecTop(); // 返回 3 。执行用户 3 的任务 103 。
            taskManager.Rmv(101); // 将系统中的任务 101 删除。
            taskManager.Add(5, 105, 15); // 给用户 5 添加优先级为 15 的任务 105 。
            taskManager.ExecTop(); // 返回 5 。执行用户 5 的任务 105 。
        }

        static void Test_3484()
        {
            Spreadsheet spreadsheet = new Spreadsheet(3); // 初始化一个具有 3 行和 26 列的电子表格
            spreadsheet.GetValue("=5+7"); // 返回 12 (5+7)
            spreadsheet.SetCell("A1", 10); // 设置 A1 为 10
            spreadsheet.GetValue("=A1+6"); // 返回 16 (10+6)
            spreadsheet.SetCell("B2", 15); // 设置 B2 为 15
            spreadsheet.GetValue("=A1+B2"); // 返回 25 (10+15)
            spreadsheet.ResetCell("A1"); // 重置 A1 为 0
            spreadsheet.GetValue("=A1+B2"); // 返回 15 (0+15)
        }

        static void Test_189()
        {
            int[] nums = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            solution.Rotate(nums, 3);
        }

        static void Test_3508()
        {
            //Router router = new Router(3); // 初始化路由器，内存限制为 3。
            //router.AddPacket(1, 4, 90); // 数据包被添加，返回 True。
            //router.AddPacket(2, 5, 90); // 数据包被添加，返回 True。
            //router.AddPacket(1, 4, 90); // 这是一个重复数据包，返回 False。
            //router.AddPacket(3, 5, 95); // 数据包被添加，返回 True。
            //router.AddPacket(4, 5, 105); // 数据包被添加，[1, 4, 90] 被移除，因为数据包数量超过限制，返回 True。
            //router.ForwardPacket(); // 转发数据包 [2, 5, 90] 并将其从路由器中移除。
            //router.AddPacket(5, 2, 110); // 数据包被添加，返回 True。
            //router.GetCount(5, 100, 110); // 唯一目标地址为 5 且时间在 [100, 110] 范围内的数据包是 [4, 5, 105]，返回 1。
            Router router = new Router(2);
            router.AddPacket(2, 5, 1);
            router.ForwardPacket();
            router.GetCount(5, 1, 1);
        }

        static void Test_139()
        {
            string[] list = new string[] { "a", "aa", "aaa", "aaaa", "aaaaa", "aaaaaa", "aaaaaaa", "aaaaaaaa", "aaaaaaaaa", "aaaaaaaaaa" };
            solution.WordBreak("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaab", list);
        }

        static void Test_239()
        {
            int[] nums = new int[] { 1, 3, -1, -3, 5, 3, 6, 7 };
            solution.MaxSlidingWindow(nums, 3);
        }

        static void Test_468_Q1()
        {
            int[] nums = new int[] { 1, 8, 16 };
            var res = solution.EvenNumberBitwiseORs(nums);
        }

        static void Test_468_Q4()
        {
            int[] nums = new int[] { 22 };
            var res = solution.MaxTotalValue2(nums, 1);
        }

        static void Test_120()
        {
            IList<IList<int>> t = new List<IList<int>>
            {
                new List<int>
                {
                    2
                },
                new List<int>
                {
                    3,4
                },
                new List<int>
                {
                    6,5,7
                },new List<int>
                {
                    4,1,8,3
                }
            };
            var res = solution.MinimumTotal(t);
        }

        static void Test_611()
        {
            var nums = new int[] { 4, 2, 3, 4 };
            var res = solution.TriangleNumber(nums);
        }


        static void Test_469_Q3()
        {
            var res = solution.ZigZagArrays(3, 4, 5);
        }

        static void Test_976()
        {
            var nums = new int[] { 1, 2, 1, 10 };
            var res = solution.LargestPerimeter(nums);
        }

        static void Test_128()
        {
            var nums = new int[] { 100, 4, 200, 1, 3, 2 };
            var res = solution.LongestConsecutive(nums);
        }

        static void Test_1039()
        {
            var nums = new int[] { 10, 30, 20, 40, 30, 50, 40, 60, 50, 70, 60, 80, 70, 90, 80, 10 };
            var res = solution.MinScoreTriangulation(nums);
        }

        static void Test_300()
        {
            var nums = new int[] { 3, 7, 4, 5 };
            var res = solution.LengthOfLIS(nums);
        }

        static void Test_347()
        {
            var nums = new int[] { 1, 1, 1, 2, 2, 3 };
            var res = solution.TopKFrequent(nums, 2);
        }

        static void Test_51()
        {
            var res = solution.SolveNQueens(9);
        }

        static void Test_41()
        {
            var nums = new int[] { 1, 2, 0 };
            var res = solution.FirstMissingPositive(nums);
        }

        static void Test_153()
        {
            var nums = new int[] { 5, 6, 7, 8, 1, 2, 3, 4 };
            var res = solution.FindMin(nums);
        }
        static void Test_416()
        {
            var nums = new int[] { 1, 2, 3 };
            var res = solution.CanPartition(nums);
        }


        static void Test_5()
        {
            var res = solution.LongestPalindrome("babad");
        }

        static void Test_3346()
        {
            var nums = new int[] { 30, 30, 37 };
            var res = solution.MaxFrequency(nums, 26, 1);
        }

        static void Test_3461()
        {
            var res = solution.HasSameDigits("3902");
        }

        static void Test_2257()
        {
            var guards = new int[][] { new int[] { 0, 0 }, new int[] { 1, 1 }, new int[] { 2, 3 } };
            var walls = new int[][] { new int[] { 0, 1 }, new int[] { 2, 2 }, new int[] { 1, 4 } };
            var res = solution.CountUnguarded(4, 6, guards, walls);
        }

        static void Test_1578()
        {
            var colors = "abaac";
            var neededTime = new int[] { 1, 2, 3, 4, 5 };
            var res = solution.MinCost(colors, neededTime);
        }

        static void Test_3318()
        {
            var nums = new int[] { 1, 1, 2, 2, 3, 4, 2, 3 };
            var res = solution.FindXSum(nums, 6, 2);
        }

        static void Test_3607()
        {
            //var connections = new int[][] { new int[] { 1, 2 }, new int[] { 2, 3 }, new int[] { 3, 4 }, new int[] { 4, 5 } };
            //var queries = new int[][] { new int[] { 1, 3 }, new int[] { 2, 1 }, new int[] { 1, 1 }, new int[] { 2, 2 }, new int[] { 1, 2 } };
            //var res = solution.ProcessQueries(5, connections, queries);
            //var connections = new int[][] { };
            //var queries = new int[][] { new int[] { 1, 1 }, new int[] { 2, 1 }, new int[] { 1, 1 } };
            //var res = solution.ProcessQueries(3, connections, queries);
            var connections = new int[][] { new int[] { 3, 4 }, new int[] { 2, 1 }, new int[] { 4, 2 }, new int[] { 3, 2 }, new int[] { 4, 1 } };
            var queries = new int[][] { new int[] { 2, 4 }, new int[] { 2, 1 }, new int[] { 2, 1 }, new int[] { 1, 3 }, new int[] { 1, 4 }, new int[] { 2, 2 }, new int[] { 1, 1 }, new int[] { 1, 4 }, new int[] { 2, 2 }, new int[] { 1, 4 }, new int[] { 1, 4 }, new int[] { 1, 4 }, new int[] { 1, 2 }, new int[] { 1, 2 }, new int[] { 2, 4 }, new int[] { 2, 2 }, new int[] { 2, 1 }, new int[] { 1, 4 }, new int[] { 2, 1 }, new int[] { 2, 4 }, new int[] { 2, 3 }, new int[] { 1, 1 }, new int[] { 2, 3 }, new int[] { 2, 4 }, new int[] { 1, 4 }, new int[] { 2, 2 }, new int[] { 1, 4 }, new int[] { 1, 1 }, new int[] { 2, 2 }, new int[] { 2, 3 }, new int[] { 2, 3 }, new int[] { 2, 3 }, new int[] { 1, 2 }, new int[] { 1, 3 }, new int[] { 1, 2 }, new int[] { 1, 2 }, new int[] { 2, 2 }, new int[] { 1, 2 }, new int[] { 1, 2 }, new int[] { 1, 3 }, new int[] { 1, 4 } };
            var res = solution.ProcessQueries(4, connections, queries);
        }

        static void Test_2528()
        {
            var stations = new int[] { 4, 2 };
            var res = solution.MaxPower(stations, 1, 1);
        }

        static void Test_2654()
        {
            var nums = new int[] { 6, 10, 15 };
            var res = solution.MinOperations(nums);
        }

        static void Test_3228()
        {
            var res = solution.MaxOperations("00111");
        }

        static void Test_2536()
        {
            var query = new int[][] { new int[] { 1, 1, 2, 2 }, new int[] { 0, 0, 1, 1 } };
            var res = solution.RangeAddQueries(3, query);
        }

        static void Test_1513()
        {
            var res = solution.NumSub("11100111");
        }

        static void Test_1437()
        {
            var nums = new int[] { 0, 1, 0, 1 };
            var res = solution.KLengthApart(nums, 1);
        }

        static void Test_2154()
        {
            var nums = new int[] { 5, 3, 6, 1, 12 };
            var res = solution.FindFinalValue(nums, 3);
        }

        static void Test_1930()
        {
            var res = solution.CountPalindromicSubsequence("bbcbaba");
        }

        static void Test_1262()
        {
            var nums = new int[] { 1, 2, 3, 4, 4 };
            var res = solution.MaxSumDivThree(nums);
        }

        static void Test_1018()
        {
            var nums = new int[] { 1, 0, 0, 1, 0, 1, 0, 0, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 1, 0, 1, 0, 0, 0, 1 };
            var res = solution.PrefixesDivBy5(nums);
        }

        static void Test_1015()
        {
            var res = solution.SmallestRepunitDivByK(3);
        }


        static void Test_2435()
        {
            var grid = new int[][] { new int[] { 5, 2, 4 }, new int[] { 3, 0, 5 }, new int[] { 0, 7, 2 } };
            var res = solution.NumberOfPaths(grid, 3);
        }

        static void Test_3381()
        {
            var nums = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, -1, -2, -3, -4, -5, -6, -7, -8, -9, -10 };
            var res = solution.MaxSubarraySum(nums, 5);
        }

        static void Test_2872()
        {
            //var n = 5;
            //var edges = new int[][] { new int[] { 0, 2 }, new int[] { 1, 2 }, new int[] { 1, 3 }, new int[] { 2, 4 } };
            //var values = new int[] { 1, 8, 1, 4, 4 };
            //var k = 6;
            var n = 1;
            var edges = new int[][] {};
            var values = new int[] { 0 };
            var k = 1;
            var res = solution.MaxKDivisibleComponents(n, edges, values, k);
        }

        static void Test_478Q3()
        {
            var nums = new int[] { 12, 21, 45, 33, 54 };
            var res = solution.MinMirrorPairDistance(nums);
        }

        static void Test_478Q4()
        {
            var nums = new int[] { 1, 4, 7 };
            var k = 3;
            var queries = new int[][] { new int[] { 0, 1 }, new int[] { 0, 2 } };
            var res = solution.MinOperations(nums, k, queries);
        }

        static void Test_1590()
        {
            var nums = new int[] { 6, 3, 5, 2 };
            var res = solution.MinSubarray(nums, 9);
        }

        static void Test_2141()
        {
            var nums = new int[] { 3, 3, 3 };
            var res = solution.MaxRunTime(2, nums);
        }

        static void Test_3623()
        {
            var points = new int[][] { new int[] { 1, 0 }, new int[] { 2, 0 }, new int[] { 3, 0 }, new int[] { 2, 2 }, new int[] { 3, 2 }, new int[] { 2, 3 }, new int[] { 3, 3 } };
            var res = solution.CountTrapezoids(points);
        }

        static void Test_2211()
        {
            var res = solution.CountCollisions("LLRRLLRRSSLLRRLL");
        }

        static void Test_179()
        {
            var nums = new int[] { 0, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            var res = solution.LargestNumber(nums);
        }

        static void Test_3578()
        {
            var nums = new int[] { 9, 4, 1, 3, 7 };
            var k = 4;
            var res = solution.CountPartitions(nums, k);
        }

        static void Test_1925()
        {
            var k = 20;
            var res = solution.CountTriples(k);
        }

        static void Test_3583()
        {
            var nums = new int[] { };
            var res = solution.SpecialTriplets(nums);
        }

        static void Test_3577()
        {
            var complexity = new int[] { 38, 223, 100, 123, 406, 234, 256, 93, 222, 259, 233, 69, 139, 245, 45, 98, 214 };
            var res = solution.CountPermutations(complexity);
        }

        static void Test_3531()
        {
            var n = 3;
            var buildings = JsonConvert.DeserializeObject<int[][]>("[[1,1],[1,2],[2,1],[2,2]]");
            var res = solution.CountCoveredBuildings(n, buildings);
        }

        static void Test_3433()
        {
            var numberOfUsers = 10;
            var events = JsonConvert.DeserializeObject<List<IList<string>>>("[[\"OFFLINE\",\"44\",\"5\"],[\"MESSAGE\",\"98\",\"HERE\"],[\"OFFLINE\",\"78\",\"0\"]]");
            var res = solution.CountMentions(numberOfUsers, events);
        }

        static void Test_3606()
        {
            var code = new string[] { "P", "j", "x", "c", "j", "C", "G" };
            var businessLine = new string[] { "pharmacy", "electronics", "invalid", "restaurant", "electronics", "pharmacy", "restaurant" };
            var isActive = new bool[] { true, true, false, false, true, false, false };
            var res = solution.ValidateCoupons(code, businessLine, isActive);
        }

        static void Test_2147()
        {
            var corridor = "PPPPPPPSPPPSPPPPSPPPSPPPPPSPPPSPPSPPSPPPPPSPSPPPPPSPPSPPPPPSPPSPPSPPPSPPPPSPPPPSPPPPPSPSPPPPSPSPPPSPPPPSPPPPPSPSPPSPPPPSPPSPPSPPSPPPSPPSPSPPSSSS";
            var res = solution.NumberOfWays(corridor);
        }

        static void Test_2110()
        {
            //var prices = new int[] { 3, 2, 1, 4 };
            var prices = new int[100000];
            for (int i = 0; i < prices.Length; i++)
            {
                prices[i] = 100000 - i;
            }
            var res = solution.GetDescentPeriods(prices);
        }

        static void Test_3562()
        {
            var n = 3;
            var present = new int[] { 4, 6, 8 };
            var future = new int[] { 7, 9, 11 };
            var hierarchy = JsonConvert.DeserializeObject<int[][]>("[[1,2],[1,3]]");
            var budget = 10;
            var res = solution.MaxProfit(n, present, future, hierarchy, budget);
        }

        static void Test_3573()
        {
            var prices = new int[] { 1, 7, 9, 8, 2 };
            var res = solution.MaximumProfit(prices, 2);
        }

        static void Test_3652()
        {
            var prices = new int[] { 4, 2, 8 };
            var strategy = new int[] { -1, 0, 1 };
            var res = solution.MaxProfit(prices, strategy,2);
        }

        static void Test_2092()
        {
            var n = 6;
            var meetings = JsonConvert.DeserializeObject<int[][]>("[[0,2,1],[1,3,1],[4,5,1]]");
            var firstPerson = 1;
            var res = solution.FindAllPeople(n, meetings, firstPerson);
        }

        static void Test_944()
        {
            var strs = JsonConvert.DeserializeObject<string[]>("[\"cba\",\"daf\",\"ghi\"]");
            var res = solution.MinDeletionSize(strs);
        }

        static void Test_955()
        {
            var strs = JsonConvert.DeserializeObject<string[]>("[\"xga\",\"xfb\",\"yfa\"]");
            var res = solution.MinDeletionSize2(strs);
        }

        static void Test_2054()
        {
            var events = JsonConvert.DeserializeObject<int[][]>("");
            var res = solution.MaxTwoEvents(events);
        }

        static void Test_3074()
        {
            var apple = new int[] { 1, 3, 2 };
            var capacity = new int[] { 4, 3, 1, 5, 2 };
            var res = solution.MinimumBoxes(apple, capacity);
        }

        static void Test_3075()
        {
            var happiness = new int[] { 1, 2, 3 };
            var res = solution.MaximumHappinessSum(happiness, 2);
        }

        static void Test_2483()
        {
            var customers = "YYNY";
            var res = solution.BestClosingTime(customers);
        }

        static void Test_2402()
        {
            var meetings = JsonConvert.DeserializeObject<int[][]>("[[1,20],[2,10],[3,5],[4,9],[6,8]]");
            var res = solution.MostBooked(4, meetings);
        }

        static void Test_1351()
        {
            var grid = JsonConvert.DeserializeObject<int[][]>("[[4,3,2,-1],[3,2,1,-1],[1,1,-1,-2],[-1,-1,-2,-3]]");
            var res = solution.CountNegatives(grid);
        }

        static void Test_756()
        {
            var bottom = "AAAA";
            var allowed = JsonConvert.DeserializeObject<List<string>>("[\"AAB\",\"AAC\",\"BCD\",\"BBE\",\"DEF\"]");
            var res = solution.PyramidTransition(bottom, allowed);
        }

        static void Test_840()
        {
            var grid = JsonConvert.DeserializeObject<int[][]>("[[4,3,8,4],[9,5,1,9],[2,7,6,2]]");
            var res = solution.NumMagicSquaresInside(grid);
        }

        static void Test_66()
        {
            var digits = JsonConvert.DeserializeObject<int[]>("[2,0,2,5]");
            var res = solution.PlusOne(digits);
        }

        static void Test_961()
        {
            var nums = JsonConvert.DeserializeObject<int[]>("[5,1,5,2,5,3,5,4]");
            var res = solution.RepeatedNTimes(nums);
        }

        static void Test_1411()
        {
            var res = solution.NumOfWays(3);
        }

        static void Test_1390()
        {
            var nums = JsonConvert.DeserializeObject<int[]>("[21,4,7]");
            var res = solution.SumFourDivisors(nums);
        }

        static void Test_1975()
        {
            var matrix = JsonConvert.DeserializeObject<int[][]>("[[-10000,-10000,-10000],[-10000,-10000,-10000],[-10000,-10000,-10000]]");
            var res = solution.MaxMatrixSum(matrix);
        }

        static void Test_1161()
        {
            var root = TreeNode.CreateTreeNode("[989,null,10250,98693,-89388,null,null,null,-32127]");
            var res = solution.MaxLevelSum(root);
        }

        static void Test_1339()
        {
            var root = TreeNode.CreateTreeNode("[989,null,10250,98693,-89388,null,null,null,-32127]");
            var res = solution.MaxProduct(root);
        }

        static void Test_1458()
        {
            var nums1 = JsonConvert.DeserializeObject<int[]>("[-3,-8,3,-10,1,3,9]");
            var nums2 = JsonConvert.DeserializeObject<int[]>("[9,2,3,7,-9,1,-8,5,-1,-1]");
            var res = solution.MaxDotProduct(nums1, nums2);
        }

        static void Test_865()
        {
            var root = TreeNode.CreateTreeNode("[3,5,1,6,2,0,8,null,null,7,4]");
            var res = solution.SubtreeWithAllDeepest(root);
        }

        static void Test_712()
        {
            var s1 = "delete";
            var s2 = "leet";
            var res = solution.MinimumDeleteSum(s1, s2);
        }

        static void Test_85()
        {
            var matrix = JsonConvert.DeserializeObject<char[][]>("[[\"1\",\"0\",\"1\",\"0\",\"0\"],[\"1\",\"0\",\"1\",\"1\",\"1\"],[\"1\",\"1\",\"1\",\"1\",\"1\"],[\"1\",\"0\",\"0\",\"1\",\"0\"]]");
            var res = solution.MaximalRectangle(matrix);
        }

        static void Test_1266()
        {
            var points = JsonConvert.DeserializeObject<int[][]>("[[1,1],[3,4],[-1,0]]");
            var res = solution.MinTimeToVisitAllPoints(points);
        }

        static void Test_3453()
        {
            var squares = JsonConvert.DeserializeObject<int[][]>("[[522261215,954313664,225462]]");
            var res = solution.SeparateSquares1(squares);
        }

        static void Test_3454()
        {
            var squares = JsonConvert.DeserializeObject<int[][]>("[[522261215,954313664,225462]]");
            var res = solution.SeparateSquares(squares);
        }

        static void Test_2943()
        {
            int n = 14;
            int m = 4;
            int[] hBars = [13];
            int[] vBars = [3, 4, 5, 2];
            var res = solution.MaximizeSquareHoleArea(n, m, hBars, vBars);
        }

        static void Test_2975()
        {
            int n = 6;
            int m = 7;
            int[] hFences = [2];
            int[] vFences = [4];
            var res = solution.MaximizeSquareArea(n, m, hFences, vFences);
        }

        static void Test_1292()
        {
            var mat = JsonConvert.DeserializeObject<int[][]>("[[1,1,3,2,4,3,2],[1,1,3,2,4,3,2],[1,1,3,2,4,3,2]]");
            var threshold = 4;
            var res = solution.MaxSideLength(mat, threshold);
        }

        static void Test_3314()
        {
            var nums = JsonConvert.DeserializeObject<List<int>>("[2,3,5,7]");
            var res = solution.MinBitwiseArray1(nums);
        }

        static void Test_3315()
        {
            var nums = JsonConvert.DeserializeObject<List<int>>("[2,3,5,7]");
            var res = solution.MinBitwiseArray(nums);
        }

        static void Test_3507()
        {
            var nums = JsonConvert.DeserializeObject<int[]>("[5,2,3,1]");
            var res = solution.MinimumPairRemoval(nums);
        }

        static void Test_1877()
        {
            var nums = JsonConvert.DeserializeObject<int[]>("[3,5,4,2,4,6]");
            var res = solution.MinPairSum(nums);
        }

        static void Test_1984()
        {
            var nums = JsonConvert.DeserializeObject<int[]>("[9,4,1,7]");
            var k = 2;
            var res = solution.MinimumDifference(nums, k);
        }

        static void Test_1200()
        {
            var nums = JsonConvert.DeserializeObject<int[]>("[3,8,-10,23,19,-4,-14,27]");
            var res = solution.MinimumAbsDifference(nums);
        }

        static void Test_3650()
        {
            var n = 4;
            var edges = JsonConvert.DeserializeObject<int[][]>("[[0,1,3],[3,1,1],[2,3,4],[0,2,2]]");
            var res = solution.MinCost(n, edges);
        }

        static void Test_744()
        {
            var letters = JsonConvert.DeserializeObject<char[]>("['c', 'f', 'j']");
            var target = 'a';
            var res = solution.NextGreatestLetter(letters, target);
        }

        static void Test_3010()
        {
            var nums = JsonConvert.DeserializeObject<int[]>("[10,3,1,1]");
            var res = solution.MinimumCost(nums);
        }

        static void Test_3634()
        {
            var nums = JsonConvert.DeserializeObject<int[]>("[14944951,1742869,51757761,56774136,6521521,48397767,68559884,39275741,2750064,42399816,11892612,12348969,14033347,66379882,45864587,36629395,7761382,50885244,12287057,31492634,10390356,52286292,69149378,15836909,26121306,33387576,63727750,16701018,23950991,68419134,1356664,51018056,5616654,16680553,36200484,26750062,15030011,51537522,7270369,63163229,19125812,38318788,9196435,36920470,17948650,962208,60113732,1392807,27127557,42103402,57812806,63502302,62896337,56580232,50124188,63486144,6905169,60223348,151382,62519772,8419426,50118129,47252331,16867705,8420914,11309745,16536243,60402892,9833954,7341930,3413794,50243767,23203427,10415178,35080390,12111948,37289690,39599679,686691,45239012,19790425,54795861,20748936,39510235,28582219,25706135,57035207,59352272,59536690,32652604,53928053,50289823,350301,2314057,25171684,32453197,62314215,48612306,8843347,48293916,12701489,17605493,66572696,30527464,51567675,32023125,9922817,1038249,27135268,7169082,56525589,25156534,68716524,15700625,15798265,60581536,49430662,4813374,13844105,61825166,40120317,38272264,6117004,9326221,457900,20976724,45454235,60747060,23398279,43153223,4290373,29787727,28176035,41310995,49258994,28267469,57591667,39195350,29927613,1670536,16323422,47382424,18526840,50089907,816034,47949885,21978403,18180216,21037050,29418646,31193736,67672882,7452293,9656558,37885215,50138863,50978640,33181807,27442193,59477446,35196830,29769410,41552742,36541038,7697696,44454991,55830879,46336872,54836624,16274898,57582477,8390360,34939466,63100744,18515544,13448056,24888528,35943434,24214880,20981957,9817510,58795727,55738223,31268329,9825436,17984979,12492910,55417095,48890778,32388741,28776169,12385250,18656766,29672990,22314935,30905148,27164025,51805522,56492770,67306704,1387308,29404048,9822659,20997688,34365488,23891809,19317096,39340469,22929688,18191558,29226588,51392327,20267674,46875804,54060725,7816179,47318222,38356336,5771462,2368284,15674636,62083715,5903167,43494281,54100401,42340181,67961232,56777611,20135844,55785517,64506993,33737040,8148559,3883984,45243873,46259623,41690641,41499108,51410848,52141013,18681887,59803570,36609425,52748330,20588200,42365220,25287839,5570553,48158764,36083552,36203419,44725039,31056972,30697776,62179702,54860996,36059255,24932947,47066993,11807000,21114938,38367324,42099798,49069735,66291601,5346890,2746052,64040319,2880303,1319560,9438485,45449744,6970885,29583941,63672007,43189672,8766422,40811107,50054166,7579172,7360266,68548080,9260436,57973565,54510959,4353243,25944447,16698606,68257893,42081146,16144711,50786442,29915710,61077328,37004661,26570766,6072995,18683491,5468059,63511604,38911275,58581338,33497973,54333831,13968338,24066328,17125053,142683,20520509,51078736,19824369,68705948,11216193,33085317,62872557,56680018,67355513,25202304,64309840,17981696,53635773,31047038,63838318,13798018,46502162,36352744,17330942,13293205,29454716,35694903,29538910,66445813,17122641,39554444,5413326,59891422,58825468,60254628,831788,485806,46990108,42119593,20969852,62898953,4798081,6615504,61158375,1809715,68404318,44266350,14796538,16295034,1066349,7835823,63694088,36311047,40827754,43278523,26229005,49960669,24346644,57577813,45914256,6622405,42747864,13863064,20974392,12911194,39889447,36975316,59436393,21587318,52555839,1365305,66308944,44269066,19099637,18326320,52513999,42743675,1908838,10572053,48190929,41097613,53227218,46626718,59437561,9124665,66241348,49259046,26457691,28277292,56878884,2861052,43075847,41283452,43017519,9701321,14870415,14021650,33580000,51505866,29390222,69535578,5153655,5567396,8725802,37588575,38783267,66641944,7989732,1430956]");
            var k = 84298;
            var res = solution.MinRemoval(nums, k);
        }
    }
}
