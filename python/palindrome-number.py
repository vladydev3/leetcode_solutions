class Solution:
    def isPalindrome(self, x: int) -> bool:
        num = str(x)
        for c in range(len(num)):
            if (num[c] != num[len(num)-c-1]):
                return False
        return True