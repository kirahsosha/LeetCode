/*
 * @lc app=leetcode.cn id=2872 lang=javascript
 *
 * [2872] 可以被 K 整除连通块的最大数目
 */

// @lc code=start
/**
 * @param {number} n
 * @param {number[][]} edges
 * @param {number[]} values
 * @param {number} k
 * @return {number}
 */
var maxKDivisibleComponents = function (n, edges, values, k) {
    var nodes = Array.from({ length: n }, () => []);
    var res = 0;
    edges.forEach(edge => {
        var l = edge[0];
        var r = edge[1];
        nodes[l].push(r);
        nodes[r].push(l);
    });

    function MaxKDivisibleComponents(parent, child) {
        var sum = values[child];
        nodes[child].forEach(neighbor => {
            if (neighbor != parent) {
                sum += MaxKDivisibleComponents(child, neighbor, values, k);
            }
        });
        if (sum % k == 0) {
            res++;
            return 0;
        }
        return sum;
    }

    MaxKDivisibleComponents(-1, 0);
    return res;
};
// @lc code=end

