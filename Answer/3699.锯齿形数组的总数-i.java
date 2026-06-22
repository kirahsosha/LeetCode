/*
 * @lc app=leetcode.cn id=3699 lang=java
 *
 * [3699] 锯齿形数组的总数 I
 */

// @lc code=start
class Solution {

    public int zigZagArrays(int n, int l, int r) {
        final int MOD = 1_000_000_007;
        int k = r - l + 1;
        int[] f = new int[k];
        Arrays.fill(f, 1);

        for (int i = 1; i < n; i++) {
            if (i % 2 > 0) { // 增
                long pre = 0;
                for (int j = 0; j < k; j++) {
                    int v = f[j];
                    f[j] = (int) (pre % MOD);
                    pre += v;
                }
            } else { // 减
                long suf = 0;
                for (int j = k - 1; j >= 0; j--) {
                    int v = f[j];
                    f[j] = (int) (suf % MOD);
                    suf += v;
                }
            }
        }

        long ans = 0;
        for (int v : f) {
            ans += v;
        }
        return (int) (ans * 2 % MOD);
    }
}
// @lc code=end

