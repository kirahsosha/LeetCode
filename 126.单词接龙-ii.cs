/*
 * @lc app=leetcode.cn id=126 lang=csharp
 *
 * [126] 单词接龙 II
 */

// @lc code=start
public class Solution {
    private static int INF = 1 << 20;
    private Dictionary<string, int> wordId; // 单词到id的映射
    private List<string> idWord; // id到单词的映射
    private List<int>[] edges; // 图的边

    public Solution()
    {
        wordId = new Dictionary<string, int>();
        idWord = new List<string>();
    }

    // 两个字符串是否可以通过改变一个字母后相等
    bool transformCheck(string str1, string str2)
    {
        int differences = 0;
        for (int i = 0; i < str1.Length && differences < 2; i++)
        {
            if (str1[i] != str2[i])
            {
                differences++;
            }
        }
        return differences == 1;
    }

    public IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList) {
        int id = 0;
        //将wordList所有单词加入wordId中, 并为每一个单词分配一个id
        foreach (string word in wordList)
        {
            if (!wordId.ContainsKey(word))
            { 
                wordId.Add(word, id++);
                idWord.Add(word);
            }
        }
        // 若endWord不在wordList中 则无解
        if (!wordId.ContainsKey(endWord))
        {
            return new List<IList<string>>();
        }
        // 把beginWord也加入wordId中
        if (!wordId.ContainsKey(beginWord))
        {
            wordId.Add(beginWord, id++);
            idWord.Add(beginWord);
        }
        // 初始化存边用的数组
        edges = new List<int>[idWord.Count];
        for (int i = 0; i < idWord.Count; i++)
        {
            edges[i] = new List<int>();
        }
        // 添加边
        for (int i = 0; i < idWord.Count; i++)
        {
            for (int j = i + 1; j < idWord.Count; j++)
            {
                // 若两者可以通过转换得到 则在它们间建一条无向边
                if (transformCheck(idWord[i], idWord[j]))
                {
                    edges[i].Add(j);
                    edges[j].Add(i);
                }
            }
        }

        int dest = wordId[endWord]; // 目的ID
        IList<IList<string>> res = new List<IList<string>>(); // 存答案
        int[] cost = new int[id]; // 到每个点的代价
        for (int i = 0; i < id; i++)
        {
            cost[i] = INF; // 每个点的代价初始化为无穷大
        }

        // 将起点加入队列 并将其cost设为0
        Queue<List<int>> q = new Queue<List<int>>();
        List<int> tmpBegin = new List<int>();
        tmpBegin.Add(wordId[beginWord]);
        q.Enqueue(tmpBegin);
        cost[wordId[beginWord]] = 0;

        // 开始广度优先搜索
        while (q.Count != 0)
        {
            List<int> now = q.Dequeue();
            int last = now[now.Count - 1]; // 最近访问的点
            if (last == dest)
            {
                // 若该点为终点则将其存入答案res中
                List<string> tmp = new List<string>();
                foreach (int index in now)
                {
                    tmp.Add(idWord[index]); // 转换为对应的word
                }
                res.Add(tmp);
            }
            
            {
                // 该点不为终点 继续搜索
                for (int i = 0; i < edges[last].Count; i++)
                {
                    int to = edges[last][i];
                    // 此处<=目的在于把代价相同的不同路径全部保留下来
                    if (cost[last] + 1 <= cost[to])
                    {
                        cost[to] = cost[last] + 1;
                        // 把to加入路径中
                        List<int> tmp = new List<int>(now);
                        tmp.Add(to);
                        q.Enqueue(tmp); // 把这个路径加入队列
                    }
                }
            }
        }
        return res;
    }
}
// @lc code=end

