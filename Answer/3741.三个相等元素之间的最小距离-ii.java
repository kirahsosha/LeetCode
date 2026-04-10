/*
 * @lc app=leetcode.cn id=3741 lang=java
 *
 * [3741] 三个相等元素之间的最小距离 II
 */

// @lc code=start
import java.util.HashMap;

class Solution {

    public int minimumDistance(int[] nums) {
        HashMap<Integer, State> positions = new HashMap<>();
        int best = Integer.MAX_VALUE;
        for (int index = 0; index < nums.length; index++) {
            int num = nums[index];
            State state = positions.get(num);
            if (state == null) {
                positions.put(num, new State(index));
                continue;
            }

            if (!state.hasTwo) {
                state.newer = index;
                state.hasTwo = true;
                continue;
            }

            best = Math.min(best, 2 * (index - state.older));
            state.older = state.newer;
            state.newer = index;
        }

        return best == Integer.MAX_VALUE ? -1 : best;
    }

    private static final class State {

        int older;
        int newer;
        boolean hasTwo;

        State(int index) {
            this.older = index;
        }
    }
}
// @lc code=end

