/*
 * @lc app=leetcode.cn id=1713 lang=csharp
 *
 * [1713] 得到子序列的最少操作次数
 */

// @lc code=start
public class Solution {
    public int MinOperations(int[] target, int[] arr)
        {
            int n = target.Length;
            int i = 0;
            Dictionary<int, int> pos = target.ToDictionary(p => p, p => i++);
            List<int> d = new List<int>();
            foreach (int val in arr)
            {
                if (pos.ContainsKey(val))
                {
                    int idx = pos[val];
                    int it = BinarySearch(d, idx);
                    if (it != d.Count)
                    {
                        d[it] = idx;
                    }
                    else
                    {
                        d.Add(idx);
                    }
                }
            }
            return n - d.Count;
        }

        public int BinarySearch(List<int> d, int target)
        {
            int size = d.Count;
            if (size == 0 || d[size - 1] < target)
            {
                return size;
            }
            int low = 0, high = size - 1;
            while (low < high)
            {
                int mid = (high - low) / 2 + low;
                if (d[mid] < target)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid;
                }
            }
            return low;
        }
}
// @lc code=end

