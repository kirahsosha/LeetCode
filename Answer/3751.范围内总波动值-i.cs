/*
 * @lc app=leetcode.cn id=3751 lang=csharp
 *
 * [3751] 范围内总波动值 I
 */

// @lc code=start
public class Solution {
    private static int[] prefix;

    static Solution() {
        const int maxN = 100000;
        int[] waviness = new int[maxN + 1];
        for (int x = 100; x <= maxN; x++) {
            string s = x.ToString();
            int cnt = 0;
            for (int j = 1; j < s.Length - 1; j++) {
                if ((s[j] > s[j - 1] && s[j] > s[j + 1]) ||
                    (s[j] < s[j - 1] && s[j] < s[j + 1])) {
                    cnt++;
                }
            }
            waviness[x] = cnt;
        }
        prefix = new int[maxN + 1];
        for (int i = 1; i <= maxN; i++) {
            prefix[i] = prefix[i - 1] + waviness[i];
        }
    }

    public int TotalWaviness(int num1, int num2) {
        if (num1 <= 0) {
            return prefix[num2];
        }
        return prefix[num2] - prefix[num1 - 1];
    }
}
// @lc code=end
