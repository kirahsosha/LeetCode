/*
 * @lc app=leetcode.cn id=229 lang=csharp
 *
 * [229] 求众数 II
 */

// @lc code=start
public class Solution {
    public IList<int> MajorityElement(int[] nums) {
        IList<int> ans = new List<int>();
        if(nums.Length == 0 || nums == null) return ans;
        int num1 = nums[0], num2 = nums[0];
        int count1 = 0, count2 = 0;
        foreach(int num in nums)
        {
            if(num == num1) count1++;
            else if(num == num2) count2++;
            else if(count1 == 0)
            {
                num1 = num;
                count1++;
            }
            else if(count2 == 0)
            {
                num2 = num;
                count2++;
            }
            else
            {
                count1--;
                count2--;
            }
        }
        count1 = 0;
        count2 = 0;
        foreach(int num in nums)
        {
            if(num == num1) count1++;
            else if(num == num2) count2++;
        }
        if(count1 * 3 > nums.Length) ans.Add(num1);
        if(count2 * 3 > nums.Length) ans.Add(num2);
        return ans;
    }
}
// @lc code=end

