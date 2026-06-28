/*
 * @lc app=leetcode.cn id=1967 lang=javascript
 *
 * [1967] 作为子字符串出现在单词中的字符串数目
 */

// @lc code=start
/**
 * @param {string[]} patterns
 * @param {string} word
 * @return {number}
 */
var numOfStrings = function (patterns, word) {
  var ans = 0;
  for (var pattern of patterns) {
    if (word.includes(pattern)) {
      ans++;
    }
  }
  return ans;
};
// @lc code=end
