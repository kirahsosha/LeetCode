/*
 * @lc app=leetcode.cn id=1291 lang=java
 *
 * [1291] 顺次数
 */

import java.util.ArrayList;
import java.util.List;

// @lc code=start
class Solution {

    public List<Integer> sequentialDigits(int low, int high) {
        List<Integer> res = new ArrayList<>(36);
        int delta = 1;
        int offset = 0;
        for (int length = 2; length <= 9; length++) {
            delta = delta * 10 + 1;
            offset = offset * 10 + (length - 1);

            int minNum = delta + offset;
            if (minNum > high) {
                break;
            }
            int maxNum = (10 - length) * delta + offset;
            if (maxNum < low) {
                continue;
            }
            for (int start = 1; start <= 10 - length; start++) {
                int num = start * delta + offset;
                if (num < low) {
                    continue;
                }
                if (num > high) {
                    break;
                }
                res.add(num);
            }
        }
        return res;
    }
}
// @lc code=end
