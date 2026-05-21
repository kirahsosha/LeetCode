/*
 * @lc app=leetcode.cn id=2657 lang=typescript
 *
 * [2657] 找到两个数组的前缀公共数组
 */

// @lc code=start
function findThePrefixCommonArray(A: number[], B: number[]): number[] {
  const n = A.length;
  const ans: number[] = new Array<number>(n).fill(0);
  const count: number[] = new Array<number>(n + 1).fill(0);
  let common = 0;
  for (let i = 0; i < n; i++) {
    count[A[i]]++;
    if (count[A[i]] === 2) {
      common++;
    }

    count[B[i]]++;
    if (count[B[i]] === 2) {
      common++;
    }

    ans[i] = common;
  }

  return ans;
}
// @lc code=end
