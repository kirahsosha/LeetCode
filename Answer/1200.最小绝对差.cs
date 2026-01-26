/*
 * @lc app=leetcode.cn id=1200 lang=csharp
 *
 * [1200] 最小绝对差
 */

// @lc code=start
public class Solution
{
    public IList<IList<int>> MinimumAbsDifference(int[] arr)
    {
        var ans = new List<IList<int>>();
        var minAbs = int.MaxValue;
        var n = arr.Length;
        Array.Sort(arr);
        for (int i = 0; i < n - 1; i++)
        {
            var abs = arr[i + 1] - arr[i];
            if (abs < minAbs)
            {
                minAbs = abs;
                ans.Clear();
                ans.Add([arr[i], arr[i + 1]]);
            }
            else if (abs == minAbs)
            {
                ans.Add([arr[i], arr[i + 1]]);
            }
        }
        return ans;
    }
}
// @lc code=end

