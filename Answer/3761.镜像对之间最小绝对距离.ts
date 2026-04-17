/*
 * @lc app=leetcode.cn id=3761 lang=typescript
 *
 * [3761] 镜像对之间最小绝对距离
 */

// @lc code=start
function minMirrorPairDistance(nums: number[]): number {
    const n = nums.length;
    const dic = new Map<number, number>();
    let res = n;

    for (let j = 0; j < n; j++) {
        const num = nums[j];
        if (dic.has(num)) {
            res = Math.min(res, j - dic.get(num)!);
        }
        let rev = 0;
        for (let x = num; x > 0; x = (x / 10) | 0) {
            rev = rev * 10 + x % 10;
        }
        dic.set(rev, j);
    }
    return res === n ? -1 : res;
}
// @lc code=end
