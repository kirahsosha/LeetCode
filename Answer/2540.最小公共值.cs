/*
 * @lc app=leetcode.cn id=2540 lang=csharp
 *
 * [2540] 最小公共值
 */

// @lc code=start
public class Solution
{
    public int GetCommon(int[] nums1, int[] nums2)
    {
        int i = 0;
        int j = 0;
        while (i < nums1.Length && j < nums2.Length)
        {
            if (nums1[i] == nums2[j])
            {
                return nums1[i];
            }
            if (nums1[i] < nums2[j])
            {
                i++;
            }
            else
            {
                j++;
            }
        }

        return -1;
    }
}
// @lc code=end
