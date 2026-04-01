
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

/*
 * @lc app=leetcode.cn id=2751 lang=java
 *
 * [2751] 机器人碰撞
 */
// @lc code=start
class Solution {

    public List<Integer> survivedRobotsHealths(int[] positions, int[] healths, String directions) {
        int n = positions.length;
        int[][] robots = new int[n][2];
        for (int i = 0; i < n; i++) {
            robots[i][0] = positions[i];
            robots[i][1] = i;
        }

        Arrays.sort(robots, (a, b) -> Integer.compare(a[0], b[0]));

        int[] rightStack = new int[n];
        int top = -1;

        for (int[] robot : robots) {
            int i = robot[1];
            if (directions.charAt(i) == 'R') {
                rightStack[++top] = i;
                continue;
            }

            while (top >= 0 && healths[i] > 0) {
                int j = rightStack[top];
                if (healths[j] < healths[i]) {
                    top--;
                    healths[i]--;
                    healths[j] = 0;
                } else if (healths[j] > healths[i]) {
                    healths[j]--;
                    healths[i] = 0;
                } else {
                    top--;
                    healths[j] = 0;
                    healths[i] = 0;
                }
            }
        }

        List<Integer> ans = new ArrayList<>();
        for (int i = 0; i < n; i++) {
            if (healths[i] > 0) {
                ans.add(healths[i]);
            }
        }

        return ans;
    }
}
// @lc code=end

