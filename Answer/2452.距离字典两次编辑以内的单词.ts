/*
 * @lc app=leetcode.cn id=2452 lang=typescript
 *
 * [2452] 距离字典两次编辑以内的单词
 */

// @lc code=start
function twoEditWords(queries: string[], dictionary: string[]): string[] {
  function editTimes(a: string, b: string): number {
    let diff = 0;
    for (let i = 0; i < a.length; i++) {
      if (a[i] !== b[i]) {
        diff++;
      }
    }
    return diff;
  }

  const ans: string[] = [];
  for (const query of queries) {
    for (const dict of dictionary) {
      if (editTimes(query, dict) <= 2) {
        ans.push(query);
        break;
      }
    }
  }
  return ans;
}
// @lc code=end
