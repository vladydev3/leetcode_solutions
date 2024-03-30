import heapq

class Solution:
    def findRelativeRanks(self, score: List[int]) -> List[str]:
        heap = []
        for i, s in enumerate(score):
            heapq.heappush(heap, (-s, i))
        
        result = [0] * len(score)
        medals = ["Gold Medal", "Silver Medal", "Bronze Medal"]
        
        for i in range(len(score)):
            s, idx = heapq.heappop(heap)
            if i < 3:
                result[idx] = medals[i]
            else:
                result[idx] = str(i + 1)
        
        return result