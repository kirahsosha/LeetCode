using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LeetCodeTester.Solutions.MovieRentingSystem;

namespace LeetCodeTester.Solutions
{
    /// <summary>
    /// [2349] 设计数字容器系统
    /// </summary>
    public class NumberContainers
    {
        Dictionary<int, int> container;
        Dictionary<int, List<int>> numbers;

        public NumberContainers()
        {
            container = new Dictionary<int, int>();
            numbers = new Dictionary<int, List<int>>();
        }

        public void Change(int index, int number)
        {
            if (container.ContainsKey(index))
            {
                var oldValue = container[index];
                container[index] = number;
                numbers[oldValue].Remove(index);
            }
            else
            {
                container.Add(index, number);
            }
            if (numbers.ContainsKey(number))
            {
                numbers[number].Add(index);
            }
            else
            {
                numbers.Add(number, new List<int> { index });
            }
        }

        public int Find(int number)
        {
            if (!numbers.ContainsKey(number))
            {
                return -1;
            }
            else if(numbers[number].Count == 0)
            {
                return -1;
            }
            else
            {
                return numbers[number].Min();
            }
        }
    }

    /// <summary>
    /// [3408] 设计任务管理器
    /// </summary>
    public class TaskManager
    {
        private Dictionary<int, int[]> taskInfo;
        private PriorityQueue<int[], int[]> heap;

        public TaskManager(IList<IList<int>> tasks)
        {
            taskInfo = new Dictionary<int, int[]>();
            heap = new PriorityQueue<int[], int[]>(Comparer<int[]>.Create((a, b) =>
            {
                if (a[0] == b[0])
                {
                    return b[1].CompareTo(a[1]);
                }
                return b[0].CompareTo(a[0]);
            }));

            foreach (var task in tasks)
            {
                int userId = task[0], taskId = task[1], priority = task[2];
                taskInfo[taskId] = new int[] { priority, userId };
                heap.Enqueue(new int[] { priority, taskId }, new int[] { priority, taskId });
            }
        }

        public void Add(int userId, int taskId, int priority)
        {
            taskInfo[taskId] = new int[] { priority, userId };
            heap.Enqueue(new int[] { priority, taskId }, new int[] { priority, taskId });
        }

        public void Edit(int taskId, int newPriority)
        {
            if (taskInfo.ContainsKey(taskId))
            {
                taskInfo[taskId][0] = newPriority;
                heap.Enqueue(new int[] { newPriority, taskId }, new int[] { newPriority, taskId });
            }
        }

        public void Rmv(int taskId)
        {
            taskInfo.Remove(taskId);
        }

        public int ExecTop()
        {
            while (heap.Count > 0)
            {
                var task = heap.Dequeue();
                int priority = task[0], taskId = task[1];
                if (taskInfo.TryGetValue(taskId, out var info) && info[0] == priority)
                {
                    int userId = info[1];
                    taskInfo.Remove(taskId);
                    return userId;
                }
            }

            return -1;
        }
    }

    /// <summary>
    /// [3484] 设计电子表格
    /// </summary>
    public class Spreadsheet
    {
        int[][] sheets;
        public Spreadsheet(int rows)
        {
            sheets = new int[26][];
            for (int i = 0; i < 26; i++)
            {
                sheets[i] = new int[rows + 1];
            }
        }

        public void SetCell(string cell, int value)
        {
            var col = cell[0] - 'A';
            var row = int.Parse(cell.Substring(1));
            sheets[col][row] = value;
        }

        public void ResetCell(string cell)
        {
            var col = cell[0] - 'A';
            var row = int.Parse(cell.Substring(1));
            sheets[col][row] = 0;
        }

        public int GetValue(string formula)
        {
            var cell1 = formula.Substring(1).Split('+')[0];
            var cell2 = formula.Substring(1).Split('+')[1];

            int value1 = 0, value2 = 0;

            if(!int.TryParse(cell1, out value1))
            {
                var col = cell1[0] - 'A';
                var row = int.Parse(cell1.Substring(1));
                value1 = sheets[col][row];
            }
            if (!int.TryParse(cell2, out value2))
            {
                var col = cell2[0] - 'A';
                var row = int.Parse(cell2.Substring(1));
                value2 = sheets[col][row];
            }
            return value1 + value2;
        }
    }

    /// <summary>
    /// [3508] 设计路由器
    /// </summary>
    public class Router
    {
        private Queue<int[]> routes;
        private Dictionary<int, Dictionary<int, HashSet<int>>> packages;

        public Router(int memoryLimit)
        {
            routes = new Queue<int[]>(memoryLimit);
            packages = new Dictionary<int, Dictionary<int, HashSet<int>>>();
        }

        public bool AddPacket(int source, int destination, int timestamp)
        {
            //Check duplicate
            if (packages.ContainsKey(destination) && packages[destination].ContainsKey(source) && packages[destination][source].Contains(timestamp))
            {
                return false;
            }
            //Remove oldest if full
            if (routes.Count == routes.Capacity)
            {
                ForwardPacket();
            }
            //Enqueue
            routes.Enqueue(new int[] { source, destination, timestamp });
            //Add dictionary
            if (packages.ContainsKey(destination))
            {
                if (packages[destination].ContainsKey(source))
                {
                    packages[destination][source].Add(timestamp);
                }
                else
                {
                    packages[destination].Add(source, new HashSet<int>() { timestamp });
                }
            }
            else
            {
                packages.Add(destination, new Dictionary<int, HashSet<int>> { { source, new HashSet<int>() { timestamp } } });
            }
            return true;
        }

