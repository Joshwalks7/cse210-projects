class Solution:

  def countSubstring(self, s: str, sub: str) -> int:
    """Count how many times `sub` appears in `s`, including overlapping matches."""
    num = 0
    s = s.lower()
    sub = sub.lower()
    for i, letter in enumerate(s):
        if s[i : i + len(sub)] == sub:
           num += 1
    return num

solution = Solution()
print(solution.countSubstring("banana", "ana"))  # Should output 2