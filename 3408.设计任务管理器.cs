/*
 * @lc app=leetcode.cn id=3408 lang=csharp
 *
 * [3408] 设计任务管理器
 */

// @lc code=start
public class TaskManager {
    private Dictionary<int, int[]> taskInfo;
    private PriorityQueue<int[], int[]> heap;
    
    public TaskManager(IList<IList<int>> tasks) {
        taskInfo = new Dictionary<int, int[]>();
        heap = new PriorityQueue<int[], int[]>(Comparer<int[]>.Create((a, b) => {
            if (a[0] == b[0]) {
                return b[1].CompareTo(a[1]);
            }
            return b[0].CompareTo(a[0]);
        }));
        
        foreach (var task in tasks) {
            int userId = task[0], taskId = task[1], priority = task[2];
            taskInfo[taskId] = new int[] {priority, userId};
            heap.Enqueue(new int[] {priority, taskId}, new int[]{priority, taskId});
        }
    }
    
    public void Add(int userId, int taskId, int priority) {
        taskInfo[taskId] = new int[] {priority, userId};
        heap.Enqueue(new int[] {priority, taskId}, new int[]{priority, taskId});
    }
    
    public void Edit(int taskId, int newPriority) {
        if (taskInfo.ContainsKey(taskId)) {
            taskInfo[taskId][0] = newPriority;
            heap.Enqueue(new int[] {newPriority, taskId}, new int[]{newPriority, taskId});
        }
    }
    
    public void Rmv(int taskId) {
        taskInfo.Remove(taskId);
    }
    
    public int ExecTop() {
        while (heap.Count > 0) {
            var task = heap.Dequeue();
            int priority = task[0], taskId = task[1];
            if (taskInfo.TryGetValue(taskId, out var info) && info[0] == priority) {
                int userId = info[1];
                taskInfo.Remove(taskId);
                return userId;
            }
        }
        
        return -1;
    }
}

/**
 * Your TaskManager object will be instantiated and called as such:
 * TaskManager obj = new TaskManager(tasks);
 * obj.Add(userId,taskId,priority);
 * obj.Edit(taskId,newPriority);
 * obj.Rmv(taskId);
 * int param_4 = obj.ExecTop();
 */
// @lc code=end

