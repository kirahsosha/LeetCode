/*
 * @lc app=leetcode.cn id=3517 lang=javascript
 *
 * [3517] 最小回文排列 I
 */

// @lc code=start
/**
 * @param {string} s
 * @return {string}
 */
var smallestPalindrome = function (s) {
    var n = s.length;
    var count = new Array(26).fill(0);
    var aCode = 'a'.charCodeAt(0);
    for (var i = 0; i < Math.floor(n / 2); i++) {
        count[s.charCodeAt(i) - aCode]++;
    }
    var ans = new Array(n);
    var left = 0, right = n - 1;
    for (var i = 0; i < 26; i++) {
        var c = String.fromCharCode(aCode + i);
        while (count[i] > 0) {
            ans[left++] = c;
            ans[right--] = c;
            count[i]--;
        }
    }
    if (n % 2 === 1) {
        ans[left] = s.charAt(Math.floor(n / 2));
    }
    return ans.join('');
};
// @lc code=end
