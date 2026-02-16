/*
 * @lc app=leetcode.cn id=401 lang=java
 *
 * [401] 二进制手表
 */

// @lc code=start

import java.util.ArrayList;
import java.util.List;

class Solution {
    public List<String> readBinaryWatch(int turnedOn) {
        var nums = ConbineNumber(0, turnedOn, 10);
        var res = new ArrayList<String>();
        for (var num : nums) {
            var minute = num >> 4;
            var hour = num & 0x0000000f;
            if (hour >= 12 || minute >= 60)
                continue;
            res.add(hour + ":" + String.format("%02d", minute));
        }
        return res;
    }

    private List<Integer> ConbineNumber(int number, int digit, int last) {
        var res = new ArrayList<Integer>();

        if (last == 0) {
            res.add(number);
            return res;
        } else if (digit == last) {
            return ConbineNumber((number << 1) + 1, digit - 1, last - 1);
        } else if (digit == 0) {
            return ConbineNumber(number << 1, digit, last - 1);
        } else {
            res.addAll(ConbineNumber((number << 1) + 1, digit - 1, last - 1));
            res.addAll(ConbineNumber(number << 1, digit, last - 1));
            return res;
        }
    }
}
// @lc code=end
