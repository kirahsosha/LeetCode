
import java.util.HashSet;

/*
 * @lc app=leetcode.cn id=961 lang=java
 *
 * [961] 在长度 2N 的数组中找出重复 N 次的元素
 */
// @lc code=start
class Solution {

    public int repeatedNTimes(int[] nums) {
        var res = 0;
        HashSet<Integer> set = new HashSet<>();
        for (int n : nums) {
            if (set.contains(n)) {
                res = n;
                break;
            }
            set.add(n);
        }
        return res;
    }
}
// @lc code=end

