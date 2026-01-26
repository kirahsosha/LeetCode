/*
 * @lc app=leetcode.cn id=1200 lang=javascript
 *
 * [1200] 最小绝对差
 */

// @lc code=start
/**
 * @param {number[]} arr
 * @return {number[][]}
 */
var minimumAbsDifference = function (arr) {
    let ans = [];
    let minAbs = Number.MAX_VALUE;
    let n = arr.length;
    arr.sort((a, b) => a - b);
    for (let i = 0; i < n - 1; i++) {
        let abs = arr[i + 1] - arr[i];
        if (abs < minAbs) {
            minAbs = abs;
            ans = [];
            const pair = [];
            pair.push(arr[i]);
            pair.push(arr[i + 1]);
            ans.push(pair);
        } else if (abs == minAbs) {
            const pair = [];
            pair.push(arr[i]);
            pair.push(arr[i + 1]);
            ans.push(pair);
        }
    }
    return ans;
};
// @lc code=end

