/*
 * @lc app=leetcode.cn id=3016 lang=typescript
 *
 * [3016] 输入单词需要的最少按键次数 II
 */

// @lc code=start
function minimumPushes(word: string): number {
    const cnt = new Array(26).fill(0);
    const aCode = 'a'.charCodeAt(0);
    for (let i = 0; i < word.length; i++) {
        cnt[word.charCodeAt(i) - aCode]++;
    }
    cnt.sort((a, b) => b - a);
    let ans = 0;
    for (let i = 0; i < 26 && cnt[i] > 0; i++) {
        ans += (Math.floor(i / 8) + 1) * cnt[i];
    }
    return ans;
}
// @lc code=end
