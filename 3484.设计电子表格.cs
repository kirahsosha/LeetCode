/*
 * @lc app=leetcode.cn id=3484 lang=csharp
 *
 * [3484] 设计电子表格
 */

// @lc code=start
public class Spreadsheet
{
    int[][] sheets;
    public Spreadsheet(int rows)
    {
        sheets = new int[26][];
        for (int i = 0; i < 26; i++)
        {
            sheets[i] = new int[rows + 1];
        }
    }

    public void SetCell(string cell, int value)
    {
        var col = cell[0] - 'A';
        var row = int.Parse(cell.Substring(1));
        sheets[col][row] = value;
    }

    public void ResetCell(string cell)
    {
        var col = cell[0] - 'A';
        var row = int.Parse(cell.Substring(1));
        sheets[col][row] = 0;
    }

    public int GetValue(string formula)
    {
        var cell1 = formula.Substring(1).Split('+')[0];
        var cell2 = formula.Substring(1).Split('+')[1];

        int value1 = 0, value2 = 0;

        if(!int.TryParse(cell1, out value1))
        {
            var col = cell1[0] - 'A';
            var row = int.Parse(cell1.Substring(1));
            value1 = sheets[col][row];
        }
        if (!int.TryParse(cell2, out value2))
        {
            var col = cell2[0] - 'A';
            var row = int.Parse(cell2.Substring(1));
            value2 = sheets[col][row];
        }
        return value1 + value2;
    }
}

/**
 * Your Spreadsheet object will be instantiated and called as such:
 * Spreadsheet obj = new Spreadsheet(rows);
 * obj.SetCell(cell,value);
 * obj.ResetCell(cell);
 * int param_3 = obj.GetValue(formula);
 */
// @lc code=end

