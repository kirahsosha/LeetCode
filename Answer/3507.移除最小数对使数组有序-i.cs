/*
 * @lc app=leetcode.cn id=3507 lang=csharp
 *
 * [3507] 移除最小数对使数组有序 I
 */

// @lc code=start
public class Solution
{
    public int MinimumPairRemoval(int[] nums)
    {
        var times = 0;
        while (!Check())
        {
            var index = GetMin();
            nums = Replace(index);
            times++;
        }
        return times;

        int GetMin()
        {
            var res = nums[0] + nums[1];
            var index = 0;
            for (int i = 1; i < nums.Length - 1; i++)
            {
                if (nums[i] + nums[i + 1] < res)
                {
                    res = nums[i] + nums[i + 1];
                    index = i;
                }
            }
            return index;
        }

        int[] Replace(int index)
        {
            var newNums = new int[nums.Length - 1];
            for (int i = 0; i < index; i++)
            {
                newNums[i] = nums[i];
            }
            newNums[index] = nums[index] + nums[index + 1];
            for (int i = index + 2; i < nums.Length; i++)
            {
                newNums[i - 1] = nums[i];
            }
            return newNums;
        }

        bool Check()
        {
            if (nums.Length <= 1)
            {
                return true;
            }

            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i] > nums[i + 1])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
// @lc code=end

