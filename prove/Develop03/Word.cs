/*
Author: Joshua Walker
Description: class that handles scripture text and methods that hide/return the words.
Date: 5/29/26
Sources:
    1. Class documentation -- CSE 210 Spr 2026, https://byui-cse.github.io/cse210-course-2023/unit03/develop.html
    2. Instructor documentation -- W. Clements 2026, Class Notes
    3. How to repeat a single character multiple times -- https://learn.microsoft.com/en-us/dotnet/fundamentals/runtime-libraries/system-string-ctor
*/
using System;

public class JWWord
{
    private string _jwVisibleWord;
    private string _jwHiddenWord;
    private bool _jwIsHidden;

    public JWWord(string jwWord)
    {
        // constructor sets visible word variable and counts the number of characters in the word. It sets the hidden variable to be underscores that represent the number of letters in the word
        _jwVisibleWord = jwWord;
        _jwIsHidden = false;
    
        string jwRepeatedLine = new string('_', jwWord.Count());
        _jwHiddenWord = jwRepeatedLine;
    }
    public void Hide()
    {
        // simply sets boolean to true
        _jwIsHidden = true;
    }
    public string ReturnWord()
    {
        // method determines which version of the word should be returned -- the hidden one (underscores) or visible one
        if (_jwIsHidden == false)
        {
            return _jwVisibleWord;
        }
        else
        {
            return _jwHiddenWord;
        }
    }

}