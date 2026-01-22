/*
 * @lc app=leetcode.cn id=3507 lang=java
 *
 * [3507] 移除最小数对使数组有序 I
 */

// @lc code=start
class Solution {

    public int minimumPairRemoval(int[] nums) {
        var times = 0;
        while (!Check(nums)) {
            var index = GetMin(nums);
            nums = Replace(nums, index);
            times++;
        }
        return times;
    }

    private int GetMin(int[] nums) {
        var res = nums[0] + nums[1];
        var index = 0;
        for (int i = 1; i < nums.length - 1; i++) {
            if (nums[i] + nums[i + 1] < res) {
                res = nums[i] + nums[i + 1];
                index = i;
            }
        }
        return index;
    }

    private int[] Replace(int[] nums, int index) {
        var newNums = new int[nums.length - 1];
        System.arraycopy(nums, 0, newNums, 0, index);
        newNums[index] = nums[index] + nums[index + 1];
        for (int i = index + 2; i < nums.length; i++) {
            newNums[i - 1] = nums[i];
        }
        return newNums;
    }

    private boolean Check(int[] nums) {
        if (nums.length <= 1) {
            return true;
        }

        for (int i = 0; i < nums.length - 1; i++) {
            if (nums[i] > nums[i + 1]) {
                return false;
            }
        }
        return true;
    }
}
// @lc code=end

