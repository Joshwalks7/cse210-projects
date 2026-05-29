/*
Author: Joshua Walker
Description: class that holds scripture reference information and compiles it into a string
Date: 5/29/26
Sources:
    1. Class documentation -- CSE 210 Spr 2026, https://byui-cse.github.io/cse210-course-2023/unit03/develop.html
    2. Instructor documentation -- W. Clements 2026, Class Notes
*/
using System;

public class JWReference
{
    private string _jwBook;
    private int _jwChapter;
    private string _jwVerse;

    public JWReference(string jwBook, int jwChapter, int jwVerse)
    {
        // normal constructor that handles just one verse
        _jwBook = jwBook;
        _jwChapter = jwChapter;
        _jwVerse = $"{jwVerse}";
    }
    public JWReference(string jwBook, int jwChapter, int jwFirstVerse, int jwLastVerse)
    {
        // handles multiple verses
        _jwBook = jwBook;
        _jwChapter = jwChapter;
        _jwVerse = $"{jwFirstVerse}-{jwLastVerse}";
    }
    public string GetReference()
    {
        // compiles variables and return them as a string
        return $"{_jwBook} {_jwChapter}: {_jwVerse}:";
    }
}