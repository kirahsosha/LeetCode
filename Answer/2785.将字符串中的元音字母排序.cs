/*
 * @lc app=leetcode.cn id=2785 lang=csharp
 *
 * [2785] 将字符串中的元音字母排序
 */

// @lc code=start
public class Solution
{
    public string SortVowels(string s)
    {
        var change = new Dictionary<char, int>
        {
            { 'A', 0 },
            { 'E', 0 },
            { 'I', 0 },
            { 'O', 0 },
            { 'U', 0 },
            { 'a', 0 },
            { 'e', 0 },
            { 'i', 0 },
            { 'o', 0 },
            { 'u', 0 }
        };
        var indexes = new List<int>();
        var arr = s.ToArray();
        for (int i = 0; i < arr.Length; i++)
        {
            if ("aeiouAEIOU".Contains(arr[i]))
            {
                change[arr[i]]++;
                indexes.Add(i);
            }
        }

        int index = 0;
        for (int i = 0; i < indexes.Count; i++)
        {
            while (index < change.Count && change.ElementAt(index).Value == 0)
            {
                index++;
            }

            var c = change.ElementAt(index).Key;
            arr[indexes[i]] = c;
            change[c]--;
        }
        return new string(arr);
    }
}
// @lc code=end

