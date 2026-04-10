/*
 * @lc app=leetcode.cn id=3655 lang=java
 *
 * [3655] 区间乘法查询后的异或 II
 */

// @lc code=start
import java.util.ArrayList;
import java.util.HashMap;

class Solution {

    public int xorAfterQueries(int[] nums, int[][] queries) {
        final int mod = 1000000007;
        int n = nums.length;
        int limit = Math.min(n, (int) Math.sqrt(queries.length));
        int[][] diff = new int[limit + 1][];
        ArrayList<Integer> smallKs = new ArrayList<>(limit);
        boolean[] used = new boolean[limit + 1];
        HashMap<Integer, Integer> inverseCache = new HashMap<>();

        for (int[] query : queries) {
            int l = query[0];
            int r = query[1];
            int k = query[2];
            int v = query[3];
            if (k <= limit) {
                if (!used[k]) {
                    used[k] = true;
                    smallKs.add(k);
                    diff[k] = new int[n];
                    Arrays.fill(diff[k], 1);
                }

                diff[k][l] = mulMod(diff[k][l], v, mod);
                int end = l + (r - l) / k * k + k;
                if (end < n) {
                    diff[k][end] = mulMod(diff[k][end], modInverse(v, mod, inverseCache), mod);
                }
                continue;
            }

            for (int i = l; i <= r; i += k) {
                nums[i] = mulMod(nums[i], v, mod);
            }
        }

        for (int k : smallKs) {
            for (int i = 0; i < n; i++) {
                if (i >= k) {
                    diff[k][i] = mulMod(diff[k][i], diff[k][i - k], mod);
                }
                nums[i] = mulMod(nums[i], diff[k][i], mod);
            }
        }

        int result = 0;
        for (int num : nums) {
            result ^= num;
        }
        return result;
    }

    private int mulMod(int a, int b, int mod) {
        return (int) ((long) a * b % mod);
    }

    private int modInverse(int value, int mod, HashMap<Integer, Integer> inverseCache) {
        Integer inverse = inverseCache.get(value);
        if (inverse == null) {
            inverse = modPow(value, mod - 2, mod);
            inverseCache.put(value, inverse);
        }
        return inverse;
    }

    private int modPow(int value, int exponent, int mod) {
        int result = 1;
        while (exponent > 0) {
            if ((exponent & 1) != 0) {
                result = mulMod(result, value, mod);
            }
            value = mulMod(value, value, mod);
            exponent >>= 1;
        }
        return result;
    }
}
// @lc code=end

