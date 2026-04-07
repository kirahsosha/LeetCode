/*
 * @lc app=leetcode.cn id=2069 lang=java
 *
 * [2069] 模拟行走机器人 II
 */

// @lc code=start
class Robot {

    private final int width;
    private final int height;
    private final int perimeter;
    private int step;

    public Robot(int width, int height) {
        this.width = width;
        this.height = height;
        this.perimeter = (width + height - 2) * 2;
    }

    public void step(int num) {
        step = (int) (((long) step + num - 1) % perimeter) + 1;
    }

    public int[] getPos() {
        int currentStep = step;
        if (currentStep < width) {
            return new int[]{currentStep, 0};
        }
        if (currentStep < width + height - 1) {
            return new int[]{width - 1, currentStep - width + 1};
        }
        if (currentStep < width * 2 + height - 2) {
            return new int[]{width * 2 + height - currentStep - 3, height - 1};
        }
        return new int[]{0, (width + height) * 2 - currentStep - 4};
    }

    public String getDir() {
        int currentStep = step;
        if (currentStep < width) {
            return "East";
        }
        if (currentStep < width + height - 1) {
            return "North";
        }
        if (currentStep < width * 2 + height - 2) {
            return "West";
        }
        return "South";
    }
}

/**
 * Your Robot object will be instantiated and called as such: Robot obj = new
 * Robot(width, height); obj.step(num); int[] param_2 = obj.getPos(); String
 * param_3 = obj.getDir();
 */
// @lc code=end

