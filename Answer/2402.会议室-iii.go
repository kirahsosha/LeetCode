import (
	"container/heap"
	"sort"
)

/*
 * @lc app=leetcode.cn id=2402 lang=golang
 *
 * [2402] 会议室 III
 */

// @lc code=start

type RoomHeap []int

func (h RoomHeap) Len() int {
	return len(h)
}
func (h RoomHeap) Less(i, j int) bool {
	return h[i] < h[j]
}
func (h RoomHeap) Swap(i, j int) {
	h[i], h[j] = h[j], h[i]
}
func (h *RoomHeap) Push(x interface{}) {
	*h = append(*h, x.(int))
}
func (h *RoomHeap) Pop() interface{} {
	old := *h
	x := old[len(old)-1]
	*h = old[:len(old)-1]
	return x
}

type UsedRoom struct{ endTime, room int }
type UsedHeap []UsedRoom

func (h UsedHeap) Len() int { return len(h) }
func (h UsedHeap) Less(i, j int) bool {
	if h[i].endTime == h[j].endTime {
		return h[i].room < h[j].room
	}
	return h[i].endTime < h[j].endTime
}
func (h UsedHeap) Swap(i, j int)       { h[i], h[j] = h[j], h[i] }
func (h *UsedHeap) Push(x interface{}) { *h = append(*h, x.(UsedRoom)) }
func (h *UsedHeap) Pop() interface{} {
	old := *h
	x := old[len(old)-1]
	*h = old[:len(old)-1]
	return x
}

func mostBooked(n int, meetings [][]int) int {
	sort.Slice(meetings, func(i, j int) bool { return meetings[i][0] < meetings[j][0] })
	free := &RoomHeap{}
	for i := 0; i < n; i++ {
		*free = append(*free, i)
	}
	heap.Init(free)
	busy := &UsedHeap{}
	heap.Init(busy)
	res := make([]int, n)
	curTime := 0
	for _, meeting := range meetings {
		if curTime < meeting[0] {
			curTime = meeting[0]
		}
		for busy.Len() > 0 && (*busy)[0].endTime <= curTime {
			heap.Push(free, heap.Pop(busy).(UsedRoom).room)
		}
		if free.Len() == 0 {
			curTime = (*busy)[0].endTime
			for busy.Len() > 0 && (*busy)[0].endTime <= curTime {
				heap.Push(free, heap.Pop(busy).(UsedRoom).room)
			}
		}
		room := heap.Pop(free).(int)
		res[room]++
		heap.Push(busy, UsedRoom{curTime + meeting[1] - meeting[0], room})
	}
	ans := 0
	for i := 1; i < n; i++ {
		if res[i] > res[ans] {
			ans = i
		}
	}
	return ans
}

// @lc code=end
