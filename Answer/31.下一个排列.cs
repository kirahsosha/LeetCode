/*
 * @lc app=leetcode.cn id=31 lang=csharp
 *
 * [31] 下一个排列
 */

// @lc code=start
public class Solution
{
    public void NextPermutation(int[] nums)
    {
        if (nums.Length == 1) return;
        int i = nums.Length - 2;
        int j = nums.Length - 1;
        int k = nums.Length - 1;

        // find: A[i] < A[j]
        while (i >= 0 && nums[i] >= nums[j])
        {
            i--;
            j--;
        }

        if (i >= 0)
        {
            // 不是最后一个排列
            // find: A[i] < A[k]
            while (nums[i] >= nums[k])
            {
                k--;
            }
            // swap A[i], A[k]
            var t = nums[i];
            nums[i] = nums[k];
            nums[k] = t;
        }

        // reverse A[j:end]
        int left = j, right = nums.Length - 1;
        Reverse(nums, left, right);
    }

    private void Reverse(int[] nums, int left, int right)
    {
        while (left < right)
        {
            int temp = nums[left];
            nums[left] = nums[right];
            nums[right] = temp;
            left++;
            right--;
        }
    }
}
// @lc code=end

