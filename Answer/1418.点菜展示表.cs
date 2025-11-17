/*
 * @lc app=leetcode.cn id=1418 lang=csharp
 *
 * [1418] 点菜展示表
 */

// @lc code=start
public class Solution {
    public IList<IList<string>> DisplayTable(IList<IList<string>> orders)
        {
            IList<string> name = new List<string>();
            name.Add("Table");
            IList<IList<string>> ans = new List<IList<string>>();
            ans.Add(name);
            if (orders.Count == 0)
            {
                return ans;
            }
            //数据遍历处理
            Dictionary<int, Dictionary<string,int>> dic = new Dictionary<int, Dictionary<string, int>>();
            List<string> foods = new List<string>();
            foreach(var item in orders)
            {
                int desk = int.Parse(item[1]);
                string food = item[2];
                if(dic.ContainsKey(desk))
                {
                    if(dic[desk].ContainsKey(food))
                    {
                        dic[desk][food]++;
                    }
                    else
                    {
                        dic[desk].Add(food, 1);
                    }
                }
                else
                {
                    Dictionary<string, int> t = new Dictionary<string, int>();
                    t.Add(food, 1);
                    dic.Add(desk, t);
                }
                if(!foods.Contains(food))
                {
                    foods.Add(food);
                }
            }
            //格式转换
            foods = foods.OrderBy(p => p, StringComparer.Ordinal).ToList();
            foreach(string food in foods)
            {
                name.Add(food);
            }
            foreach (var deskItem in dic.OrderBy(p => p.Key))
            {
                int desk = deskItem.Key;
                IList<string> table = new List<string>();
                var item = deskItem.Value;
                table.Add(desk.ToString());
                foreach (string food in foods)
                {
                    if (item.ContainsKey(food))
                    {
                        table.Add(item[food].ToString());
                    }
                    else
                    {
                        table.Add("0");
                    }
                }
                ans.Add(table);
            }
            return ans;
        }
}
// @lc code=end

