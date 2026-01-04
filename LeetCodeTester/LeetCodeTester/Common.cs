using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTester
{
    public class Common
    {
        /// <summary>
        /// 最大公约数 (greatest common divisor)
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int GCD(int a, int b)
        {
            return b == 0 ? a : GCD(b, a % b);
        }

        /// <summary>
        /// 求所有因数
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int[] AllDivisors(int n)
        {
            var res = new HashSet<int>();
            for(int i = 1; i <= Math.Sqrt(n); i++)
            {
                if(n % i == 0)
                {
                    res.Add(i);
                    res.Add(n / i);
                }
            }
            return res.ToArray();
        }

        /// <summary>
        /// 快速选择算法：找到第k小的元素，平均O(n)时间复杂度
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static long QuickSelect(long[] arr, int left, int right, int k)
        {
            while (left < right)
            {
                // 使用三数取中值选择pivot，避免最坏情况
                int index = MedianOfThree(arr, left, right);
                index = Partition(arr, left, right, index);

                if (k == index)
                {
                    return arr[k];
                }
                else if (k < index)
                {
                    right = index - 1;
                }
                else
                {
                    left = index + 1;
                }
            }
            return arr[left];
        }

        // 三数取中值，选择更好的pivot以提高稳定性
        private static int MedianOfThree(long[] arr, int left, int right)
        {
            int mid = left + (right - left) / 2;
            if (arr[right] < arr[left]) Swap(arr, left, right);
            if (arr[mid] < arr[left]) Swap(arr, mid, left);
            if (arr[right] < arr[mid]) Swap(arr, right, mid);
            return mid;
        }

        private static int Partition(long[] arr, int left, int right, int index)
        {
            long value = arr[index];
            Swap(arr, index, right);

            int storeIndex = left;
            for (int i = left; i < right; i++)
            {
                if (arr[i] < value)
                {
                    Swap(arr, storeIndex, i);
                    storeIndex++;
                }
            }
            Swap(arr, right, storeIndex);
            return storeIndex;
        }

        private static void Swap(long[] arr, int i, int j)
        {
            long temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

    }
}
