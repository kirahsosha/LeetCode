/*
 * @lc app=leetcode.cn id=3433 lang=golang
 *
 * [3433] 统计用户被提及情况
 */

// @lc code=start
package main

import (
	"container/heap"
	"strconv"
	"strings"
)

// 优先队列中的元素
type Item struct {
	timestamp int // 时间戳，用于排序
	event     int // 事件类型: 0=MESSAGE, 1=OFFLINE, 2=ONLINE
	id        int // 用户ID，-1代表HERE
}

// PriorityQueue 实现 heap.Interface
type PriorityQueue []*Item

func (pq PriorityQueue) Len() int { return len(pq) }

// Less 定义最小堆：时间戳小的优先级高
func (pq PriorityQueue) Less(i, j int) bool {
	return pq[i].timestamp < pq[j].timestamp
}

func (pq PriorityQueue) Swap(i, j int) {
	pq[i], pq[j] = pq[j], pq[i]
}

// Push 向堆中添加元素
func (pq *PriorityQueue) Push(x interface{}) {
	item := x.(*Item)
	*pq = append(*pq, item)
}

// Pop 从堆中移除并返回元素
func (pq *PriorityQueue) Pop() interface{} {
	old := *pq
	n := len(old)
	item := old[n-1]
	*pq = old[0 : n-1]
	return item
}

func countMentions(numberOfUsers int, events [][]string) []int {
	pq := &PriorityQueue{}
	heap.Init(pq)
	all := 0

	for _, ev := range events {

		e := 0
		if ev[0] != "MESSAGE" {
			e = 1
		}

		t, _ := strconv.Atoi(ev[1])
		t *= 3

		ids := strings.ReplaceAll(ev[2], "id", "")
		ids = strings.TrimSpace(ids)

		if e == 0 {
			if ids == "ALL" {
				all++
			} else if ids == "HERE" {
				heap.Push(pq, &Item{timestamp: t, event: e, id: -1})
			} else {
				idList := strings.Split(ids, " ")
				for _, idStr := range idList {
					id, _ := strconv.Atoi(idStr)
					heap.Push(pq, &Item{timestamp: t, event: e, id: id})
				}
			}
		} else {
			id, _ := strconv.Atoi(ids)
			heap.Push(pq, &Item{timestamp: t - 1, event: e, id: id})
			heap.Push(pq, &Item{timestamp: t + 178, event: 2, id: id})
		}
	}

	status := make([]int, numberOfUsers)
	res := make([]int, numberOfUsers)

	if all > 0 {
		for i := 0; i < numberOfUsers; i++ {
			res[i] = all
		}
	}

	for pq.Len() > 0 {
		item := heap.Pop(pq).(*Item)
		e := item.event

		if e == 0 {
			if item.id == -1 {
				for i := 0; i < numberOfUsers; i++ {
					if status[i] == 0 {
						res[i]++
					}
				}
			} else {
				res[item.id]++
			}
		} else if e == 1 {
			status[item.id] = -1
		} else {
			status[item.id] = 0
		}
	}

	return res
}

// @lc code=end
