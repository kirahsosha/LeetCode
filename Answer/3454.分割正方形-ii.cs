/*
 * @lc app=leetcode.cn id=3454 lang=csharp
 *
 * [3454] 分割正方形 II
 */

// @lc code=start
public class Solution
{
    public double SeparateSquares(int[][] squares)
    {
        var set = new HashSet<int>();
        foreach (int[] square in squares)
        {
            set.Add(square[0]);
            set.Add(square[0] + square[2]);
        }
        var xValues = new List<int>(set);
        xValues.Sort((a, b) => a - b);
        var st = new SegmentTree(xValues);
        var yValues = new List<int[]>();
        int n = squares.Length;
        for (int i = 0; i < n; i++)
        {
            yValues.Add([squares[i][1], i, 1]);
            yValues.Add([squares[i][1] + squares[i][2], i, -1]);
        }
        yValues.Sort((a, b) =>
        {
            if (a[0] != b[0])
            {
                return a[0] - b[0];
            }
            else if (a[1] != b[1])
            {
                return a[1] - b[1];
            }
            else
            {
                return a[2] - b[2];
            }
        });
        long totalArea = 0;
        var areas = new List<long>();
        var intervals = new List<int[]>();
        areas.Add(0);
        intervals.Add([-1, -1]);
        var yValuesCount = yValues.Count;
        var yValuesIndex = 0;
        while (yValuesIndex < yValuesCount)
        {
            var prev = yValuesIndex;
            while (yValuesIndex < yValuesCount - 1 && yValues[yValuesIndex][0] == yValues[yValuesIndex + 1][0])
            {
                yValuesIndex++;
            }
            if (yValuesIndex < yValuesCount - 1)
            {
                for (var i = prev; i <= yValuesIndex; i++)
                {
                    var arr = yValues[i];
                    var index = arr[1];
                    var delta = arr[2];
                    var start = BinarySearchXValue(xValues, squares[index][0]) + 1;
                    var end = BinarySearchXValue(xValues, squares[index][0] + squares[index][2]);
                    st.Update(0, delta, start, end);
                }
                var interval = new int[] { yValues[yValuesIndex][0], yValues[yValuesIndex + 1][0] };
                long currArea = (long)st.GetLength() * (interval[1] - interval[0]);
                totalArea += currArea;
                areas.Add(totalArea);
                intervals.Add(interval);
            }
            yValuesIndex++;
        }
        double halfArea = totalArea / 2.0;
        var areaIndex = BinarySearchArea(areas, halfArea);
        double areaDiff = areas[areaIndex] - halfArea;
        double ratio = areaDiff / (areas[areaIndex] - areas[areaIndex - 1]);
        var targetInterval = intervals[areaIndex];
        return targetInterval[1] - (targetInterval[1] - targetInterval[0]) * ratio;

        int BinarySearchXValue(List<int> xValues, int target)
        {
            int low = 0, high = xValues.Count;
            while (low < high)
            {
                int mid = low + (high - low) / 2;
                if (xValues[mid] >= target)
                {
                    high = mid;
                }
                else
                {
                    low = mid + 1;
                }
            }
            return low;
        }

        int BinarySearchArea(List<long> areas, double target)
        {
            int low = 0, high = areas.Count;
            while (low < high)
            {
                int mid = low + (high - low) / 2;
                if (areas[mid] >= target)
                {
                    high = mid;
                }
                else
                {
                    low = mid + 1;
                }
            }
            return low;
        }
    }
}


public class SegmentTree
{
    private int n;
    private int[] cover;
    private int[] length;
    private int[] maxLength;

    public SegmentTree(IList<int> nums)
    {
        this.n = nums.Count;
        this.cover = new int[n * 4 + 1];
        this.length = new int[n * 4 + 1];
        this.maxLength = new int[n * 4 + 1];
        Build(0, n - 2, 0, nums);
    }

    public int GetLength()
    {
        return length[0];
    }

    public void Update(int index, int delta, int start, int end)
    {
        Update(index, delta, start, end, 1, n - 1);
    }

    private void Build(int start, int end, int treeIndex, IList<int> nums)
    {
        if (start == end)
        {
            maxLength[treeIndex] = nums[start + 1] - nums[start];
            return;
        }
        int mid = start + (end - start) / 2;
        Build(start, mid, treeIndex * 2 + 1, nums);
        Build(mid + 1, end, treeIndex * 2 + 2, nums);
        maxLength[treeIndex] = maxLength[treeIndex * 2 + 1] + maxLength[treeIndex * 2 + 2];
    }

    private void Update(int index, int delta, int rangeStart, int rangeEnd, int treeStart, int treeEnd)
    {
        if (treeStart > rangeEnd || treeEnd < rangeStart)
        {
            return;
        }
        if (treeStart >= rangeStart && treeEnd <= rangeEnd)
        {
            cover[index] += delta;
            UpdateLength(index, treeStart, treeEnd);
            return;
        }
        int mid = treeStart + (treeEnd - treeStart) / 2;
        Update(index * 2 + 1, delta, rangeStart, rangeEnd, treeStart, mid);
        Update(index * 2 + 2, delta, rangeStart, rangeEnd, mid + 1, treeEnd);
        UpdateLength(index, treeStart, treeEnd);
    }

    private void UpdateLength(int index, int treeStart, int treeEnd)
    {
        if (cover[index] > 0)
        {
            length[index] = maxLength[index];
        }
        else if (treeStart == treeEnd)
        {
            length[index] = 0;
        }
        else
        {
            length[index] = length[index * 2 + 1] + length[index * 2 + 2];
        }
    }
}
// @lc code=end

