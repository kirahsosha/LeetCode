/*
 * @lc app=leetcode.cn id=1358 lang=typescript
 *
 * [1358] 包含所有三种字符的子字符串数目
 */

// @lc code=start
function numberOfSubstrings(s: string): number {
    const last = [-1, -1, -1];
    let ans = 0;
    const aCode = 'a'.charCodeAt(0);
    for (let i = 0; i < s.length; i++) {
        last[s.charCodeAt(i) - aCode] = i;
        ans += Math.min(last[0], Math.min(last[1], last[2])) + 1;
    }
    return ans;
}
// @lc code=end
