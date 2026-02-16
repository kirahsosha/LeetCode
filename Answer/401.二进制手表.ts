/*
 * @lc app=leetcode.cn id=401 lang=typescript
 *
 * [401] 二进制手表
 */

// @lc code=start
function readBinaryWatch(turnedOn: number): string[] {
    function ConbineNumber(num: number, digit: number, last: number): number[] {
        let res = Array<number>();

        if (last == 0) {
            res.push(num);
            return res;
        } else if (digit == last) {
            return ConbineNumber((num << 1) + 1, digit - 1, last - 1);
        } else if (digit == 0) {
            return ConbineNumber(num << 1, digit, last - 1);
        } else {
            ConbineNumber((num << 1) + 1, digit - 1, last - 1).forEach(num => {
                res.push(num);
            });
            ConbineNumber(num << 1, digit, last - 1).forEach(num => {
                res.push(num);
            });
            return res;
        }
    }

    let nums = ConbineNumber(0, turnedOn, 10);
    let res = Array<string>();
    nums.forEach(num => {
        var minute = num >> 4;
        var hour = num & 0x0000000f;
        if (hour < 12 && minute < 60) {
            res.push(hour + ":" + (minute < 10 ? "0" : "") + minute);
        }
    });
    return res;
};
// @lc code=end

