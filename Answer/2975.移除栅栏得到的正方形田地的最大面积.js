/*
 * @lc app=leetcode.cn id=2975 lang=javascript
 *
 * [2975] 移除栅栏得到的正方形田地的最大面积
 */

// @lc code=start
/**
 * @param {number} m
 * @param {number} n
 * @param {number[]} hFences
 * @param {number[]} vFences
 * @return {number}
 */
var maximizeSquareArea = function (m, n, hFences, vFences) {
    const MOD = 1000000007;
    hFences.sort((a, b) => a - b);
    let hLength = new Set();
    hLength.add(m - 1);
    for (let i = 0; i < hFences.length; i++) {
        hLength.add(hFences[i] - 1);
        hLength.add(m - hFences[i]);
        for (let j = i + 1; j < hFences.length; j++) {
            hLength.add(hFences[j] - hFences[i]);
        }
    }

    vFences.sort((a, b) => a - b);
    let vLength = new Set();
    vLength.add(n - 1);
    for (let i = 0; i < vFences.length; i++) {
        vLength.add(vFences[i] - 1);
        vLength.add(n - vFences[i]);
        for (let j = i + 1; j < vFences.length; j++) {
            vLength.add(vFences[j] - vFences[i]);
        }
    }

    let res = 0;
    hLength.forEach(len => {
        if (vLength.has(len)) {
            res = Math.max(res, len);
        }
    });

    if (res === 0) {
        return -1;
    }
    else {
        return Number((BigInt(res) * BigInt(res)) % BigInt(MOD));
    }
};
// @lc code=end

