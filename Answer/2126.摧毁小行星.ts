/*
 * @lc app=leetcode.cn id=2126 lang=typescript
 *
 * [2126] 摧毁小行星
 */

// @lc code=start
function asteroidsDestroyed(mass: number, asteroids: number[]): boolean {
  asteroids.sort((a, b) => a - b);
  let currentMass = BigInt(mass);
  for (const asteroid of asteroids) {
    const asteroidMass = BigInt(asteroid);
    if (currentMass < asteroidMass) {
      return false;
    }
    currentMass += asteroidMass;
  }
  return true;
}
// @lc code=end
