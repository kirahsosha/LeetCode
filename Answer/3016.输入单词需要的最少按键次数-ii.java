/*
 * @lc app=leetcode.cn id=3016 lang=java
 *
 * [3016] 输入单词需要的最少按键次数 II
 */

import java.util.Arrays;

// @lc code=start
class Solution {
    public int minimumPushes(String word) {
        int[] cnt = new int[26];
        for (int i = 0; i < word.length(); i++) {
            cnt[word.charAt(i) - 'a']++;
        }
        Arrays.sort(cnt);
        int ans = 0;
        for (int i = 25; i >= 0 && cnt[i] > 0; i--) {
            ans += ((25 - i) / 8 + 1) * cnt[i];
        }
        return ans;
    }
}
// @lc code=end
