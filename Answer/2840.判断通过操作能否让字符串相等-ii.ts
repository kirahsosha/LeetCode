/*
 * @lc app=leetcode.cn id=2840 lang=typescript
 *
 * [2840] 判断通过操作能否让字符串相等 II
 */

// @lc code=start
function checkStrings(s1: string, s2: string): boolean {
	const cnt1: number[][] = Array.from({ length: 2 }, () => new Array(26).fill(0));
	const cnt2: number[][] = Array.from({ length: 2 }, () => new Array(26).fill(0));
	for (let i = 0; i < s1.length; i++) {
		cnt1[i % 2][s1.charCodeAt(i) - 97]++;
		cnt2[i % 2][s2.charCodeAt(i) - 97]++;
	}

	for (let p = 0; p < 2; p++) {
		for (let c = 0; c < 26; c++) {
			if (cnt1[p][c] !== cnt2[p][c]) {
				return false;
			}
		}
	}

	return true;
};
// @lc code=end

