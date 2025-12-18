using LeetCodeTester.Solutions;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeTester
{
    class Program
    {
        private static Solution solution = new Solution();
        static void Main(string[] args)
        {
            Test_2092();
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

    }

}
