class Solution:

  def isAnagram(self, s: str, t: str) -> bool:
    # TODO: Use a hash map or Counter to check if both strings have the exact same character counts
    if len(s) != len(t):
        return False
    s = s.lower()
    t = t.lower()
    s_letters = {}
    for letter in s:
      s_letters[letter] = s_letters.get(letter, 0) + 1
    t_letters = {}
    for tletter in t:
      t_letters[tletter] = t_letters.get(tletter, 0) + 1
    for letter, count in s_letters.items():
      if count != t_letters.get(letter, 0):
        return False
    return True
    

solution = Solution()
print(solution.isAnagram("cArr", "Rarc"))