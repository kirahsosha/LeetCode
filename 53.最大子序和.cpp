/*
 * @lc app=leetcode.cn id=53 lang=cpp
 *
 * [53] 最大子序和
 */

// @lc code=start
class Solution {
public:
    int maxSubArray(vector<int>& nums) {
        if (nums.size() == 0) return 0;
        if (nums.size() == 1) return nums[0];
        int sub = 0, max = nums[0];
        for (int i = 0; i < nums.size(); i++)
        {
            if (nums[i] > sub + nums[i])
            {
                sub = nums[i];
            }
            else
            {
                sub += nums[i];
            }
            if (sub > max)
            {
                max = sub;
            }
        }
        return max;
    }
};
// @lc code=end

