/*
Author: Joshua Walker
Description: class that handles scripture text and methods that hide/return the words.
Date: 5/29/26
Sources:
    1. Class documentation -- CSE 210 Spr 2026, https://byui-cse.github.io/cse210-course-2023/unit03/develop.html
    2. Instructor documentation -- W. Clements 2026, Class Notes
    3. How to split a string -- https://learn.microsoft.com/en-us/dotnet/csharp/how-to/parse-strings-using-split
    4. How to remove items from list -- https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.removeat?view=netframework-4.8.1
*/
using System;

public class JWScripture
{
    private string _jwReference;
    private string _jwVerseText;
    private string[] _jwSplitWords;
    private int jwIterationCount;
    private List<JWWord> _jwWordsList;
    private List<JWWord> _jwPoppableList;

    public JWScripture(JWReference jwReference, string jwVerse)
    {
        // constructor takes verse text, splits it into individual words, calls function to change words into the word class, and calls reference information
        _jwVerseText = jwVerse;
        _jwSplitWords = jwVerse.Split(" ");
        _jwWordsList = new List<JWWord>();
        _jwPoppableList = new List<JWWord>();
        CreateWordLists();
        _jwReference = jwReference.GetReference();
        jwIterationCount = 0;
    }

    public void CreateWordLists()
    {
        // each word in the split list gets passed into a new instance of the Word class
        foreach (string jwSplitWord in _jwSplitWords)
        {
            JWWord word = new JWWord(jwSplitWord);
            // add word to lists
            _jwWordsList.Add(word);
            _jwPoppableList.Add(word);
        }
    }
    public void HideWords()
    {
        // if there are less than three words in the list, hide all remaining words; else choose three words randomly to hide from the list of words
        if (_jwPoppableList.Count < 3)
        {
            foreach (JWWord jwWord in _jwPoppableList)
            {
                jwWord.Hide();
                jwIterationCount++;
            }
        }
        else
        {
            for (int i = 0; i < 3; i++)
            {
                // this is the code for the creativity addition
                Random jwRandomizer = new Random();
                int jwRandNum = jwRandomizer.Next(0, _jwPoppableList.Count);
                _jwPoppableList[jwRandNum].Hide();
                // remove the word from the list that way only visible words can be hidden in the future
                _jwPoppableList.RemoveAt(jwRandNum);
                jwIterationCount++;
            }
        }
    }
    public string WordListToString()
    {
        // string together each version of the words in the list (either the hidden version or visible version) and return it in a nicely compiled way
        string rvalue = "";
        rvalue += _jwReference + " ";
        foreach (JWWord word in _jwWordsList)
        {
            rvalue += word.ReturnWord() + " ";
        }
        return rvalue;
    }
    public bool DetermineContinuation()
    {
        // if the number of words that have been hidden matches the number of words in the in list, tell the program that it should not continue
        if (jwIterationCount == _jwWordsList.Count)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}