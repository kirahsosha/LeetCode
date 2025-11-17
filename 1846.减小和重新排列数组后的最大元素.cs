/*
 * @lc app=leetcode.cn id=1846 lang=csharp
 *
 * [1846] 减小和重新排列数组后的最大元素
 */

// @lc code=start
public class Solution {
    public int MaximumElementAfterDecrementingAndRearranging(int[] arr) {
        if (arr.Length == 1) return 1;
            int t = 0;
            arr = arr.OrderBy(p => p).ToArray();
            for(int i = 0; i < arr.Length; i++)
            {
                if(arr[i] > t + 1)
                {
                    arr[i] = t + 1;
                }
                t = arr[i];
            }
            return t;
    }
}
// @lc code=end

