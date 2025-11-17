/*
 * @lc app=leetcode.cn id=283 lang=cpp
 *
 * [283] 移动零
 */

// @lc code=start
class Solution {
public:
    void moveZeroes(vector<int>& nums) {
        if(nums.size() < 2) return;
        int i = 0, j = 0;
        while(j < nums.size())
        {
            if(i != j) nums[i] = nums[j];
            if(nums[i] == 0)
            {
                j++;
                continue;
            }
            i++;
            j++;
        }
        for(int t = i; t < nums.size(); t++)
        {
            nums[t] = 0;
        }
        return;
    }
};
// @lc code=end

