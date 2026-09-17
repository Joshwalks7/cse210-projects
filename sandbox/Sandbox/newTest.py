class Solution:
    def reverseString(self, s: list[str]) -> None:
            """
            Do not return anything, modify s in-place instead.
            """
            length = len(s) -1
            for i, letter in enumerate(s):
                if i < len(s) /2:
                    s[i] = s[length]
                    s[length] = letter
                    length -= 1
solution = Solution()
strin = ["h","e","l","l","o"]
solution.reverseString(strin)
print(strin)