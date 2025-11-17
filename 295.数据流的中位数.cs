/*
 * @lc app=leetcode.cn id=295 lang=csharp
 *
 * [295] 数据流的中位数
 */

// @lc code=start
public class MedianFinder
{
    private List<int> arr;
    private int max = 0;

    public MedianFinder()
    {
        arr = new List<int>();
    }

    public void AddNum(int num)
    {
        if (arr.Count == 0)
        {
            arr.Add(num);
            max = num;
        }
        else
        {
            if (num > max)
            {
                arr.Add(num);
                max = num;
            }
            else
            {
                int l = 0, r = arr.Count - 1;
                while (l <= r)
                {
                    if (l == r)
                    {
                        arr.Insert(l, num);
                        break;
                    }
                    int mid = l + (int)Math.Floor((double)(r - l) / 2);
                    if (arr[mid] < num)
                    {
                        l = mid + 1;
                    }
                    else if (arr[mid] >= num)
                    {
                        r = mid;
                    }
                }
            }
        }

    }

    public double FindMedian()
    {
        int mid = (int)Math.Floor((double)(arr.Count - 1) / 2);
        // Console.WriteLine(mid);
        if (arr.Count % 2 == 0)
        {
            return ((arr[mid] + arr[mid + 1]) / 2.0);
        }
        return (double)arr[mid];
    }
}

/**
 * Your MedianFinder object will be instantiated and called as such:
 * MedianFinder obj = new MedianFinder();
 * obj.AddNum(num);
 * double param_2 = obj.FindMedian();
 */
// @lc code=end

