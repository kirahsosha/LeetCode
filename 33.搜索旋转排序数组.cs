/*
 * @lc app=leetcode.cn id=33 lang=csharp
 *
 * [33] 搜索旋转排序数组
 */

// @lc code=start
public class Solution {
    public int Search(int[] nums, int target) {
        int len = nums.Length;
        int l = 0;
        int r = len - 1;
        while(l <= r)
        {
            int mid = (l + r) / 2;
            //当前中点为目标值, 返回结果
            if(nums[l] == target) return l;
            if(nums[r] == target) return r;
            if(nums[mid] == target) return mid;
            //中点大于等于左侧端点, 说明左侧有序
            if(nums[mid] >= nums[l])
            {
                //目标值在左侧
                if(nums[l] <= target && target <= nums[mid]) r = mid - 1;
                else l = mid + 1;
            }
            else
            {
                //目标值在右侧
                if(nums[mid] <= target && target <= nums[r]) l = mid + 1;
                else r = mid - 1;
            }
        }
        return -1;
    }
}
// @lc code=end