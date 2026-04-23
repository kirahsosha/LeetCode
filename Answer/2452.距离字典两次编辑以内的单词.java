
import java.util.ArrayList;
import java.util.List;

/*
 * @lc app=leetcode.cn id=2452 lang=java
 *
 * [2452] 距离字典两次编辑以内的单词
 */
// @lc code=start
class Solution {

    public List<String> twoEditWords(String[] queries, String[] dictionary) {
        List<String> ans = new ArrayList<>();
        for (String query : queries) {
            for (String dict : dictionary) {
                if (editTimes(query, dict) <= 2) {
                    ans.add(query);
                    break;
                }
            }
        }
        return ans;
    }

    private int editTimes(String a, String b) {
        int diff = 0;
        for (int i = 0; i < a.length(); i++) {
            if (a.charAt(i) != b.charAt(i)) {
                diff++;
            }
        }
        return diff;
    }
}
// @lc code=end

