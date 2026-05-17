
import java.util.ArrayDeque;
import java.util.Deque;

/*
 * @lc app=leetcode.cn id=1306 lang=java
 *
 * [1306] 跳跃游戏 III
 */
// @lc code=start
class Solution {

    public boolean canReach(int[] arr, int start) {
        boolean[] visited = new boolean[arr.length];
        Deque<Integer> stack = new ArrayDeque<>();
        stack.push(start);
        visited[start] = true;
        while (!stack.isEmpty()) {
            int index = stack.pop();
            if (arr[index] == 0) {
                return true;
            }

            int next = index + arr[index];
            if (next < arr.length && !visited[next]) {
                visited[next] = true;
                stack.push(next);
            }

            int prev = index - arr[index];
            if (prev >= 0 && !visited[prev]) {
                visited[prev] = true;
                stack.push(prev);
            }
        }

        return false;
    }
}
// @lc code=end
