
using System;
using System.Collections.Generic;
using parser;
using prettyPrinter;
using tokenizer;

static class App
  {
    static void Main(string[] args)
    {
      Document d = new Document();
      d.Parse("I love parsers. Are they fun? Yes! They are fun.");

      PrettyPrinter pp =  new PrettyPrinter(d);
      pp.PrintAllSentences();
      pp.PrintAllRegularSentences();
      pp.PrintAllQuestions();
      pp.PrintAllExclamations();
   }
 }