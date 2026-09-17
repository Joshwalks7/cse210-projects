class Solution:

  def twoSum(self, nums: list[int], target: int) -> list[int]:
    """Return the indices of the two numbers that add up to target."""
    # TODO: Use a hash map to track numbers and their indices as you loop through
    complements ={}
    for i, num in enumerate(nums):
      complement = target - num
      is_complement = complements.get(complement, i)
      if is_complement != i:
        return [is_complement, i]
      else:
        complements[num] = i

solution = Solution()
print(solution.twoSum([2, 7, 11, 15], 9))  # Should output [0, 1]