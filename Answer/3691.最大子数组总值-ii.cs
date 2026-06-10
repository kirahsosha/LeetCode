/*
 * @lc app=leetcode.cn id=3691 lang=csharp
 *
 * [3691] 最大子数组总值 II
 */

// @lc code=start
using System.Numerics;

public class Solution
{
    public long MaxTotalValue(int[] nums, int k)
    {
        int n = nums.Length;

        // 1. Find global max and min
        int M = nums[0], mVal = nums[0];
        foreach (int v in nums)
        {
            if (v > M) M = v;
            if (v < mVal) mVal = v;
        }
        if (M == mVal) return 0;

        // 2. Sparse table for RMQ – flattened to 1D to reduce indirection
        int K = BitOperations.Log2((uint)n) + 1;
        int[] stMin = new int[K * n];
        Array.Copy(nums, stMin, n);
        for (int j = 1; j < K; j++)
        {
            int step = 1 << (j - 1);
            int rowOff = j * n, prevRow = (j - 1) * n;
            int limit = n - (1 << j) + 1;
            for (int i = 0; i < limit; i++)
                stMin[rowOff + i] = Math.Min(stMin[prevRow + i], stMin[prevRow + i + step]);
        }

        // 3. Monotonic stacks: range where each element is the MAXIMUM.
        //    prev: <= pop, next: < pop → assign each subarray to rightmost max.
        int[] prevG = new int[n];
        int[] nextG = new int[n];
        int[] stack = new int[n];
        int sp;

        sp = 0;
        for (int i = 0; i < n; i++)
        {
            prevG[i] = -1;
            while (sp > 0 && nums[stack[sp - 1]] <= nums[i]) sp--;
            if (sp > 0) prevG[i] = stack[sp - 1];
            stack[sp++] = i;
        }

        sp = 0;
        for (int i = n - 1; i >= 0; i--)
        {
            nextG[i] = n;
            while (sp > 0 && nums[stack[sp - 1]] < nums[i]) sp--;
            if (sp > 0) nextG[i] = stack[sp - 1];
            stack[sp++] = i;
        }

        // 4. PriorityQueue<TElement, TPriority> (min-heap; negate priority for max)
        var pq = new PriorityQueue<Entry, long>(k);
        var visited = new HashSet<int>(); // key = l * n + r

        // 5. Push initial candidate for every element as a potential maximum.
        for (int i = 0; i < n; i++)
        {
            int L = prevG[i] + 1;
            int R = nextG[i] - 1;
            // inline range-min for speed
            int len = R - L + 1;
            int j = BitOperations.Log2((uint)len);
            int minVal = Math.Min(stMin[j * n + L], stMin[j * n + R - (1 << j) + 1]);
            long val = (long)nums[i] - minVal;
            if (val > 0 && visited.Add(L * n + R))
                pq.Enqueue(new Entry(L, R, i, val), -val);
        }

        // 6. Pop top entries and generate shrink variants.
        long ans = 0;
        while (k > 0 && pq.Count > 0)
        {
            var e = pq.Dequeue();
            ans += e.Val;
            k--;

            // Shrink left
            if (e.L < e.Ref)
            {
                int nl = e.L + 1;
                int len = e.R - nl + 1;
                int j = BitOperations.Log2((uint)len);
                int minVal = Math.Min(stMin[j * n + nl], stMin[j * n + e.R - (1 << j) + 1]);
                long nv = (long)nums[e.Ref] - minVal;
                if (nv > 0 && visited.Add(nl * n + e.R))
                    pq.Enqueue(new Entry(nl, e.R, e.Ref, nv), -nv);
            }
            // Shrink right (keep Ref inside, avoid next >= value)
            if (e.R > e.Ref && e.R - 1 < nextG[e.Ref])
            {
                int nr = e.R - 1;
                int len = nr - e.L + 1;
                int j = BitOperations.Log2((uint)len);
                int minVal = Math.Min(stMin[j * n + e.L], stMin[j * n + nr - (1 << j) + 1]);
                long nv = (long)nums[e.Ref] - minVal;
                if (nv > 0 && visited.Add(e.L * n + nr))
                    pq.Enqueue(new Entry(e.L, nr, e.Ref, nv), -nv);
            }
        }

        return ans;
    }

    private readonly struct Entry
    {
        public readonly int L, R, Ref;
        public readonly long Val;

        public Entry(int l, int r, int refIdx, long val)
        {
            L = l; R = r; Ref = refIdx; Val = val;
        }
    }
}
// @lc code=end
