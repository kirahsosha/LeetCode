/*
 * @lc app=leetcode.cn id=1600 lang=csharp
 *
 * [1600] 皇位继承顺序
 */

// @lc code=start
public class ThroneInheritance {

    private IList<string> curOrder;
    private Dictionary<string, bool> isDeath;
    private string KingName;

    public ThroneInheritance(string kingName) {
        isDeath = new Dictionary<string, bool>();
        isDeath.Add(kingName, false);
        KingName = kingName;
    }
    
    public void Birth(string parentName, string childName) {
        isDeath.Add(childName, false);
    }
    
    public void Death(string name) {
        isDeath[name] = true;
    }
    
    public IList<string> GetInheritanceOrder() {
        curOrder = new List<string>();
        curOrder.Add(KingName);
        string name = Successor(KingName, curOrder);
        while(name != null)
        {
            if(!isDeath[name])
            {
                curOrder.Add(name);
            }
            name = Successor(name, curOrder);
        }
        return curOrder;
    }
}

/**
 * Your ThroneInheritance object will be instantiated and called as such:
 * ThroneInheritance obj = new ThroneInheritance(kingName);
 * obj.Birth(parentName,childName);
 * obj.Death(name);
 * IList<string> param_3 = obj.GetInheritanceOrder();
 */
// @lc code=end

