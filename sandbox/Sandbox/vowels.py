word = "cheEse"
vowels = "aeiouAEIOU"

new_word = "".join((char for char in word if char not in vowels))
print(new_word)