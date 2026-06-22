
/*
 * @lc app=leetcode.cn id=1833 lang=java
 *
 * [1833] 雪糕的最大数量
 */
// @lc code=start
class Solution {

    public int maxIceCream(int[] costs, int coins) {
        var count = new int[100001];
        for (int cost : costs) {
            count[cost]++;
        }
        int ans = 0;
        int index = 1;
        while (coins > 0 && index < 100001) {
            if (coins < index) {
                break;
            }
            if (count[index] > 0) {
                int curCount = Math.min(count[index], coins / index);
                ans += curCount;
                coins -= index * curCount;
            }
            index++;
        }
        return ans;
    }
}
// @lc code=end

