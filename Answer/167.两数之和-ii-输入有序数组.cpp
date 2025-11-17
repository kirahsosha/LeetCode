/*
 * @lc app=leetcode.cn id=167 lang=cpp
 *
 * [167] 两数之和 II - 输入有序数组
 */

// @lc code=start
class Solution {
public:
    vector<int> twoSum(vector<int>& numbers, int target) {
        vector<int> index(2);
        index[0] = 1;
        index[1] = numbers.size();
        while(index[0] < index[1])
        {
            if(numbers[index[0] - 1] + numbers[index[1] - 1] == target)
            {
                return index;
            }
            else if(numbers[index[0] - 1] + numbers[index[1] - 1] > target)
            {
                index[1]--;
            }
            else
            {
                index[0]++;
            }
        }
        return index;
    }
};
// @lc code=end

