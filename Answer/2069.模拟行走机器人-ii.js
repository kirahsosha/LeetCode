/*
 * @lc app=leetcode.cn id=2069 lang=javascript
 *
 * [2069] 模拟行走机器人 II
 */

// @lc code=start
/**
 * @param {number} width
 * @param {number} height
 */
var Robot = function (width, height) {
  this.width = width;
  this.height = height;
  this.perimeter = (width + height - 2) * 2;
  this.stepCount = 0;
};

/**
 * @param {number} num
 * @return {void}
 */
Robot.prototype.step = function (num) {
  this.stepCount = ((this.stepCount + num - 1) % this.perimeter) + 1;
};

/**
 * @return {number[]}
 */
Robot.prototype.getPos = function () {
  var state = this._getState();
  return [state[0], state[1]];
};

/**
 * @return {string}
 */
Robot.prototype.getDir = function () {
  return this._getState()[2];
};

Robot.prototype._getState = function () {
  var width = this.width;
  var height = this.height;
  var step = this.stepCount;
  if (step < width) {
    return [step, 0, "East"];
  }
  if (step < width + height - 1) {
    return [width - 1, step - width + 1, "North"];
  }
  if (step < width * 2 + height - 2) {
    return [width * 2 + height - step - 3, height - 1, "West"];
  }
  return [0, (width + height) * 2 - step - 4, "South"];
};

/**
 * Your Robot object will be instantiated and called as such:
 * var obj = new Robot(width, height)
 * obj.step(num)
 * var param_2 = obj.getPos()
 * var param_3 = obj.getDir()
 */
// @lc code=end
