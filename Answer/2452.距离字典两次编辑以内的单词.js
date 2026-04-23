/*
 * @lc app=leetcode.cn id=2452 lang=javascript
 *
 * [2452] 距离字典两次编辑以内的单词
 */

// @lc code=start
/**
 * @param {string[]} queries
 * @param {string[]} dictionary
 * @return {string[]}
 */
var twoEditWords = function (queries, dictionary) {
  function editTimes(a, b) {
    let diff = 0;
    for (let i = 0; i < a.length; i++) {
      if (a[i] !== b[i]) {
        diff++;
      }
    }
    return diff;
  }

  const ans = [];
  for (const query of queries) {
    for (const dict of dictionary) {
      if (editTimes(query, dict) <= 2) {
        ans.push(query);
        break;
      }
    }
  }
  return ans;
};
// @lc code=end
