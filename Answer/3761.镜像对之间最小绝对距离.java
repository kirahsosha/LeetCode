
import java.util.HashMap;

/*
 * @lc app=leetcode.cn id=3761 lang=java
 *
 * [3761] 镜像对之间最小绝对距离
 */
// @lc code=start
class Solution {
    public int minMirrorPairDistance(int[] nums) {
        int n = nums.length;
        HashMap<Integer, Integer> dic = new HashMap<>(n);
        int res = n;

        for (int j = 0; j < n; j++) {
            int num = nums[j];
            Integer i = dic.get(num);
            if (i != null) {
                res = Math.min(res, j - i);
            }
            int rev = 0;
            for (int x = num; x > 0; x /= 10) {
                rev = rev * 10 + x % 10;
            }
            dic.put(rev, j);
        }
        return res == n ? -1 : res;
    }
}
// @lc code=end
