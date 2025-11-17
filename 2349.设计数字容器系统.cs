/*
 * @lc app=leetcode.cn id=2349 lang=csharp
 *
 * [2349] 设计数字容器系统
 */

// @lc code=start
public class NumberContainers
{
    Dictionary<int, int> container;
    Dictionary<int, List<int>> numbers;

    public NumberContainers()
    {
        container = new Dictionary<int, int>();
        numbers = new Dictionary<int, List<int>>();
    }

    public void Change(int index, int number)
    {
        if (container.ContainsKey(index))
        {
            var oldValue = container[index];
            container[index] = number;
            numbers[oldValue].Remove(index);
        }
        else
        {
            container.Add(index, number);
        }
        if (numbers.ContainsKey(number))
        {
            numbers[number].Add(index);
        }
        else
        {
            numbers.Add(number, new List<int> { index });
        }
    }

    public int Find(int number)
    {
        if (!numbers.ContainsKey(number))
        {
            return -1;
        }
        else if (numbers[number].Count == 0)
        {
            return -1;
        }
        else
        {
            return numbers[number].Min();
        }
    }
}

/**
 * Your NumberContainers object will be instantiated and called as such:
 * NumberContainers obj = new NumberContainers();
 * obj.Change(index,number);
 * int param_2 = obj.Find(number);
 */
// @lc code=end

