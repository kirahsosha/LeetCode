/*
 * @lc app=leetcode.cn id=1415 lang=typescript
 *
 * [1415] 长度为 n 的开心字符串中字典序第 k 小的字符串
 */

// @lc code=start
function getHappyString(n: number, k: number): string {
	const chars: string[] = ['a', 'b', 'c'];
	const res: string[] = [];
	if (k > 3 * (1 << (n - 1))) {
		return '';
	}
	for (let i = 0; i < n; i++) {
		const count = 1 << (n - i - 1);
		for (const c of chars) {
			if (res.length > 0 && res[res.length - 1] === c) {
				continue;
			}
			if (k <= count) {
				res.push(c);
				break;
			}
			k -= count;
		}
	}
	return res.join('');
}
// @lc code=end

