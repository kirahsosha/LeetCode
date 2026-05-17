/*
 * @lc app=leetcode.cn id=1306 lang=typescript
 *
 * [1306] 跳跃游戏 III
 */

// @lc code=start
function canReach(arr: number[], start: number): boolean {
  const visited = new Array<boolean>(arr.length).fill(false);
  const stack: number[] = [start];
  visited[start] = true;
  while (stack.length > 0) {
    const index = stack.pop()!;
    if (arr[index] === 0) {
      return true;
    }

    const next = index + arr[index];
    if (next < arr.length && !visited[next]) {
      visited[next] = true;
      stack.push(next);
    }

    const prev = index - arr[index];
    if (prev >= 0 && !visited[prev]) {
      visited[prev] = true;
      stack.push(prev);
    }
  }

  return false;
}
// @lc code=end
