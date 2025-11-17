/*
 * @lc app=leetcode.cn id=217 lang=csharp
 *
 * [217] 存在重复元素
 */

// @lc code=start
public class Solution {
    public bool ContainsDuplicate(int[] nums) {
        if(nums.Length==0) return false;
        var hs = new HashSet<int>(nums);
        return !(hs.Count == nums.Length);
    }
}
// @lc code=end

