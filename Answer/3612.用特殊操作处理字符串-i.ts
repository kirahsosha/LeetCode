/*
 * @lc app=leetcode.cn id=3612 lang=typescript
 *
 * [3612] 用特殊操作处理字符串 I
 */

// @lc code=start
function processStr(s: string): string {
    let arr = [];
    for (const ch of s) {
        if (ch === '*') {
            arr.pop();
        } else if (ch === '#') {
            let n = arr.length;
            for (let i = 0; i < n; i++) {
                arr.push(arr[i]);
            }
        } else if (ch === '%') {
            arr.reverse();
        } else {
            arr.push(ch);
        }
    }
    return arr.join('');
}
// @lc code=end
