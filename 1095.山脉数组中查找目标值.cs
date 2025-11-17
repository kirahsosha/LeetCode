/*
 * @lc app=leetcode.cn id=1095 lang=csharp
 *
 * [1095] 山脉数组中查找目标值
 */

// @lc code=start
/**
 * // This is MountainArray's API interface.
 * // You should not implement it, or speculate about its implementation
 * class MountainArray {
 *     public int Get(int index) {}
 *     public int Length() {}
 * }
 */

class Solution {
    public int FindInMountainArray(int target, MountainArray mountainArr) {
        return this.FindInMountainArray(target, mountainArr, 0, mountainArr.Length() - 1, mountainArr.Get(0), mountainArr.Get(mountainArr.Length() - 1));
    }

    private int FindInMountainArray(int target, MountainArray mountainArr, int left, int right, int leftValue, int rightValue)
    {
        if (left == right)
        {
            if (leftValue == target) return left;
            else return -1;
        }
        int mid = (left + right) >> 1, midValue = mountainArr.Get(mid);
        if (midValue == target)
        {
            if (mid == left) return left;
            else
            {
                // 一定在左侧找
                return this.FindInMountainArray(target, mountainArr, left, mid, leftValue, midValue);
            }
        }
        else if (midValue > target)
        {
            // 判断左右是否都单调
            if (leftValue < midValue && leftValue <= target)
            {
                // 左侧可能有
                int res = this.FindInMountainArray(target, mountainArr, left, mid - 1, leftValue, mountainArr.Get(mid - 1));
                if (res != -1)
                {
                    // 左侧有就直接返回了
                    return res;
                }
            }
            if (rightValue < midValue && rightValue <= target)
            {
                // 右侧也有可能有,右侧的优先级是低的,直接返回即可
                return this.FindInMountainArray(target, mountainArr, mid + 1, right, mountainArr.Get(mid + 1), rightValue);
            }
            // 左侧没有，右侧也没有
            return -1;
        }
        else
        {
            // 山巅即可能在左，也可能在右，
            // 由于数组单侧不存在相同数字，因此，可以通过mid-1和mid的比较得到mid是在山巅左侧还是右侧
            int tmp = mid > left ? mountainArr.Get(mid - 1) : -1;
            if (tmp < midValue)
            {
                // mid在山巅左侧，所以只需要找右测就行
                return this.FindInMountainArray(target, mountainArr, mid + 1, right, mountainArr.Get(mid + 1), rightValue);
            }
            else
            {
                // mid在山巅右侧或者正好是山巅，因此，只有可能在左侧
                return this.FindInMountainArray(target, mountainArr, left, mid - 1, leftValue, tmp);
            }
        }
    }
}
// @lc code=end

