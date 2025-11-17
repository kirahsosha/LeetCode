/*
 * @lc app=leetcode.cn id=88 lang=cpp
 *
 * [88] 合并两个有序数组
 */

// @lc code=start
class Solution {
public:
    void merge(vector<int>& nums1, int m, vector<int>& nums2, int n) {
		if (m == 0)
		{
			for (int i = 0; i < n; i++)
			{
				nums1[i] = nums2[i];
			}
			return;
		}
		if (n == 0) return;
		int a = 0, b = 0;
		vector<int> nums3 = nums1;
		for (int i = 0; i < m + n; i++)
		{
			if (a == m)
			{
				nums1[i] = nums2[b];
				b++;
			}
			else if (b == n)
			{
				nums1[i] = nums3[a];
				a++;
			}
			else if (nums3[a] <= nums2[b])
			{
				nums1[i] = nums3[a];
				a++;
			}
			else
			{
				nums1[i] = nums2[b];
				b++;
			}
		}
		return;
    }
};
// @lc code=end

