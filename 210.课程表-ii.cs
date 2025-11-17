/*
 * @lc app=leetcode.cn id=210 lang=csharp
 *
 * [210] 课程表 II
 */

// @lc code=start
public class Solution {
    public int[] FindOrder(int numCourses, int[][] prerequisites) {
        IEnumerable<int> enumerable = Enumerable.Range(0, numCourses);
        //课程依赖列表
        List<int>[] list = enumerable.Select(c => new List<int>()).ToArray();
        foreach (int[] item in prerequisites)
        {
            list[item[0]].Add(item[1]);
        }
        //满足条件的列表
        var trueList = new HashSet<int>();
        for (int i = 0; i < numCourses; i++)
        {
            if (!DFS(trueList, new HashSet<int>(), list, i))
            {
                return new int[0];
            }
        }
        return trueList.ToArray();
    }
    
    public bool DFS(HashSet<int> trueList, HashSet<int> used, List<int>[] list, int id)
    {
        if (trueList.Contains(id))
        {
            return true;
        }
        if (used.Contains(id))
        {
            return false;
        }
        else
        {
            used.Add(id);
        }
        foreach (int item in list[id])
        {
            if (DFS(trueList, used, list, item) == false)
            {
                return false;
            }
        }
        trueList.Add(id);
        return true;
    }
}
// @lc code=end

