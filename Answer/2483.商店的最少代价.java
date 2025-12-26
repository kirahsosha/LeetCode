/*
 * @lc app=leetcode.cn id=2483 lang=java
 *
 * [2483] 商店的最少代价
 */

// @lc code=start
class Solution {
    public int bestClosingTime(String customers) {
        var cost = 0;
        for (int i = 0; i < customers.length(); i++) {
            if (customers.charAt(i) == 'Y') {
                cost++;
            }
        }
        var min = cost;
        var res = 0;
        for (int i = 0; i < customers.length(); i++) {
            if (customers.charAt(i) == 'Y') {
                cost--;
            } else {
                cost++;
            }
            if (cost < min) {
                min = cost;
                res = i + 1;
            }
        }
        return res;
    }
}
// @lc code=end
