
import java.util.Arrays;
import java.util.HashSet;

/*
 * @lc app=leetcode.cn id=2975 lang=java
 *
 * [2975] 移除栅栏得到的正方形田地的最大面积
 */
// @lc code=start
class Solution {

    public int maximizeSquareArea(int m, int n, int[] hFences, int[] vFences) {
        var MOD = 1000000007;
        Arrays.sort(hFences);
        HashSet<Integer> hLength = new HashSet<>();
        hLength.add(m - 1);
        for (var i = 0; i < hFences.length; i++) {
            hLength.add(hFences[i] - 1);
            hLength.add(m - hFences[i]);
            for (var j = i + 1; j < hFences.length; j++) {
                hLength.add(hFences[j] - hFences[i]);
            }
        }

        Arrays.sort(vFences);
        HashSet<Integer> vLength = new HashSet<>();
        vLength.add(n - 1);
        for (var i = 0; i < vFences.length; i++) {
            vLength.add(vFences[i] - 1);
            vLength.add(n - vFences[i]);
            for (var j = i + 1; j < vFences.length; j++) {
                vLength.add(vFences[j] - vFences[i]);
            }
        }

        long res = 0;
        for (var len : hLength) {
            if (vLength.contains(len)) {
                res = Math.max(res, len);
            }
        }

        if (res == 0) {
            return -1;
        } else {
            return (int) (res * res % MOD);
        }
    }
}
// @lc code=end

