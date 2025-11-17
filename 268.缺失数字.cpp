/*
 * @lc app=leetcode.cn id=268 lang=cpp
 *
 * [268] 缺失数字
 */

// @lc code=start
class Solution {
public:
    int missingNumber(vector<int>& nums) {
        if(nums.size() == 0) return 0;
        int n = nums.size();
        int m = 0, t = 0;
        m = (1 + n) * n / 2;
        for(int i = 0; i < n; i++)
        {
            t +=nums[i];
        }
        return m - t;
    }
};
// @lc code=end

