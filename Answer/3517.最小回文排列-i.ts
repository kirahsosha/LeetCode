/*
 * @lc app=leetcode.cn id=3517 lang=typescript
 *
 * [3517] 最小回文排列 I
 */

// @lc code=start
function smallestPalindrome(s: string): string {
    const n = s.length;
    const count = new Array(26).fill(0);
    const aCode = 'a'.charCodeAt(0);
    for (let i = 0; i < Math.floor(n / 2); i++) {
        count[s.charCodeAt(i) - aCode]++;
    }
    const ans = new Array<string>(n);
    let left = 0, right = n - 1;
    for (let i = 0; i < 26; i++) {
        const c = String.fromCharCode(aCode + i);
        while (count[i] > 0) {
            ans[left++] = c;
            ans[right--] = c;
            count[i]--;
        }
    }
    if (n % 2 === 1) {
        ans[left] = s.charAt(Math.floor(n / 2));
    }
    return ans.join('');
}
// @lc code=end
