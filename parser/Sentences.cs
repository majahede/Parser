using System.Collections.Generic;

namespace parser
{
  class Sentences
  {
    private readonly List<Sentence> sentences = new List<Sentence>();

    public void Add(Sentence s)
    {
      sentences.Add(s);
    }

    public List<Sentence> GetSentences()
    {
      return sentences;
    }
  }
}
