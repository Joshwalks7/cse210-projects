def two_sum(nums: list[int], target: int) -> list[int]:
    complements = {}
    for i, num in enumerate(nums):
        complement = target - num
        is_complement = complements.get(complement, i)
        if is_complement != i:
            return [is_complement, i]
        else:
            complements[num] = i

print(two_sum([2, 7, 11, 15], 9))
print(two_sum([3, 2, 4], 6))
print(two_sum([3, 3], 6))
