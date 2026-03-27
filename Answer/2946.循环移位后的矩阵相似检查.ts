/*
 * @lc app=leetcode.cn id=2946 lang=typescript
 *
 * [2946] 循环移位后的矩阵相似检查
 */

// @lc code=start
function areSimilar(mat: number[][], k: number): boolean {
    const m = mat.length;
    const n = mat[0].length;
    k %= n;
    if (k === 0) return true;
    
    for (let i = 0; i < m; i++) {
        const row = mat[i];
        if ((i & 1) === 0) {
            // 偶数行：右移 k 位
            for (let j = 0; j < n; j++) {
                if (row[j] !== row[(j + k) % n]) {
                    return false;
                }
            }
        } else {
            // 奇数行：左移 k 位
            for (let j = 0; j < n; j++) {
                if (row[j] !== row[(j - k + n) % n]) {
                    return false;
                }
            }
        }
    }
    return true;
};
// @lc code=end

