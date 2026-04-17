/*
 * @lc app=leetcode.cn id=3761 lang=javascript
 *
 * [3761] 镜像对之间最小绝对距离
 */

// @lc code=start
/**
 * @param {number[]} nums
 * @return {number}
 */
var minMirrorPairDistance = function(nums) {
    const n = nums.length;
    const dic = new Map();
    let res = n;

    for (let j = 0; j < n; j++) {
        const num = nums[j];
        if (dic.has(num)) {
            res = Math.min(res, j - dic.get(num));
        }
        let rev = 0;
        for (let x = num; x > 0; x = (x / 10) | 0) {
            rev = rev * 10 + x % 10;
        }
        dic.set(rev, j);
    }
    return res === n ? -1 : res;
};
// @lc code=end
