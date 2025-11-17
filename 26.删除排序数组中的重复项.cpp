/*
 * @lc app=leetcode.cn id=26 lang=cpp
 *
 * [26] 删除排序数组中的重复项
 */

// @lc code=start
class Solution {
public:
    int removeDuplicates(vector<int>& nums) {
        if(nums.size() == 0) return 0;
        if(nums.size() == 1) return 1;
        int a = 0, b = 1;
        while(b < nums.size())
        {
            if(nums[b] > nums[a])
            {
                nums[++a] = nums[b];
                b++;
            }
            else
            {
                b++;
            }
        }
        return a + 1;
    }
};
// @lc code=end

