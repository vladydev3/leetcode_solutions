from typing import List
def resultsArray(nums: List[int], k: int) -> List[int]:
    response = [0] * (len(nums) - k + 1)
    for i in range(len(nums) - k + 1):
        response[i] = nums[i + k - 1]
        for j in range(k - 1):
            if nums[i + j] != nums[i + j + 1] - 1:
                response[i] = -1
                break
    
    return response