/*
 * @lc app=leetcode.cn id=46 lang=csharp
 *
 * [46] 全排列
 */

// @lc code=start
public class Solution {
    public void search(int[]nums, IList<IList<int>> ans, IList<int> list)
    {
        if(list.Count == nums.Length)
        {
            ans.Add(new List<int>(list));
        }
        foreach(int i in nums)
        {
            if(list.Contains(i))
            {
                continue;
            }
            else
            {
                list.Add(i);
                search(nums, ans, list);
                list.RemoveAt(list.Count - 1);
            }
        }
    }

    public IList<IList<int>> Permute(int[] nums) {
        IList<IList<int>> ans = new List<IList<int>>();
        IList<int> list = new List<int>();
        search(nums, ans, list);
        return ans;
    }
}
// @lc code=end

