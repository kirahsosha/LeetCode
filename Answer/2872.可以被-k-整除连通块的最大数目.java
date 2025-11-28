/*
 * @lc app=leetcode.cn id=2872 lang=java
 *
 * [2872] 可以被 K 整除连通块的最大数目
 */

// @lc code=start
import java.util.ArrayList;

class Solution {

    ArrayList<Integer>[] nodes;
    int res;

    public int maxKDivisibleComponents(int n, int[][] edges, int[] values, int k) {
        nodes = new ArrayList[n];
        res = 0;
        for (int i = 0; i < n; ++i) {
            nodes[i] = new ArrayList<>();
        }
        for (int[] edge : edges) {
            var l = edge[0];
            var r = edge[1];
            nodes[l].add(r);
            nodes[r].add(l);
        }
        MaxKDivisibleComponents(-1, 0, values, k);
        return res;
    }

    private long MaxKDivisibleComponents(int parent, int child, int[] values, int k) {
        long sum = values[child];
        for (int neighbor : nodes[child]) {
            if (neighbor != parent) {
                sum += MaxKDivisibleComponents(child, neighbor, values, k);
            }
        }
        if (sum % k == 0) {
            res++;
            return 0;
        }
        return sum;
    }
}
// @lc code=end

