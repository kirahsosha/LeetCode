/*
 * @lc app=leetcode.cn id=756 lang=csharp
 *
 * [756] 金字塔转换矩阵
 */

// @lc code=start
public class Solution
{
    public bool PyramidTransition(string bottom, IList<string> allowed)
    {
        var dic = new Dictionary<string, List<char>>();
        foreach (var a in allowed)
        {
            var key = a.Substring(0, 2);
            var value = a[2];
            if (!dic.ContainsKey(key))
            {
                dic.Add(key, new List<char>());
            }
            dic[key].Add(value);
        }
        return CanBuild(bottom);

        bool CanBuild(string layer)
        {
            if (layer.Length == 1)
            {
                return true;
            }
            var nextLayers = new List<string>();
            BuildNextLayer(layer, 0, new StringBuilder(), nextLayers);
            foreach (var nextLayer in nextLayers)
            {
                if (CanBuild(nextLayer))
                {
                    return true;
                }
            }
            return false;
        }

        void BuildNextLayer(string layer, int index, StringBuilder sb, List<string> nextLayers)
        {
            if (index == layer.Length - 1)
            {
                nextLayers.Add(sb.ToString());
                return;
            }
            var key = layer.Substring(index, 2);
            if (dic.ContainsKey(key))
            {
                foreach (var c in dic[key])
                {
                    sb.Append(c);
                    BuildNextLayer(layer, index + 1, sb, nextLayers);
                    sb.Length--;
                }
            }
        }
    }
}
// @lc code=end

