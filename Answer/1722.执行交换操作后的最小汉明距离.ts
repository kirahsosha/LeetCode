/*
 * @lc app=leetcode.cn id=1722 lang=typescript
 *
 * [1722] 执行交换操作后的最小汉明距离
 */

// @lc code=start
function minimumHammingDistance(source: number[], target: number[], allowedSwaps: number[][]): number {
    const n = source.length;
    const parent: number[] = new Array(n);
    const sz: number[] = new Array(n);
    for (let i = 0; i < n; i++) {
        parent[i] = i;
        sz[i] = 1;
    }

    const find = (x: number): number => {
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

    const roots: number[] = new Array(n);
    for (let i = 0; i < n; i++) {
        roots[i] = find(i);
    }

    const groups = new Map<number, Map<number, number>>();
    for (let i = 0; i < n; i++) {
        const r = roots[i];
        if (!groups.has(r)) {
            groups.set(r, new Map<number, number>());
        }
        const cnt = groups.get(r)!;
        const val = source[i];
        cnt.set(val, (cnt.get(val) || 0) + 1);
    }

    let res = 0;
    for (let i = 0; i < n; i++) {
        const r = roots[i];
        const cnt = groups.get(r)!;
        const val = target[i];
        if ((cnt.get(val) || 0) > 0) {
            cnt.set(val, cnt.get(val)! - 1);
        } else {
            res++;
        }
    }
    return res;
};
// @lc code=end
