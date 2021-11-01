using System.Collections.Generic;

namespace parser
{
  class Sentences
  {
    public List<Sentence> SentenceList { get; } = new();

    public void Add(Sentence s)
    {
      SentenceList.Add(s);
    }
  }
}
