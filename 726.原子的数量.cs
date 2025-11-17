/*
 * @lc app=leetcode.cn id=726 lang=csharp
 *
 * [726] 原子的数量
 */

// @lc code=start
public class Solution {
    public string CountOfAtoms(string formula)//原子的数量
        {
            Queue<char> queue = new Queue<char>(formula);//转成队列
            StringBuilder sb = new StringBuilder();
            foreach (var item in ParseArr(queue).OrderBy(g => g.Key))//遍历排序好的字典
            {
                sb.Append(item.Key);
                if (item.Value > 1)
                {
                    sb.Append(item.Value);
                }
            }
            return sb.ToString();
        }

        Dictionary<string, int> ParseArr(Queue<char> a)//分析一个数组
        {
            List<char> clist = new List<char>();
            List<char> nlist = new List<char>();
            Dictionary<string, int> dicMain = new Dictionary<string, int>();
            Dictionary<string, int> dicNew = new Dictionary<string, int>();
            while (true)
            {
                if (a.Count == 0 || a.Peek() == ')')//结束递归返回
                {
                    if (a.Count > 0)
                    {
                        //跳过右括号
                        a.Dequeue();
                    }
                    UnionDic(dicMain, dicNew, nlist);
                    return dicMain;//返回字典
                }
                char q = a.Dequeue();
                if (char.IsNumber(q))
                {
                    nlist.Add(q);
                }
                if (char.IsLetter(q))
                {
                    clist.Add(q);
                }
                if (char.IsLetter(q) && (a.Count == 0 || !char.IsLower(a.Peek())))//字母后跟 非小写 是单词终结符
                {
                    dicNew[new string(clist.ToArray())] = 1;//定义为一个字典元素
                }
                if (a.Count == 0 || char.IsUpper(a.Peek()) || a.Peek() == '(')//下一个是 大写 或 左括号 是元素带数字的终结符
                {
                    UnionDic(dicMain, dicNew, nlist);//合并字典
                    dicNew.Clear();
                    clist.Clear();
                    nlist.Clear();//清空
                }
                if (q == '(')//左括号是子字典元素的开始符
                {
                    dicNew = ParseArr(a);//递归分析括号内的元素到dic03
                }
            }
        }

        void UnionDic(Dictionary<string, int> dicMain, Dictionary<string, int> dicNew, List<char> nlist)//按倍数合并字典
        {
            int mul = 1;
            if (nlist.Count > 0)
            {
                //计算个数
                mul = int.Parse(new string(nlist.ToArray()));
            }
            foreach (var item in dicNew)//dic03并入dic02
            {
                if (dicMain.ContainsKey(item.Key))
                {
                    dicMain[item.Key] += item.Value * mul;
                }
                else
                {
                    dicMain[item.Key] = item.Value * mul;
                }
            }
        }
}
// @lc code=end

