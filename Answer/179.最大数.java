/*
 * @lc app=leetcode.cn id=179 lang=java
 *
 * [179] 最大数
 */

// @lc code=start
import java.util.Arrays;
import java.util.Objects;

class Solution {

    public String largestNumber(int[] nums) {
        Integer[] arr = new Integer[nums.length];
        for (int i = 0; i < nums.length; i++) {
            arr[i] = nums[i];
        }
        Arrays.sort(arr, (x, y) -> {
            if (Objects.equals(x, y)) {
                return 0;
            }
            if (x == 0) {
                return 1;
            }
            if (y == 0) {
                return -1;
            }
            long i = 1;
            while (i <= y) {
                i *= 10;
            }
            long j = 1;
            while (j <= x) {
                j *= 10;
            }
            if ((i * x + y) > (j * y + x)) {
                return -1;
            }
            return 1;
        });
        if (arr[0] == 0) {
            return "0";
        }
        StringBuilder sb = new StringBuilder();
        for (int num : arr) {
            sb.append(num);
        }
        return sb.toString();
    }
}
// @lc code=end

