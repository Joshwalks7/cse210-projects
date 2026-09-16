def is_palindrome(s: str) -> bool:
    # Write your code here
    left = 0
    right = len(s) -1
    while left < right:
        while left < right and not s[left].isalpha():
            left += 1
        while left < right and not s[right].isalpha():
            right -= 1
        if s[left].lower() != s[right].lower():
            return False
        left += 1
        right -= 1
    return True

# Test your code:
print(is_palindrome("A man, a plan, a canal: Panama"))  # Expected: True
print(is_palindrome("race a car"))                      # Expected: False
print(is_palindrome(" "))                               # Expected: True