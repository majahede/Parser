using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using parser;
using tokenizer;

namespace prettyPrinter
{
  class PrettyPrinter
  {
    private readonly Document d;

    public PrettyPrinter(Document d)
    {
      this.d = d;
    }

    public void PrintAllSentences()
    {
      Console.WriteLine("All sentences: ");
      Print(d.GetAllSentences());
    }

    public void PrintAllRegularSentences()
    {
      Console.WriteLine("Regular sentences: ");
      Print(d.GetAllRegularSentences());
    }

    public void PrintAllQuestions()
    {
      Console.WriteLine("Questions: ");
      Print(d.GetAllQuestions());
    }

    public void PrintAllExclamations()
    {
      Console.WriteLine("Exclamations: ");
      Print(d.GetAllExclamations());
    }

    private void Print(List<Sentence> sentences)
    {
      Console.WriteLine("---------");
      foreach (Sentence s in sentences)
      {
        s.SetStyling();
        Console.WriteLine(sentences.IndexOf(s) + 1 + ": " + s.GetSentence());
        Console.ResetColor();
      }
      Console.WriteLine("---------");
    }
  }
}

