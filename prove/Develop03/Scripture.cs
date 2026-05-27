using System;
// split string: https://learn.microsoft.com/en-us/dotnet/csharp/how-to/parse-strings-using-split
// removeat https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.removeat?view=netframework-4.8.1

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
        _jwVerseText = jwVerse;
        _jwSplitWords = jwVerse.Split(" ");
        _jwWordsList = new List<JWWord>();
        _jwPoppableList = new List<JWWord>();
        CreateWordLists();
        // add reference call later
        _jwReference = jwReference.GetReference();
        jwIterationCount = 0;
    }

    public void CreateWordLists()
    {
        foreach (string jwSplitWord in _jwSplitWords)
        {
            JWWord word = new JWWord(jwSplitWord);
            _jwWordsList.Add(word);
            _jwPoppableList.Add(word);
        }
    }
    public void HideWords()
    {
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
                Random jwRandomizer = new Random();
                int jwRandNum = jwRandomizer.Next(0, _jwPoppableList.Count);
                _jwPoppableList[jwRandNum].Hide();
                _jwPoppableList.RemoveAt(jwRandNum);
                jwIterationCount++;
            }
        }
    }
    public string WordListToString()
    {
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