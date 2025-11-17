/*
 * @lc app=leetcode.cn id=852 lang=csharp
 *
 * [852] 山脉数组的峰顶索引
 */

// @lc code=start
public class Solution {
    public int PeakIndexInMountainArray(int[] arr) {
        int length = arr.Length;
        if(length == 3) return 1;
        int l = 0;
        int r = length - 1;
        while(l < r)
        {
            int n = l + (r - l) / 2;
            if(arr[n] >= arr[n - 1] && arr[n] >= arr[n + 1])
            {
                return n;
            }
            else if(arr[n] >= arr[n - 1])
            {
                l = n;
            }
            else if(arr[n] >= arr[n + 1])
            {
                r = n;
            }
        }
        return r;
    }
}
// @lc code=end

