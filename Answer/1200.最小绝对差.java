
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

/*
 * @lc app=leetcode.cn id=1200 lang=java
 *
 * [1200] 最小绝对差
 */
// @lc code=start
class Solution {

    public List<List<Integer>> minimumAbsDifference(int[] arr) {
        List<List<Integer>> ans = new ArrayList<>();
        var minAbs = Integer.MAX_VALUE;
        var n = arr.length;
        Arrays.sort(arr);
        for (int i = 0; i < n - 1; i++) {
            var abs = arr[i + 1] - arr[i];
            if (abs < minAbs) {
                minAbs = abs;
                ans.clear();
                var temp = new ArrayList<Integer>();
                temp.add(arr[i]);
                temp.add(arr[i + 1]);
                ans.add(temp);
            } else if (abs == minAbs) {
                var temp = new ArrayList<Integer>();
                temp.add(arr[i]);
                temp.add(arr[i + 1]);
                ans.add(temp);
            }
        }
        return ans;
    }
}
// @lc code=end

