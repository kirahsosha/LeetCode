/*
 * @lc app=leetcode.cn id=136 lang=csharp
 *
 * [136] 只出现一次的数字
 */

// @lc code=start
public class Solution {
    public int SingleNumber(int[] nums) {
        IList<int> list = new List<int>();
        foreach(int i in nums)
        {
            if(list.Contains(i))
            {
                list.Remove(i);
            }
            else
            {
                list.Add(i);
            }
        }
        return list[0];
    }
}
// @lc code=end

