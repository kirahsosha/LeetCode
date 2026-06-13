/*
 * @lc app=leetcode.cn id=3838 lang=typescript
 *
 * [3838] 带权单词映射
 */

// @lc code=start
function mapWordWeights(words: string[], weights: number[]): string {
    const res: string[] = [];
    for (let i = 0; i < words.length; i++) {
        const word = words[i];
        let w = 0;
        for (let j = 0; j < word.length; j++) {
            w = (w + weights[word.charCodeAt(j) - 97]) % 26;
        }
        res.push(String.fromCharCode(97 + 25 - w));
    }
    return res.join('');
}
// @lc code=end
