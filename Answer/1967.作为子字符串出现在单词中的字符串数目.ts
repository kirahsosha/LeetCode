/*
 * @lc app=leetcode.cn id=1967 lang=typescript
 *
 * [1967] 作为子字符串出现在单词中的字符串数目
 */

// @lc code=start
function numOfStrings(patterns: string[], word: string): number {
    let ans = 0;
    for (const p of patterns) {
        if (word.includes(p)) {
            ans++;
        }
    }
    return ans;
}
// @lc code=end
