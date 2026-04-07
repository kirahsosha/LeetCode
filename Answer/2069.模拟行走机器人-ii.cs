/*
 * @lc app=leetcode.cn id=2069 lang=csharp
 *
 * [2069] 模拟行走机器人 II
 */

// @lc code=start
public class Robot
{
    private readonly int width;
    private readonly int height;
    private readonly int perimeter;
    private int step;

    public Robot(int width, int height)
    {
        this.width = width;
        this.height = height;
        perimeter = (width + height - 2) * 2;
    }

    public void Step(int num)
    {
        step = (int)(((long)step + num - 1) % perimeter) + 1;
    }

    public int[] GetPos()
    {
        var state = GetState();
        return new int[] { state.x, state.y };
    }

    public string GetDir()
    {
        return GetState().dir;
    }

    private (int x, int y, string dir) GetState()
    {
        if (step < width)
        {
            return (step, 0, "East");
        }
        if (step < width + height - 1)
        {
            return (width - 1, step - width + 1, "North");
        }
        if (step < width * 2 + height - 2)
        {
            return (width * 2 + height - step - 3, height - 1, "West");
        }
        return (0, (width + height) * 2 - step - 4, "South");
    }
}

/**
 * Your Robot object will be instantiated and called as such:
 * Robot obj = new Robot(width, height);
 * obj.Step(num);
 * int[] param_2 = obj.GetPos();
 * string param_3 = obj.GetDir();
 */
// @lc code=end

