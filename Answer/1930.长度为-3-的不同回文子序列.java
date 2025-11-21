
import java.util.ArrayList;
import java.util.HashMap;
import java.util.HashSet;

/*
 * @lc app=leetcode.cn id=1930 lang=java
 *
 * [1930] 长度为 3 的不同回文子序列
 */
// @lc code=start
class Solution {

    public int countPalindromicSubsequence(String s) {
        HashMap<Character, ArrayList<Integer>> dic = new HashMap<>();
        HashSet<String> res = new HashSet<>();
        for (int i = 0; i < s.length(); i++) {
            var c = s.charAt(i);
            if (dic.get(c) != null) {
                dic.get(c).add(i);
            } else {
                ArrayList<Integer> list = new ArrayList<>();
                list.add(i);
                dic.put(c, list);
            }
        }
        for (ArrayList<Integer> v : dic.values()) {
            if (v.size() >= 2) {
                var l = v.get(0);
                var r = v.get(v.size() - 1);

                for (int j = l + 1; j < r; j++) {
                    res.add("" + s.charAt(l) + s.charAt(j) + s.charAt(r));
                }
            }
        }
        return res.size();
    }
}
// @lc code=end

