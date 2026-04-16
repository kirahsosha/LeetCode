/*
 * @lc app=leetcode.cn id=3488 lang=csharp
 *
 * [3488] 距离最小相等元素查询
 */

// @lc code=start
public class Solution {
    public IList<int> SolveQueries(int[] nums, int[] queries) {
        int n = nums.Length;
        int[] left = new int[n];
        int[] right = new int[n];
        Dictionary<int, int> first = new Dictionary<int, int>();
        Dictionary<int, int> last = new Dictionary<int, int>();

        for (int i = 0; i < n; i++) {
            int x = nums[i];
            if (last.TryGetValue(x, out int j)) {
                left[i] = j;
                right[j] = i;
            } else {
                left[i] = -1;
            }
            if (!first.ContainsKey(x)) {
                first[x] = i;
            }
            last[x] = i;
        }

        int[] ans = new int[queries.Length];
        for (int qi = 0; qi < queries.Length; qi++) {
            int i = queries[qi];
            int l = left[i];
            if (l < 0) {
                l = last[nums[i]] - n;
            }
            if (i - l == n) {
                ans[qi] = -1;
            } else {
                int r = right[i];
                if (r == 0) {
                    r = first[nums[i]] + n;
                }
                ans[qi] = Math.Min(i - l, r - i);
            }
        }
        return ans;
    }
}
// @lc code=end
