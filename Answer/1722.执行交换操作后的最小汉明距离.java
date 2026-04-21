/*
 * @lc app=leetcode.cn id=1722 lang=java
 *
 * [1722] 执行交换操作后的最小汉明距离
 */

// @lc code=start
class Solution {
    public int minimumHammingDistance(int[] source, int[] target, int[][] allowedSwaps) {
        int n = source.length;
        int[] parent = new int[n];
        int[] sz = new int[n];
        for (int i = 0; i < n; i++) {
            parent[i] = i;
            sz[i] = 1;
        }

        for (int[] swap : allowedSwaps) {
            int pa = find(parent, swap[0]);
            int pb = find(parent, swap[1]);
            if (pa != pb) {
                if (sz[pa] < sz[pb]) {
                    int tmp = pa; pa = pb; pb = tmp;
                }
                parent[pb] = pa;
                sz[pa] += sz[pb];
            }
        }

        int[] roots = new int[n];
        for (int i = 0; i < n; i++) {
            roots[i] = find(parent, i);
        }

        java.util.HashMap<Integer, java.util.HashMap<Integer, Integer>> groups = new java.util.HashMap<>();
        for (int i = 0; i < n; i++) {
            int r = roots[i];
            groups.computeIfAbsent(r, k -> new java.util.HashMap<>()).merge(source[i], 1, Integer::sum);
        }

        int res = 0;
        for (int i = 0; i < n; i++) {
            int r = roots[i];
            var cnt = groups.get(r);
            if (cnt.getOrDefault(target[i], 0) > 0) {
                cnt.put(target[i], cnt.get(target[i]) - 1);
            } else {
                res++;
            }
        }
        return res;
    }

    private int find(int[] parent, int x) {
        int root = x;
        while (parent[root] != root) {
            root = parent[root];
        }
        while (parent[x] != x) {
            int next = parent[x];
            parent[x] = root;
            x = next;
        }
        return root;
    }
}
// @lc code=end
