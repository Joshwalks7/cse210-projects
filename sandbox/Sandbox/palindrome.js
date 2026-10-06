const form = document.getElementById("palindrome-form");

form.addEventListener("submit", (event) => {
    event.preventDefault();

    const userText = document.getElementById("palindrome").value;
    
    const isResult = checkPalindrome(userText);

    document.getElementById("result-message").textContent = isResult ? "It's a palindrome!" : "Not a palindrome.";

    form.reset();
})

function checkPalindrome(userInput) {
    const cleaned = userInput.toLowerCase().replace(/[^a-z0-9]/g, "");

    const reversed = cleaned.split("").reverse().join("");

    return cleaned === reversed;
}