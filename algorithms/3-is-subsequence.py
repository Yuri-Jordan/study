class Solution(object):
    def isSubsequence(self, s: str, t: str) -> bool:
        ssIndex = 0
        for letter in t:
            if ssIndex == len(s):
                return True
            if letter == s[ssIndex]:
                ssIndex += 1

        return ssIndex == len(s)

if __name__ == "__main__":
    s = "axc"
    t = "ahbgdc"
    solution = Solution()
    result = solution.isSubsequence(s, t)
    print(f"Input: subsequence = {s}, t = {t}")
    print(f"Output: {result}")