using System;
using System.Collections.Generic;
using System.Linq;
using tokenizer;

namespace parser
{
  class Document
  {
    private readonly Sentences sentences = new Sentences();

    public Sentences Parse(string text)
    {
      Tokenizer t = new(CreateGrammar(), text);

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

      RegexRule r = new("WORD", "^[\\w|åäöÅÄÖ]+");
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
      var words = ParseWords(t);
      Sentence s = CreateSentenceType(t, words);

      ThrowErrorInvalidSentence(s.GetSentence().Length);

      sentences.Add(s);
    }

    private List<TokenMatch> ParseWords(Tokenizer t)
    {
      List<TokenMatch> words = new();

      while (t.ActiveToken.Token == "WORD")
      {
        words.Add(t.ActiveToken);
        t.GetNextToken();
      }

      return words;
    }

    private Sentence CreateSentenceType(Tokenizer t, List<TokenMatch> words) {
        SentenceFactory factory = new();
        Sentence sentence = factory.GetSentenceType(t.ActiveToken);

        foreach(var w in words) {
          sentence.Add(w);
        }

        sentence.Add(t.ActiveToken);
        t.GetNextToken();

        return sentence;
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
      return GetAllSentences().Where(s => s is RegularSentence).ToList();
    }

    public List<Sentence> GetAllQuestions()
    {
      return GetAllSentences().Where(s => s is Question).ToList();
    }

    public List<Sentence> GetAllExclamations()
    {
      return GetAllSentences().Where(s => s is Exclamation).ToList();
    }
  }
}

