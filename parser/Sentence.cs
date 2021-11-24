using System.Collections.Generic;
using System.Linq;
using tokenizer;

namespace parser
{
    abstract class Sentence
    {
        protected readonly List<TokenMatch> sentence;

        public abstract string EndType { get; }

        public Sentence() 
        {
            sentence = new();
        }

        /// <summary>
        /// Creates a string with the right end-token
        /// </summary>
        /// <returns>The sentence</returns>
        public string GetSentence()
        {
            var words = GetWords();
            string s = string.Join(" ", words);
            return s += EndType;
        }

        public List<string> GetWords()
        {
            return (from tokenMatch in sentence where tokenMatch.Token == "WORD" select tokenMatch.Match).ToList();
        }

        public void Add(TokenMatch tokenMatch)
        {
            sentence.Add(tokenMatch);
        }

        public abstract void SetStyling();
    }
}
