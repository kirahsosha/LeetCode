/*
 * @lc app=leetcode.cn id=912 lang=csharp
 *
 * [912] 排序数组
 */

// @lc code=start
public class Solution {
    public int[] mergeSort(int[] nums, int l, int r)
    {
        if(l >= r) return nums;
        nums = mergeSort(nums, l, (l + r) / 2);
        nums = mergeSort(nums, (l + r) / 2 + 1, r);
        int[] tmp = new int[r - l + 1];
        int i = l, j = (l + r) / 2 + 1, k = 0;
        while(i <= (l + r) / 2 && j <= r)
        {
            if(nums[i] <= nums[j])
            {
                tmp[k++] = nums[i++];
            }
            else
            {
                tmp[k++] = nums[j++];
            }
        }
        while(i<=(l + r) / 2)
        {
            tmp[k++] = nums[i++];
        }
        while(j <= r)
        {
            tmp[k++] = nums[j++];
        }
        for(int m = 0; m < r - l + 1; m++)
        {
            nums[m + l] = tmp[m];
        }
        return nums;
    }

    public int[] SortArray(int[] nums) {
        if (nums.Length == 1) return nums;
        return mergeSort(nums, 0, nums.Length - 1);
    }
}
// @lc code=end

