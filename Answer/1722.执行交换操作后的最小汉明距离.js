/*
 * @lc app=leetcode.cn id=1722 lang=javascript
 *
 * [1722] 执行交换操作后的最小汉明距离
 */

// @lc code=start
/**
 * @param {number[]} source
 * @param {number[]} target
 * @param {number[][]} allowedSwaps
 * @return {number}
 */
var minimumHammingDistance = function(source, target, allowedSwaps) {
    const n = source.length;
    const parent = new Array(n);
    const sz = new Array(n);
    for (let i = 0; i < n; i++) {
        parent[i] = i;
        sz[i] = 1;
    }

    const find = (x) => {
        let root = x;
        while (parent[root] !== root) root = parent[root];
        while (parent[x] !== x) {
            const next = parent[x];
            parent[x] = root;
            x = next;
        }
        return root;
    };

    for (const [a, b] of allowedSwaps) {
        const pa = find(a);
        const pb = find(b);
        if (pa !== pb) {
            if (sz[pa] < sz[pb]) {
                parent[pa] = pb;
                sz[pb] += sz[pa];
            } else {
                parent[pb] = pa;
                sz[pa] += sz[pb];
            }
        }
    }

    const roots = new Array(n);
    for (let i = 0; i < n; i++) {
        roots[i] = find(i);
    }

    // 使用普通对象做频次统计，在 V8 中对整数键的访问极快
    const groups = new Map();
    for (let i = 0; i < n; i++) {
        const r = roots[i];
        if (!groups.has(r)) {
            groups.set(r, Object.create(null));
        }
        const cnt = groups.get(r);
        const val = source[i];
        cnt[val] = (cnt[val] || 0) + 1;
    }

    let res = 0;
    for (let i = 0; i < n; i++) {
        const r = roots[i];
        const cnt = groups.get(r);
        const val = target[i];
        if (cnt[val] > 0) {
            cnt[val]--;
        } else {
            res++;
        }
    }
    return res;
};
// @lc code=end
