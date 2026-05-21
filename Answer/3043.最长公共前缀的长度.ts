/*
 * @lc app=leetcode.cn id=3043 lang=typescript
 *
 * [3043] 最长公共前缀的长度
 */

// @lc code=start
function longestCommonPrefix(arr1: number[], arr2: number[]): number {
  const prefixSet = new Set<number>();

  for (const num of arr1) {
    for (let n = num; n > 0; n = Math.floor(n / 10)) {
      prefixSet.add(n);
    }
  }

  let maxLen = 0;
  for (const num of arr2) {
    let length = 0;
    for (let temp = num; temp > 0; temp = Math.floor(temp / 10)) {
      length++;
    }

    for (let n = num; n > 0; n = Math.floor(n / 10)) {
      if (prefixSet.has(n)) {
        if (length > maxLen) {
          maxLen = length;
        }
        break;
      }
      length--;
    }
  }

  return maxLen;
}
// @lc code=end
