/*
 * @lc app=leetcode.cn id=990 lang=csharp
 *
 * [990] 等式方程的可满足性
 */

// @lc code=start
public class Solution {
    public bool EquationsPossible(string[] equations)
    {
        //所有相等的集合集
        List<List<char>> equitStr = new List<List<char>>();
        //不等的字符串集
        List<string> unEquit = new List<string>();
        foreach (var item in equations)
        {
            if (item[1] == '=')
            {
                //处理相等的字符集和,如果现有的集和里面有就连接,没有就添加新集和
                equitStr = UnionChar(equitStr, item[0], item[3]);
            }
            else
            {
                unEquit.Add(item);
            }
        }
        foreach (var item in unEquit)
        {
            //a!=a  这种情况
            if (item[0] == item[3])
                return false;
            //循环不等集和,如果同一个相等集和里面同时包含左右两边,则返回false
            foreach (var arrChar in equitStr)
            {
                if ((arrChar.Contains(item[0]) && arrChar.Contains(item[3])))
                    return false;
            }
            
        }
        return true;
    }

    private List<List<char>> UnionChar(List<List<char>> allArr,char left,char right)
    {
        List<char> leftArr=null,rightArr=null;
        List<List<char>> removeArr = new List<List<char>>();
        foreach (var item in allArr)
        {
            if (item.Contains(left)&& item.Contains(right))
            {
                leftArr = item;
                rightArr = item;
                removeArr.Add(item);
            }
            //上面的if可以去掉了,在removeArr Distinct一下
            if (item.Contains(left))
            {
                leftArr = item;
                removeArr.Add(item);
            }
            if (item.Contains(right))
            {
                rightArr = item;
                removeArr.Add(item);
            }
        }
        removeArr.ForEach(x =>
        {
            allArr.Remove(x);
        });
        if (leftArr == null)
            leftArr = new List<char>() { left };
        if (rightArr == null)
            rightArr = new List<char>() { right };
        allArr.Add(leftArr.Union(rightArr).Distinct().ToList());
        return allArr;
    }
}
// @lc code=end

