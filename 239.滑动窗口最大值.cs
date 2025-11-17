/*
 * @lc app=leetcode.cn id=239 lang=csharp
 *
 * [239] 滑动窗口最大值
 */

// @lc code=start
public class Solution
{
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
}
// @lc code=end

