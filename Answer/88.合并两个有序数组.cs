/*
 * @lc app=leetcode.cn id=88 lang=csharp
 *
 * [88] 合并两个有序数组
 */

// @lc code=start
public class Solution {
    public void Merge(int[] nums1, int m, int[] nums2, int n) {
        if (n == 0) return;
        if (m == 0)
        {
            nums2.CopyTo(nums1, 0);
            return;
        }
        int p1 = 0, p2 = 0;
        Queue<int> nums3 = new Queue<int>();
        while (p1 < m && p2 < n)
        {
            nums3.Enqueue(nums1[p1]);
            int t = nums3.Peek();
            if(t < nums2[p2])
            {
                nums1[p1++] = t;
                nums3.Dequeue();
            }
            else
            {
                nums1[p1++] = nums2[p2++];
            }
        }
        //如果p1 < m, p2一定为n, nums3有值
        //将nums1剩下的值入队nums, 并用nums3的值出队填入nums1
        //循环结束后, p1 == m, p2 == n, nums3有值
        while (p1 < m)
        {
            nums3.Enqueue(nums1[p1]);
            nums1[p1++] = nums3.Dequeue();
        }
        //如果p2 < n, p1一定为m, num3可能有值
        //循环取nums2和nums3的最小值, 直到p2 == n
        //循环结束后, p1 > m, p2 == n, nums3可能有值
        while (p2 < n)
        {
            if(nums3.Count != 0)
            {
                int t = nums3.Peek();
                if(t < nums2[p2])
                {
                    nums1[p1++] = t;
                    nums3.Dequeue();
                }
                else
                {
                    nums1[p1++] = nums2[p2++];
                }
            }
            else
            {
                nums1[p1++] = nums2[p2++];
            }
        }
        //此时p1 >= m, p2 == n, nums3可能有值
        //将nums3剩下的值赋值到nums1
        nums3.CopyTo(nums1, p1);
        return;
    }
}
// @lc code=end

