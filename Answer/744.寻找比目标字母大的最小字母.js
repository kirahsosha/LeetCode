/*
 * @lc app=leetcode.cn id=744 lang=javascript
 *
 * [744] 寻找比目标字母大的最小字母
 */

// @lc code=start
/**
 * @param {character[]} letters
 * @param {character} target
 * @return {character}
 */
var nextGreatestLetter = function (letters, target) {
    let index = 0;
    for (let i = 0; i < letters.length; i++) {
        if (letters[i] > target) {
            index = i;
            break;
        }
    }
    return letters[index];
};
// @lc code=end

