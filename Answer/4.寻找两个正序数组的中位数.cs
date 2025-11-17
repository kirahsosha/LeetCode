/*
 * @lc app=leetcode.cn id=4 lang=csharp
 *
 * [4] 寻找两个正序数组的中位数
 */

// @lc code=start
public class Solution
{
    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        int m = nums1.Length;
        int n = nums2.Length;
        int p1 = 0;
        int p2 = 0;
        IList<int> list = new List<int>();
        var mid = (m + n) / 2;
        while (p1 + p2 <= mid)
        {
            if (p1 == m)
            {
                list.Add(nums2[p2++]);
            }
            else if (p2 == n)
            {
                list.Add(nums1[p1++]);
            }
            else
            {
                if (nums1[p1] < nums2[p2])
                {
                    list.Add(nums1[p1++]);
                }
                else
                {
                    list.Add(nums2[p2++]);
                }
            }
        }
        if ((m + n) % 2 == 0)
        {
            return (double)(list[mid] + list[mid - 1]) / 2.0;
        }
        else
        {
            return (double)list[mid];
        }
    }
}
// @lc code=end

