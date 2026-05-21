/*
 * @lc app=leetcode.cn id=2657 lang=javascript
 *
 * [2657] 找到两个数组的前缀公共数组
 */

// @lc code=start
/**
 * @param {number[]} A
 * @param {number[]} B
 * @return {number[]}
 */
var findThePrefixCommonArray = function (A, B) {
  var n = A.length;
  var ans = new Array(n).fill(0);
  var count = new Array(n + 1).fill(0);
  var common = 0;
  for (var i = 0; i < n; i++) {
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
};
// @lc code=end
