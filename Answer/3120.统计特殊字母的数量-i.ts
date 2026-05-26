/*
 * @lc app=leetcode.cn id=3120 lang=typescript
 *
 * [3120] 统计特殊字母的数量 I
 */

// @lc code=start
function numberOfSpecialChars(word: string): number {
  let lowerMask = 0;
  let upperMask = 0;
  for (let i = 0; i < word.length; i++) {
    const c = word.charCodeAt(i);
    if (c >= 97 && c <= 122) {
      lowerMask |= 1 << (c - 97);
    } else if (c >= 65 && c <= 90) {
      upperMask |= 1 << (c - 65);
    }
  }

  let common = lowerMask & upperMask;
  let ans = 0;
  while (common > 0) {
    ans += common & 1;
    common >>= 1;
  }
  return ans;
}
// @lc code=end
