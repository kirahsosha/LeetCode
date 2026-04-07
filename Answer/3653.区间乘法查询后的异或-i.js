/*
 * @lc app=leetcode.cn id=3653 lang=javascript
 *
 * [3653] 区间乘法查询后的异或 I
 */

// @lc code=start
/**
 * @param {number[]} nums
 * @param {number[][]} queries
 * @return {number}
 */
var xorAfterQueries = function (nums, queries) {
  const mod = 1000000007n;
  const n = nums.length;
  const limit = Math.min(n, Math.floor(Math.sqrt(queries.length)));
  const diff = new Array(limit + 1);
  const smallKs = [];
  const used = new Array(limit + 1).fill(false);
  const inverseCache = new Map();

  for (const [l, r, k, v] of queries) {
    if (k <= limit) {
      if (!used[k]) {
        used[k] = true;
        smallKs.push(k);
        diff[k] = new Array(n).fill(1n);
      }

      const value = BigInt(v);
      diff[k][l] = mulMod(diff[k][l], value);
      const end = l + Math.floor((r - l) / k) * k + k;
      if (end < n) {
        diff[k][end] = mulMod(diff[k][end], modInverse(v));
      }
      continue;
    }

    const value = BigInt(v);
    for (let i = l; i <= r; i += k) {
      nums[i] = Number(mulMod(BigInt(nums[i]), value));
    }
  }

  for (const k of smallKs) {
    for (let i = 0; i < n; i++) {
      if (i >= k) {
        diff[k][i] = mulMod(diff[k][i], diff[k][i - k]);
      }
      nums[i] = Number(mulMod(BigInt(nums[i]), diff[k][i]));
    }
  }

  let result = 0;
  for (const num of nums) {
    result ^= num;
  }
  return result;

  function mulMod(a, b) {
    return (a * b) % mod;
  }

  function modInverse(value) {
    let inverse = inverseCache.get(value);
    if (inverse === undefined) {
      inverse = modPow(BigInt(value), mod - 2n);
      inverseCache.set(value, inverse);
    }
    return inverse;
  }

  function modPow(base, exponent) {
    let result = 1n;
    while (exponent > 0n) {
      if ((exponent & 1n) === 1n) {
        result = mulMod(result, base);
      }
      base = mulMod(base, base);
      exponent >>= 1n;
    }
    return result;
  }
};
// @lc code=end
