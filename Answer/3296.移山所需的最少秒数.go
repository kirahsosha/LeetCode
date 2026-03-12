/*
 * @lc app=leetcode.cn id=3296 lang=golang
 *
 * [3296] 移山所需的最少秒数
 */

// @lc code=start
import (
	"container/heap"
)

// Worker represents an entry in the priority queue.
type Worker struct {
	nextTime int64
	index    int
}

// WorkerHeap implements heap.Interface for Worker pointers.
type WorkerHeap []*Worker

func (h WorkerHeap) Len() int { return len(h) }
func (h WorkerHeap) Less(i, j int) bool {
	return h[i].nextTime < h[j].nextTime
}
func (h WorkerHeap) Swap(i, j int) {
	h[i], h[j] = h[j], h[i]
}

func (h *WorkerHeap) Push(x interface{}) {
	*h = append(*h, x.(*Worker))
}

func (h *WorkerHeap) Pop() interface{} {
	old := *h
	n := len(old)
	x := old[n-1]
	*h = old[0 : n-1]
	return x
}

func minNumberOfSeconds(mountainHeight int, workerTimes []int) int64 {
	worker := len(workerTimes)
	roundCount := make([]int, worker)
	times := make([]int64, worker)
	pq := &WorkerHeap{}
	heap.Init(pq)

	// init pq
	for i := 0; i < worker; i++ {
		heap.Push(pq, &Worker{nextTime: int64(workerTimes[i]), index: i})
	}

	for i := 0; i < mountainHeight; i++ {
		w := heap.Pop(pq).(*Worker)
		roundCount[w.index]++
		times[w.index] = w.nextTime
		newNext := times[w.index] + int64(workerTimes[w.index])*int64(roundCount[w.index]+1)
		heap.Push(pq, &Worker{nextTime: newNext, index: w.index})
	}

	var res int64
	for _, t := range times {
		if t > res {
			res = t
		}
	}
	return res
}

// @lc code=end
