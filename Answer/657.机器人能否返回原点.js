/*
 * @lc app=leetcode.cn id=657 lang=javascript
 *
 * [657] 机器人能否返回原点
 */

// @lc code=start
/**
 * @param {string} moves
 * @return {boolean}
 */
var judgeCircle = function (moves) {
  var ver = 0;
  var hor = 0;
  moves.split("").forEach((move) => {
    switch (move) {
      case "U":
        ver++;
        break;
      case "D":
        ver--;
        break;
      case "L":
        hor--;
        break;
      case "R":
        hor++;
        break;
      default:
        throw new AssertionError();
    }
  });
  return ver == 0 && hor == 0;
};
// @lc code=end
