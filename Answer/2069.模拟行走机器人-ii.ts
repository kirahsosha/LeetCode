/*
 * @lc app=leetcode.cn id=2069 lang=typescript
 *
 * [2069] 模拟行走机器人 II
 */

// @lc code=start
class Robot {
  private readonly perimeter: number;
  private stepCount = 0;

  constructor(
    private readonly width: number,
    private readonly height: number,
  ) {
    this.perimeter = (width + height - 2) * 2;
  }

  step(num: number): void {
    this.stepCount = ((this.stepCount + num - 1) % this.perimeter) + 1;
  }

  getPos(): number[] {
    const [x, y] = this.getState();
    return [x, y];
  }

  getDir(): string {
    return this.getState()[2];
  }

  private getState(): [number, number, string] {
    const step = this.stepCount;
    if (step < this.width) {
      return [step, 0, "East"];
    }
    if (step < this.width + this.height - 1) {
      return [this.width - 1, step - this.width + 1, "North"];
    }
    if (step < this.width * 2 + this.height - 2) {
      return [this.width * 2 + this.height - step - 3, this.height - 1, "West"];
    }
    return [0, (this.width + this.height) * 2 - step - 4, "South"];
  }
}

/**
 * Your Robot object will be instantiated and called as such:
 * var obj = new Robot(width, height)
 * obj.step(num)
 * var param_2 = obj.getPos()
 * var param_3 = obj.getDir()
 */
// @lc code=end
