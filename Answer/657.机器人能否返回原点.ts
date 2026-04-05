/*
 * @lc app=leetcode.cn id=657 lang=typescript
 *
 * [657] 机器人能否返回原点
 */

// @lc code=start
function judgeCircle(moves: string): boolean {
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
    }
  });
  return ver == 0 && hor == 0;
}
// @lc code=end
