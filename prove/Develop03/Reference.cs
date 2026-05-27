using System;

public class JWReference
{
    private string _jwBook;
    private int _jwChapter;
    private string _jwVerse;

    public JWReference(string jwBook, int jwChapter, int jwVerse)
    {
        _jwBook = jwBook;
        _jwChapter = jwChapter;
        _jwVerse = $"{jwVerse}";
    }
    public JWReference(string jwBook, int jwChapter, int jwFirstVerse, int jwLastVerse)
    {
        _jwBook = jwBook;
        _jwChapter = jwChapter;
        _jwVerse = $"{jwFirstVerse}-{jwLastVerse}";
    }
    public string GetReference()
    {
        return $"{_jwBook} {_jwChapter} {_jwVerse}:";
    }
}