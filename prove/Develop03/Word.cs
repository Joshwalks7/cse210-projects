using System;
// https://learn.microsoft.com/en-us/dotnet/fundamentals/runtime-libraries/system-string-ctor

public class JWWord
{
    private string _jwVisibleWord;
    private string _jwHiddenWord;
    private bool _jwIsHidden;

    public JWWord(string jwWord)
    {
        _jwVisibleWord = jwWord;
        _jwIsHidden = false;
    
        string jwRepeatedLine = new string('_', jwWord.Count());
        _jwHiddenWord = jwRepeatedLine;
    }
    public void Hide()
    {
        _jwIsHidden = true;
    }
    public string ReturnWord()
    {
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