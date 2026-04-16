import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

/*
 * @lc app=leetcode.cn id=3488 lang=java
 *
 * [3488] 距离最小相等元素查询
 */

// @lc code=start
class Solution {
    public List<Integer> solveQueries(int[] nums, int[] queries) {
        int n = nums.length;
        int[] left = new int[n];
        int[] right = new int[n];
        Map<Integer, Integer> first = new HashMap<>();
        Map<Integer, Integer> last = new HashMap<>();

        for (int i = 0; i < n; i++) {
            int x = nums[i];
            Integer j = last.get(x);
            if (j != null) {
                left[i] = j;
                right[j] = i;
            } else {
                left[i] = -1;
            }
            if (!first.containsKey(x)) {
                first.put(x, i);
            }
            last.put(x, i);
        }

        List<Integer> ans = new ArrayList<>(queries.length);
        for (int i : queries) {
            int l = left[i];
            if (l < 0) {
                l = last.get(nums[i]) - n;
            }
            if (i - l == n) {
                ans.add(-1);
            } else {
                int r = right[i];
                if (r == 0) {
                    r = first.get(nums[i]) + n;
                }
                ans.add(Math.min(i - l, r - i));
            }
        }
        return ans;
    }
}
// @lc code=end
