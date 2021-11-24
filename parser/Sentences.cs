using System;
using System.Collections.Generic;
using tokenizer;

namespace parser
{
    class Sentences
    {
        public List<Sentence> SentenceList { get; } = new();

        public void ParseSentences(Tokenizer t)
        {
            var words = ParseWords(t);
            Sentence s = CreateSentenceType(t, words);

            ThrowErrorInvalidSentence(s.GetSentence().Length);

            SentenceList.Add(s);
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

        private Sentence CreateSentenceType(Tokenizer t, List<TokenMatch> words) 
        {
            SentenceFactory factory = new();
            Sentence sentence = factory.GetSentenceType(t.ActiveToken);

            foreach(var w in words) 
            {
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
    }
}
