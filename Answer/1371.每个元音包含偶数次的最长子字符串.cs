/*
 * @lc app=leetcode.cn id=1371 lang=csharp
 *
 * [1371] 每个元音包含偶数次的最长子字符串
 */

// @lc code=start
public class Solution {
    public int FindTheLongestSubstring(string s) {
        int[] earliest = new int [1 << 5];
        for (int i = 0; i < earliest.Length; ++i) {
            earliest[i] = int.MaxValue;
        }
        earliest[0] = -1;
        int mask = 0, ans = 0;
        for (int i = 0; i < s.Length; ++i) {
            switch (s[i]) {
                case 'a': mask ^= (1 << 0); break;
                case 'e': mask ^= (1 << 1); break;
                case 'i': mask ^= (1 << 2); break;
                case 'o': mask ^= (1 << 3); break;
                case 'u': mask ^= (1 << 4); break;
            }
            if (earliest[mask] == int.MaxValue) earliest[mask] = i;
            else ans = Math.Max(ans, i - earliest[mask]);
        } 
        return ans;
    }
}
// @lc code=end

