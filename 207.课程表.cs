/*
 * @lc app=leetcode.cn id=207 lang=csharp
 *
 * [207] 课程表
 */

// @lc code=start
public class Solution {
    public bool CanFinish(int numCourses, int[][] prerequisites)
        {
            var learned = new List<int>();
            var preDic = new Dictionary<int, HashSet<int>>();
            foreach(var pre in prerequisites)
            {
                if (preDic.ContainsKey(pre[0]))
                {
                    preDic[pre[0]].Add(pre[1]);
                }
                else
                {
                    preDic.Add(pre[0], new HashSet<int>() { pre[1] });
                }
            }
            for (int i = 0; i < numCourses; i++)
            {
                if (learned.Contains(i)) continue;
                var res = LearnCourse(i, learned, new List<int>(), preDic);
                if (res == false) return false;
            }
            return true;
        }

        private bool LearnCourse(int course, List<int> learned, List<int> needLearn, Dictionary<int, HashSet<int>> preDic)
        {
            if (learned.Contains(course))
            {
                return true;
            }
            if (needLearn.Contains(course))
            {
                return false;
            }
            if (!preDic.TryGetValue(course, out var pre))
            {
                learned.Add(course);
                return true;
            }
            if(pre.Count == 0)
            {
                learned.Add(course);
                preDic.Remove(course);
                return true;
            }
            needLearn.Add(course);
            foreach(var preCourse in pre)
            {
                var res = LearnCourse(preCourse, learned, needLearn, preDic);
                if (res == false) return false;
            }
            learned.Add(course);
            needLearn.Remove(course);
            preDic.Remove(course);
            return true;
        }
}
// @lc code=end