        public int[] ForwardPacket()
        {
            if(routes.Count == 0)
            {
                return new int[0];
            }
            var res = routes.Dequeue();
            packages[res[1]][res[0]].Remove(res[2]);
            if (packages[res[1]][res[0]].Count == 0)
            {
                packages[res[1]].Remove(res[0]);
            }
            if (packages[res[1]].Count == 0)
            {
                packages.Remove(res[1]);
            }
            return res;
        }

        public int GetCount(int destination, int startTime, int endTime)
        {
            if (!packages.ContainsKey(destination) || packages[destination].Count == 0)
            {
                return 0;
            }
            var count = 0;
            foreach (var list in packages[destination].Values)
            {
                count += list.Where(p => p >= startTime && p <= endTime).Count();
            }
            return count;
        }
    }

    /// <summary>
    /// [1912] 设计电影租借系统
    /// </summary>
    public class MovieRentingSystem
    {
        public class Movie
        {
            public int Shop { get; set; }

            public int MovieId { get; set; }

            public int Price { get; set; }

            public bool Rent { get; set; }
        }

        List<Movie> Movies = new List<Movie>();

        public MovieRentingSystem(int n, int[][] entries)
        {
            Movies = new List<Movie>();
            foreach (var entry in entries)
            {
                Movies.Add(new Movie
                {
                    Shop = entry[0],
                    MovieId = entry[1],
                    Price = entry[2],
                    Rent = false
                });
            }
        }

        public IList<int> Search(int movie)
        {
            var list = Movies.Where(p => p.Rent == false && p.MovieId == movie);
            if (list.Any())
            {
                return list.OrderBy(p => p.Price).ThenBy(p => p.Shop).Take(5).Select(p => p.Shop).ToList();
            }
            return new List<int>();
        }

        public void Rent(int shop, int movie)
        {
            Movies.Where(p => p.Shop == shop && p.MovieId == movie).ToList().ForEach(p => p.Rent = true);
        }

        public void Drop(int shop, int movie)
        {
            Movies.Where(p => p.Shop == shop && p.MovieId == movie).ToList().ForEach(p => p.Rent = false);
        }

        public IList<IList<int>> Report()
        {
            var res = new List<IList<int>>();
            var list = Movies.Where(p => p.Rent == true).ToList();
            if (list.Any())
            {
                list = list.OrderBy(p => p.Price).ThenBy(p => p.Shop).ThenBy(p => p.MovieId).Take(5).ToList();
                foreach(var movie in list)
                {
                    res.Add(new List<int> { movie.Shop, movie.MovieId });
                }
            }
            return res;
        }
    }

    /// <summary>
    /// [1622] 奇妙序列
    /// </summary>
    public class Fancy
    {
        private const int MOD = 1000000007;
        private List<int> value;
        private int a;
        private int b;

        public Fancy()
        {
            value = new List<int>();
            a = 1;
            b = 0;
        }

        public void Append(int val)
        {
            long adjustedVal = ((long)(val - b + MOD) % MOD) * Inv(a) % MOD;
            value.Add((int)adjustedVal);
        }

        public void AddAll(int inc)
        {
            b = (b + inc) % MOD;
        }

        public void MultAll(int m)
        {
            a = (int)((long)a * m % MOD);
            b = (int)((long)b * m % MOD);
        }

        public int GetIndex(int idx)
        {
            if (idx >= value.Count)
            {
                return -1;
            }
            int ans = (int)(((long)a * value[idx] % MOD + b) % MOD);
            return ans;
        }

        private int QuickMul(int x, int y)
        {
            long ret = 1;
            long cur = x;
            while (y != 0)
            {
                if ((y & 1) != 0)
                {
                    ret = ret * cur % MOD;
                }
                cur = cur * cur % MOD;
                y >>= 1;
            }
            return (int)ret;
        }

        // 乘法逆元
        private int Inv(int x)
        {
            return QuickMul(x, MOD - 2);
        }
    }

    /// <summary>
    /// [2069] 模拟行走机器人 II
    /// </summary>
    public class Robot
    {
        private readonly int width;
        private readonly int height;
        private readonly int perimeter;
        private int step;

        public Robot(int width, int height)
        {
            this.width = width;
            this.height = height;
            perimeter = (width + height - 2) * 2;
        }

        public void Step(int num)
        {
            step = (int)(((long)step + num - 1) % perimeter) + 1;
        }

        public int[] GetPos()
        {
            var state = GetState();
            return new int[] { state.x, state.y };
        }

        public string GetDir()
        {
            return GetState().dir;
        }

        private (int x, int y, string dir) GetState()
        {
            if (step < width)
            {
                return (step, 0, "East");
            }
            if (step < width + height - 1)
            {
                return (width - 1, step - width + 1, "North");
            }
            if (step < width * 2 + height - 2)
            {
                return (width * 2 + height - step - 3, height - 1, "West");
            }
            return (0, (width + height) * 2 - step - 4, "South");
        }
    }

}
