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
                sentences.ParseSentences(t);
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

