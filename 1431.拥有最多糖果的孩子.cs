/*
 * @lc app=leetcode.cn id=1431 lang=csharp
 *
 * [1431] 拥有最多糖果的孩子
 */

// @lc code=start
public class Solution {
    public IList<bool> KidsWithCandies(int[] candies, int extraCandies) {
        int max = 0;
        foreach(int i in candies)
        {
            max = Math.Max(max, i);
        }
        IList<bool> ans = new List<bool>();
        foreach(int i in candies)
        {
            if(i + extraCandies >= max)
            {
                ans.Add(true);
            }
            else
            {
                ans.Add(false);
            }
        }
        return ans;
    }
}
// @lc code=end

