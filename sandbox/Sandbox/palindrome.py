def is_palindrome(s: str) -> bool:
    # Write your code here
    clean_string = "".join(filter(str.isalnum, s)).lower()
    for original_letter, flipped_letter in zip(clean_string, reversed(clean_string)):
        if original_letter != flipped_letter:
            return False
    return True

# Test your code:
print(is_palindrome("A man, a plan, a canal: Panama"))  # Expected: True
print(is_palindrome("race a car"))                      # Expected: False
print(is_palindrome(" "))                               # Expected: True