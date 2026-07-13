/*
 * @lc app=leetcode.cn id=1291 lang=typescript
 *
 * [1291] 顺次数
 */

// @lc code=start
function sequentialDigits(low: number, high: number): number[] {
  const res: number[] = [];
  let delta = 1;
  let offset = 0;
  for (let length = 2; length <= 9; length++) {
    delta = delta * 10 + 1;
    offset = offset * 10 + (length - 1);

    const minNum = delta + offset;
    if (minNum > high) {
      break;
    }
    const maxNum = (10 - length) * delta + offset;
    if (maxNum < low) {
      continue;
    }
    for (let start = 1; start <= 10 - length; start++) {
      const num = start * delta + offset;
      if (num < low) {
        continue;
      }
      if (num > high) {
        break;
      }
      res.push(num);
    }
  }
  return res;
}
// @lc code=end
