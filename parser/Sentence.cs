using System;
using System.Collections.Generic;
using System.Linq;
using tokenizer;

namespace parser
{
  class Sentence
  {
    private readonly List<TokenMatch> sentence = new List<TokenMatch>();

    /// <summary>
    /// Creates a string with the right end-token
    /// </summary>
    /// <returns>The sentence</returns>
    public string GetSentence()
    {
      var words = GetWords();
      string s = string.Join(" ", words);
      return s += GetEndType().Match;
    }

    public List<string> GetWords()
    {
      return (from tokenMatch in sentence where tokenMatch.Token == "WORD" select tokenMatch.Match).ToList();
    }

    public TokenMatch GetEndType()
    {
      return sentence.Last();
    }

    public void Add(TokenMatch tokenMatch)
    {
      sentence.Add(tokenMatch);
    }
  }
}
