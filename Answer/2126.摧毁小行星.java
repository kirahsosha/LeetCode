/*
 * @lc app=leetcode.cn id=2126 lang=java
 *
 * [2126] 摧毁小行星
 */

// @lc code=start
import java.util.Arrays;

class Solution {

    public boolean asteroidsDestroyed(int mass, int[] asteroids) {
        Arrays.sort(asteroids);
        long currentMass = mass;
        for (int asteroid : asteroids) {
            if (currentMass < asteroid) {
                return false;
            }
            currentMass += asteroid;
        }
        return true;
    }
}
// @lc code=end
