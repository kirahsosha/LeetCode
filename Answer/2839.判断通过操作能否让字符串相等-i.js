/*
 * @lc app=leetcode.cn id=2839 lang=javascript
 *
 * [2839] 判断通过操作能否让字符串相等 I
 */

// @lc code=start
/**
 * @param {string} s1
 * @param {string} s2
 * @return {boolean}
 */
var canBeEqual = function(s1, s2) {
	const evenEqual =
		(s1[0] === s2[0] && s1[2] === s2[2]) ||
		(s1[0] === s2[2] && s1[2] === s2[0]);
	const oddEqual =
		(s1[1] === s2[1] && s1[3] === s2[3]) ||
		(s1[1] === s2[3] && s1[3] === s2[1]);

	return evenEqual && oddEqual;
};
// @lc code=end

