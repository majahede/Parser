using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Linq;
using tokenizer;

namespace parser
{
  class Document
  {
    private Sentences sentences = new Sentences();

    public Sentences Parse(string text)
    {
      Tokenizer t = new Tokenizer(CreateGrammar(), text);

      ThrowErrorInvalidSentence(text.Length);

      while (t.ActiveToken.Token != "END")
      {
        ParseSentences(t);
      }
      return sentences;
    }

    private Grammar CreateGrammar()
    {
      Grammar grammar = new Grammar();

      RegexRule r = new RegexRule("WORD", "^[\\w|åäöÅÄÖ]+");
      grammar.Add(r);
      r = new RegexRule("DOT", "^\\.");
      grammar.Add(r);
      r = new RegexRule("EXCLAMATIONMARK", "^\\!");
      grammar.Add(r);
      r = new RegexRule("QUESTIONMARK", "^\\?");
      grammar.Add(r);

      return grammar;
    }

    private void ParseSentences(Tokenizer t)
    {
      Sentence s = new();
      ParseSentence(t, s);
      ThrowErrorInvalidSentence(s.GetSentence().Length);
      sentences.Add(s);
    }


    private void ParseSentence(Tokenizer t, Sentence s)
    {
      while (t.ActiveToken.Token == "WORD")
      {
        s.Add(t.ActiveToken);
        t.GetNextToken();
      }

      s.Add(t.ActiveToken);
      t.GetNextToken();
    }

    private void ThrowErrorInvalidSentence(int length)
    {
      if (length <= 1)
      {
        throw new Exception("The document contains an invalid sentence.");
      }
    }

    public List<Sentence> GetAllSentences()
    {
      return sentences.SentenceList;
    }

    public List<Sentence> GetAllRegularSentences()
    {
      return GetAllSentences().Where(s => s.GetEndType().Token == "DOT").ToList();
    }

    public List<Sentence> GetAllQuestions()
    {
      return GetAllSentences().Where(s => s.GetEndType().Token == "QUESTIONMARK").ToList();
    }

    public List<Sentence> GetAllExclamations()
    {
      return GetAllSentences().Where(s => s.GetEndType().Token == "EXCLAMATIONMARK").ToList();
    }
  }
}

