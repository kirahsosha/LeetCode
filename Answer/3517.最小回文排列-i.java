/*
 * @lc app=leetcode.cn id=3517 lang=java
 *
 * [3517] 最小回文排列 I
 */

// @lc code=start
class Solution {
    public String smallestPalindrome(String s) {
        int n = s.length();
        int[] count = new int[26];
        for (int i = 0; i < n / 2; i++) {
            count[s.charAt(i) - 'a']++;
        }
        char[] ans = new char[n];
        int left = 0, right = n - 1;
        for (int i = 0; i < 26; i++) {
            char c = (char) ('a' + i);
            while (count[i]-- > 0) {
                ans[left++] = c;
                ans[right--] = c;
            }
        }
        if (n % 2 == 1) {
            ans[left] = s.charAt(n / 2);
        }
        return new String(ans);
    }
}
// @lc code=end
