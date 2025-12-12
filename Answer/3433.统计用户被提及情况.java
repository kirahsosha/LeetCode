/*
 * @lc app=leetcode.cn id=3433 lang=java
 *
 * [3433] 统计用户被提及情况
 */

// @lc code=start
import java.util.Comparator;
import java.util.List;
import java.util.PriorityQueue;

class Solution {

    class NewComparator implements Comparator<int[]> {
        public int compare(int[] obj1, int[] obj2) {
            return obj1[0] - obj2[0];
        }
    }

    public int[] countMentions(int numberOfUsers, List<List<String>> events) {
        //Value: Timestamp, Event, Ids
        PriorityQueue<int[]> pq = new PriorityQueue<>(new NewComparator());
        var all = 0;
        for (int i = 0; i < events.size(); i++) {
            var ev = events.get(i);
            var e = "MESSAGE".equals(ev.get(0)) ? 0 : 1;
            var t = Integer.parseInt(ev.get(1)) * 3;
            var ids = ev.get(2).replace("id", "");
            if (e == 0) {
                if ("ALL".equals(ids)) {
                    all++;
                } else if ("HERE".equals(ids)) {
                    pq.add(new int[]{t, e, -1});
                } else {
                    var id = ids.split(" ");
                    for (String s : id) {
                        pq.add(new int[]{t, e, Integer.parseInt(s)});
                    }
                }
            } else {
                var id = Integer.parseInt(ids);
                pq.add(new int[]{t - 1, e, id});
                pq.add(new int[]{t + 178, 2, id});
            }
        }
        var status = new int[numberOfUsers];
        var res = new int[numberOfUsers];
        if (all > 0)
        {
            for (int i = 0; i < numberOfUsers; i++)
            {
                res[i] = all;
            }
        }
        while(!pq.isEmpty()){
            var item = pq.poll();
            var e = item[1];
            if (e == 0)
            {
                //MESSAGE
                if (item[2] == -1)
                {
                    for (int i = 0; i < numberOfUsers; i++)
                    {
                        if (status[i] == 0)
                        {
                            res[i]++;
                        }
                    }
                }
                else
                {
                    res[item[2]]++;
                }
            }
            else if (e == 1)
            {
                //OFFLINE
                status[item[2]] = -1;
            }
            else
            {
                //ONLINE
                status[item[2]] = 0;
            }
        }
        return res;
    }
}
// @lc code=end

