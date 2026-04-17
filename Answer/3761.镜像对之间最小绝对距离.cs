using System.Collections.Generic;

/*
 * @lc app=leetcode.cn id=3761 lang=csharp
 *
 * [3761] 镜像对之间最小绝对距离
 */

// @lc code=start
public class Solution {
    public int MinMirrorPairDistance(int[] nums) {
        int n = nums.Length;
        var dic = new Dictionary<int, int>(n);
        int res = n;

        for (int j = 0; j < n; j++) {
            int num = nums[j];
            if (dic.TryGetValue(num, out int i)) {
                res = Math.Min(res, j - i);
            }
            int rev = 0;
            for (int x = num; x > 0; x /= 10) {
                rev = rev * 10 + x % 10;
            }
            dic[rev] = j;
        }
        return res == n ? -1 : res;
    }
}
// @lc code=end
