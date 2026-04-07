/*
 * @lc app=leetcode.cn id=3653 lang=typescript
 *
 * [3653] 区间乘法查询后的异或 I
 */

// @lc code=start
function xorAfterQueries(nums: number[], queries: number[][]): number {
  const mod = 1000000007n;
  const n = nums.length;
  const limit = Math.min(n, Math.floor(Math.sqrt(queries.length)));
  const diff: Array<bigint[] | undefined> = new Array(limit + 1);
  const smallKs: number[] = [];
  const used = new Array<boolean>(limit + 1).fill(false);
  const inverseCache = new Map<number, bigint>();

  for (const [l, r, k, v] of queries) {
    if (k <= limit) {
      if (!used[k]) {
        used[k] = true;
        smallKs.push(k);
        diff[k] = new Array<bigint>(n).fill(1n);
      }

      const value = BigInt(v);
      diff[k]![l] = mulMod(diff[k]![l], value);
      const end = l + Math.floor((r - l) / k) * k + k;
      if (end < n) {
        diff[k]![end] = mulMod(diff[k]![end], modInverse(v));
      }
      continue;
    }

    const value = BigInt(v);
    for (let i = l; i <= r; i += k) {
      nums[i] = Number(mulMod(BigInt(nums[i]), value));
    }
  }

  for (const k of smallKs) {
    const current = diff[k]!;
    for (let i = 0; i < n; i++) {
      if (i >= k) {
        current[i] = mulMod(current[i], current[i - k]);
      }
      nums[i] = Number(mulMod(BigInt(nums[i]), current[i]));
    }
  }

  let result = 0;
  for (const num of nums) {
    result ^= num;
  }
  return result;

  function mulMod(a: bigint, b: bigint): bigint {
    return (a * b) % mod;
  }

  function modInverse(value: number): bigint {
    let inverse = inverseCache.get(value);
    if (inverse === undefined) {
      inverse = modPow(BigInt(value), mod - 2n);
      inverseCache.set(value, inverse);
    }
    return inverse;
  }

  function modPow(base: bigint, exponent: bigint): bigint {
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
}
// @lc code=end
